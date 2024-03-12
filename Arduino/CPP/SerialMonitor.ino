void ResetBuffer() {
  memset(tempData, 0, bufferSize);
  counterBuffer = 0;
}

void MonitoringSerialData() {
  if (IsRunning) RunRoutine();
  
  while (Serial.available() > 0) {
    int readedBytes = Serial.readBytesUntil(INSTRUCTION_END, tempData, bufferSize);
    int arraySize = 0;
    for (int i = 0; i < readedBytes; i++)
    {
      if (tempData[i] != newLine && tempData[i] != 0x00) arraySize++;
    }

    if (arraySize > 0)
    { if (arraySize == 1)  HandleControlData();
      else {
        
        if (IsReading) ParseInstruction();
      }
    }
    ResetBuffer();
  }  
}

void HandleControlData() {
  char target = tempData[0];

  if (target == CONTROL_RESET_BOARD)  //D>
  {
    Serial.end();
    asm ("jmp (0x0000)");
  }

  if (target == CONTROL_RESET_INSTRUCTION)  //R>
  {
    ResetBuffer();
    pulseCounter = 0;

    InterpulseLengths[numOfPulses] = { NULL };
    Currents[numOfPulses] = { NULL };
    Polarities[numOfPulses] = { NULL };
    PulseLengths[numOfPulses] = { NULL };

    HasInstruction = false;
    Serial.println("Reseted");
  }

  if (target == CONTROL_START_ROUTINE)  //J>
  {
    Serial.println("Start Routine");
    if (!IsReading && HasInstruction)
    {
      SetPotentiometerValue(Currents[0]);
      IsRunning = true;
      Serial.println("Routine Enabled");
    }
  }

  if (target == CONTROL_STOP_ROUTINE)  //K>
  {
    Serial.println("Stop Routine");
    if (IsRunning && !IsReading && HasInstruction)
    {
      IsRunning = false;
      Serial.println("Routine Disabled");
    }
  }

  if (target == CONTROL_READ_INSTRUCTIONS)  //L>
  { Serial.println("Start Read Instructions");
    if (!IsRunning && !HasInstruction) {
      IsReading = true;
      Serial.println("Read Routine Enabled");
    }
  }

  if (target == CONTROL_STOP_READ_INSTRUCTIONS)  //M>
  {
    Serial.println("Stop Read Instructions");
    if (!IsRunning && IsReading && !HasInstruction) {
      IsReading = false;
      HasInstruction = true;
      Serial.println("Read Routine Disabled");
      Serial.print("Saved data: "); Serial.println(pulseCounter);
    }
  }
}
