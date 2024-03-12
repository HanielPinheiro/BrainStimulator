//=================================================
void setDigitalPorts(void)
{
  DDRB  |=  (1 << PORTB0) | (1 << PORTB3) | (1 << PORTB4) | (1 << PORTB5); //configura (Pd8, pd11, pd12, 13) como saída
  PORTB &=  ~(1 << PORTB0) |  ~(1 << PORTB3) | ~(1 << PORTB4) | ~(1 << PORTB5);   //inicializa em LOW

  DDRD  |=  (1 << PORTD4) | (1 << PORTD3) | (1 << PORTD2);        //configura (PD4, pd3, pd2) como saída
  PORTD &=  ~(1 << PORTD4) |  ~(1 << PORTD3) | ~(1 << PORTD2);    //inicializa em LOW
}
//#define DIGIPOT_INC_PIN 2
//#define DIGIPOT_UD_PIN 3
//#define DIGIPOT_CS_PIN 4
void setPD13_On(void) {
  PORTB |= (1 << PORTB5);
}
void setPD13_Off(void) {
  PORTB &= ~(1 << PORTB5);
}

void setPD12_On(void) {
  PORTB |= (1 << PORTB4);
}
void setPD12_Off(void) {
  PORTB &= ~(1 << PORTB4);
}

void setPD11_On(void) {
  PORTB |= (1 << PORTB3);
}
void setPD11_Off(void) {
  PORTB &= ~(1 << PORTB3);
}

void setInc_On(void) {
  PORTD |= (1 << PORTD2);
}
void setInc_Off(void) {
  PORTD &= ~(1 << PORTD2);
}

void setCs_On(void) {
  PORTD |= (1 << PORTD3);
}
void setCs_Off(void) {
  PORTD &= ~(1 << PORTD3);
}

void setUd_On(void) {
  PORTD |= (1 << PORTD3);
}
void setUd_Off(void) {
  PORTD &= ~(1 << PORTD3);
}


//=================================================
void setInterruptions(void)
{
  //menor tempo aprox 4uS
  cli();                             //desliga interrupções
  TCCR0B = 0x00;                     //timer 0 desligado
  TCNT0 = valorTimer0;                      //inicia timer0
  TCCR0B = 0x01;                     //prescaler 1
  TIMSK0 = 0x01;                     //habilita interrupção do Timer0
  sei();                             //liga interrupções
}


//=================================================
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

void USART_Receive(void)
{
  /* Wait for data to be received */
  while (!(UCSR0A & (1 << RXC0)));

  /* Get and return received data from buffer */
  if (UDR0 != newLine)
  {
    tempData[counterBuffer] = UDR0;
    counterBuffer++;
  }
  else PrintDataReceived();
}

void PrintDataReceived()
{
  int arraySize = 0;
  for (int i = 0; i < bufferSize; i++)
  {
    if (tempData[i] != newLine && tempData[i] != 0x00) arraySize++;
    USART_Transmit(tempData[i]);
  }
  USART_Transmit(newLine);

  if (arraySize == 1) ControlWithSerialKeywords();
  else      ParseInstruction();

  ResetBufferUART();
}

void ResetBufferUART()
{
  counterBuffer = 0;
  UDR0 = 0x00;
  memset(tempData, 0, bufferSize);
}

void USART_Transmit(unsigned char data)
{
  /* Wait for empty transmit buffer */
  while (!(UCSR0A & (1 << UDRE0))) ;
  /* Put data into buffer, sends the data */
  UDR0 = data;
}

// =========================================================
// --- Print const messages ---

void printArr(char* arr, int siz) {
  for (unsigned int i = 0; i < siz; i++)
    USART_Transmit(arr[i]);
}

// =========================================================
// --- Print const messages ---

void printStartUART() {
  const char message[] = "Stimulator is ready!\n";
  for (unsigned int i = 0; i < sizeof(message); i++)
    USART_Transmit(message[i]);
}

void printReseted() {
  const char message[] = "Reseted\n";
  for (unsigned int i = 0; i < sizeof(message); i++)
    USART_Transmit(message[i]);
}

// =========================================================
// --- Routine ---
void printTryStartRoutine() {
  const char message[] = "Try to start Routine\n";
  for (unsigned int i = 0; i < sizeof(message); i++)
    USART_Transmit(message[i]);
}

void printRoutineOn() {
  const char message[] = "Routine Enabled\n";
  for (unsigned int i = 0; i < sizeof(message); i++)
    USART_Transmit(message[i]);
}

void printTryStopRoutine() {
  const char message[] = "Try to stop Routine\n";
  for (unsigned int i = 0; i < sizeof(message); i++)
    USART_Transmit(message[i]);
}

void printRoutineOff() {
  const char message[] = "Routine Disabled\n";
  for (unsigned int i = 0; i < sizeof(message); i++)
    USART_Transmit(message[i]);
}
// =========================================================
// --- Instructions ---
void printTryStartRead() {
  const char message[] = "Try to start Read\n";
  for (unsigned int i = 0; i < sizeof(message); i++)
    USART_Transmit(message[i]);
}

void printReadOn() {
  const char message[] = "Reading Enabled\n";
  for (unsigned int i = 0; i < sizeof(message); i++)
    USART_Transmit(message[i]);
}

void printTryStopRead() {
  const char message[] = "Try to stop Read\n";
  for (unsigned int i = 0; i < sizeof(message); i++)
    USART_Transmit(message[i]);
}

void printReadOff() {
  const char message[] = "Reading Disabled\n";
  for (unsigned int i = 0; i < sizeof(message); i++)
    USART_Transmit(message[i]);

  const char mess[] = "Saved data: ";
  for (unsigned int i = 0; i < sizeof(mess); i++)
    USART_Transmit(mess[i]);
  USART_Transmit(pulseCounter);
  USART_Transmit(newLine);
}
