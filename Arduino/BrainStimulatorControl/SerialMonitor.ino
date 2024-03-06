void ResetBuffer() {
  memset(tempData, 0, buffer);
  counterBuffer = 0;
  tempData[0] = 0;
}

void MonitoringSerialData() {
  while (Serial.available() > 0) {
    int readedBytes = Serial.readBytesUntil(INSTRUCTION_END, tempData, buffer);

    if (readedBytes == 0) Serial.write("ERROR WHEN TRY TO READ BYTES");
    else if (readedBytes < 5) {
      char temp = 0;
      for (int i = 0; i < sizeof(tempData); i++)
      {
        if (tempData[i] != 10 && tempData[i] != 0)
          temp = tempData[i];
      }

      if (temp != 0) {
        tempData[0] = temp;
        HandleControlData();
      }
    }

    ResetBuffer();
  }
}

void HandleControlData() {
  if (tempData[0] == CONTROL_RESET_BOARD)  //D>
  {
    Serial.end();
    asm ("jmp (0x0000)");
  }

  if (tempData[0] == CONTROL_RESET_INSTRUCTION)  //R>
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

  if (tempData[0] == CONTROL_START_ROUTINE)  //J>
  {
    Serial.println("Start Routine");
    if (!IsReading) {
      if (!HasInstruction) Serial.println("ERROR: Dont have a routine loaded");
      else
      {
        IsRunning = true;
        Serial.println("Routine Enabled");
      }
    } else Serial.println("ERROR: Must stop reading before run routine");
  }

  if (tempData[0] == CONTROL_STOP_ROUTINE)  //K>
  {
    Serial.println("Stop Routine");
    if (!IsReading) {
      if (!HasInstruction) Serial.println("ERROR: Dont have a routine loaded");
      else
      {
        IsRunning = false;
        Serial.println("Routine Disabled");
      }
    } else Serial.println("ERROR: Must stop reading before run routine");
  }

  if (tempData[0] == CONTROL_READ_INSTRUCTIONS)  //L>
  { Serial.println("Start Read Instructions");
    if (!IsRunning) {
      if (HasInstruction) Serial.println("ERROR: Must reset pre-loaded routine first");
      else {
        IsReading = true;
        Serial.println("Read Routine Enabled");
      }
    } else Serial.println("ERROR: Must stop running before send new routine");
  }

  if (tempData[0] == CONTROL_STOP_READ_INSTRUCTIONS)  //M>
  {
    Serial.println("Stop Read Instructions");
    if (!IsRunning) {
      if (IsReading && !HasInstruction) {
        IsReading = false;
        HasInstruction = true;
        Serial.println("Read Routine Disabled");
        Serial.print("Saved data: "); Serial.println(pulseCounter);
      }
    } else Serial.println("ERROR: Must stop running before send new routine");
  }
}
