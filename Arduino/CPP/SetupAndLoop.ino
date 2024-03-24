
void setup() {
  Digipot_CurrentValue = DIGIPOT_UNKNOWN;
  pinMode(DIGIPOT_INC_PIN, OUTPUT);
  pinMode(DIGIPOT_UD_PIN, OUTPUT);
  pinMode(DIGIPOT_CS_PIN, OUTPUT);
  digitalWrite(DIGIPOT_CS_PIN, HIGH);

  pinMode(ON_OFF_PIN, OUTPUT);
  digitalWrite(ON_OFF_PIN, HIGH);
  pinMode(CLOCK_1_PIN, OUTPUT);
  pinMode(CLOCK_2_PIN, OUTPUT);

  Serial.begin(115200);
  Serial.println("Stimulator is ready");
}

unsigned long int timeMicros = 0;
unsigned long int timeMilis = 0;
unsigned long int timeSeconds = 0;

void loop()
{
  //SET$150$+$200U$999.8M> //Continuar testes
  //SET$450$-$200.8M$1.2S>
  if (IsRunning) {
    RunRoutine();
    //Serial.println(micros());
  }
  if (millis() - timeMilis >= 50)
  {
    timeMilis = millis();

    if (Serial.available()) {
      int readedBytes = Serial.readBytesUntil(INSTRUCTION_END, tempData, bufferSize);

      int arraySize = 0;
      for (int i = 0; i < readedBytes; i++)
        if (tempData[i] != newLine && tempData[i] != 0x00)
          arraySize++;

      if (arraySize > 0)
      {
        if (arraySize == 1)  ParseCommands(tempData[0]);
        else if (IsReading) ParseInstruction(tempData);
      }
    }
    Serial_ResetBuffer();

    //  while (Serial.available() > 0) {
    //    int readedBytes = Serial.readBytesUntil(INSTRUCTION_END, tempData, bufferSize);
    //
    //    int arraySize = 0;
    //    for (int i = 0; i < readedBytes; i++)
    //      if (tempData[i] != newLine && tempData[i] != 0x00)
    //        arraySize++;
    //
    //    if (arraySize > 0)
    //    {
    //      if (arraySize == 1)  ParseCommands(tempData[0]);
    //      else if (IsReading) ParseInstruction(tempData);
    //    }
    //  }
    //  Serial_ResetBuffer();
  }
}

// =========================================================
void Serial_ResetBuffer() {
  memset(tempData, 0, bufferSize);
  counterBuffer = 0;
}
