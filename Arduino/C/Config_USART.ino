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

void printArr(char* arr, int siz) {
  for (unsigned int i = 0; i < siz; i++)
    USART_Transmit(arr[i]);
}

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
