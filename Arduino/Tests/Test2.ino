#include <avr/io.h>
#include <avr/interrupt.h>

#ifndef F_CPU
#define F_CPU 16000000UL
#endif

#define USART_BAUDRATE 115200
#define UBRR_VALUE ((F_CPU / (USART_BAUDRATE * 16UL)))

#define PD_5 (1 << PD5)
#define PD_6 (1 << PD6)

volatile uint8_t pin11_enabled = 0;
volatile uint8_t pin12_enabled = 0;

void USART_Init() {
  UBRR0H = (uint8_t)(UBRR_VALUE >> 8);
  UBRR0L = (uint8_t)(UBRR_VALUE);

  UCSR0B |= (1 << RXCIE0) | (1 << TXEN0) | (1 << RXEN0);
  UCSR0C |= (1 << UCSZ01) | (1 << UCSZ00);
}

void USART_Transmit(uint8_t data) {
  while (!(UCSR0A & (1 << UDRE0)));
  UDR0 = data;
}

ISR(USART_RX_vect) {
  char received_byte = UDR0;
  if (received_byte == 'A')
    pin11_enabled = !pin11_enabled;
  else if (received_byte == 'B')
    pin12_enabled = !pin12_enabled;

  USART_Transmit(received_byte);
}

void Timer0_Init() {
  TCCR0A |= (1 << WGM01); // CTC mode
  TCCR0B |= (1 << CS02) | (1 << CS00); // Prescaler 1024
  OCR0A = 125; // For 1ms interrupt frequency
  TIMSK0 |= (1 << OCIE0A); // Enable timer interrupt
}
int thr1 = 0, thr2 = 0;
ISR(TIMER0_COMPA_vect) {
  thr1 ++;
  thr2++;

  if (thr1 == 100)
  {
    // Update pin 11 state
    if (pin11_enabled)
      PORTD |= PD_5;
    else
      PORTD &= ~PD_5;

    thr1 = 0;
  }

  if (thr2 == 1000)
  {
    // Update pin 12 state
    if (pin12_enabled)
      PORTD |= PD_6;
    else
      PORTD &= ~PD_6;
    thr2 = 0;
  }
}

// AVR assembly delay routine for 10 microseconds
void delay_10us() {
  // With a 16MHz clock, each cycle is 1/16us, so we need 10*16 = 160 cycles for 10us
  asm volatile (
    "    ldi r18, 160" "\n"
    "1:  dec r18" "\n"
    "    brne 1b" "\n"
  );
}

// AVR assembly delay routine for microseconds
void delay_us(uint16_t microseconds) {
  uint16_t cycles = (microseconds * F_CPU) / 1000000UL;
  asm volatile (
    "1:  dec %0" "\n"
    "    brne 1b" "\n"
    : "+r" (cycles)
  );
}

int main() {
  DDRD |= PD_5 | PD_6; // Set pins as outputs
  USART_Init();
  Timer0_Init();

  sei(); // Enable global interrupts

  while (1) {
    // Main loop, interrupt-driven
  }

  return 0;
}
