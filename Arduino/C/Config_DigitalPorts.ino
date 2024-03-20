void setDigitalPorts(void)
{
  DDRB  |=  (1 << PORTB0) | (1 << PORTB3) | (1 << PORTB4) | (1 << PORTB5); //configura (Pd8, pd11, pd12, 13) como saída
  PORTB &=  ~(1 << PORTB0) |  ~(1 << PORTB3) | ~(1 << PORTB4) | ~(1 << PORTB5);   //inicializa em LOW

  DDRD  |=  (1 << PORTD4) | (1 << PORTD3) | (1 << PORTD2);        //configura (PD4, pd3, pd2) como saída
  PORTD &=  ~(1 << PORTD4) |  ~(1 << PORTD3) | ~(1 << PORTD2);    //inicializa em LOW
}
// =========================================================
void setSerialPorts(void)
{
  //*Set baud rate
  UBRR0H = 0x00;
  UBRR0L = 0x08;
  //Enable receiver and transmitter
  UCSR0B = (1 << RXEN0) | (1 << TXEN0);
  // Set frame format: 8data, 2stop bit */
  UCSR0C = (1 << USBS0) | (3 << UCSZ00);

  printStartUART();
}
// =========================================================
void SetPositive(void)
{
  setPD11_Off();
  setPD12_Off();
}
// =========================================================
void SetNegative(void)
{
  setPD11_On();
  setPD12_On();
}
// =========================================================
void SetZero(void)
{
  setPD11_Off();
  setPD12_On();
}
// =========================================================
void setPD13_On(void) {
  PORTB |= (1 << PORTB5);
}
void setPD13_Off(void) {
  PORTB &= ~(1 << PORTB5);
}
// =========================================================
void setPD12_On(void) {
  PORTB |= (1 << PORTB4);
}
void setPD12_Off(void) {
  PORTB &= ~(1 << PORTB4);
}
// =========================================================
void setPD11_On(void) {
  PORTB |= (1 << PORTB3);
}
void setPD11_Off(void) {
  PORTB &= ~(1 << PORTB3);
}
// =========================================================
void setInc_On(void) {
  PORTD |= (1 << PORTD2);
}
void setInc_Off(void) {
  PORTD &= ~(1 << PORTD2);
}
// =========================================================
void setCs_On(void) {
  PORTD |= (1 << PORTD3);
}
void setCs_Off(void) {
  PORTD &= ~(1 << PORTD3);
}
// =========================================================
void setUd_On(void) {
  PORTD |= (1 << PORTD3);
}
void setUd_Off(void) {
  PORTD &= ~(1 << PORTD3);
}
