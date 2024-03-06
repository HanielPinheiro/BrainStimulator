void ReceivingInstruction() {
  Serial.println("Reading");
  while (Serial.available() > 0) {

    int readedBytes = Serial.readBytesUntil(INSTRUCTION_END, tempData, buffer);
    if (readedBytes == 0) Serial.write("ERROR WHEN TRY TO READ BYTES");
    else if (readedBytes < 5) {
      HandleControlData();
    }
    else {
      char* strtokIndx = strtok(tempData, INSTRUCTION_SEPARATOR);
      if (strcmp(strtokIndx, "SET") == 0)
      {
        // get the first part - the current  ==================================
        strtokIndx = strtok(NULL, INSTRUCTION_SEPARATOR);
        int tempCurrent = atoi(strtokIndx);
        Currents[pulseCounter] = tempCurrent;

        // get the second part - the polarity ==================================
        char polarity[1];
        int tempPolarity = 0;
        strtokIndx = strtok(NULL, INSTRUCTION_SEPARATOR);
        strcpy(polarity, strtokIndx);
        if (polarity[0] == INSTRUCTION_POLARITY_P) tempPolarity = 1;
        if (polarity[0] == INSTRUCTION_POLARITY_N) tempPolarity = -1;
        Polarities[pulseCounter] = tempPolarity;

        // get the third part - the pulse length  ==================================
        strtokIndx = strtok(NULL, INSTRUCTION_SEPARATOR);
        float timeConverted = GetTimeFromInstruction(strtokIndx);
        PulseLengths[pulseCounter] = timeConverted;
        PulseLengthsMeasure[pulseCounter] = measureUnity;

        // get the fourth part - the interpulse length  ==================================
        strtokIndx = strtok(NULL, INSTRUCTION_SEPARATOR);
        timeConverted = GetTimeFromInstruction(strtokIndx);
        InterpulseLengths[pulseCounter] = timeConverted;
        InterpulseLengthsMeasure[pulseCounter] = measureUnity;

        Serial.print(pulseCounter); Serial.print(": ");
        Serial.print(Currents[pulseCounter]); Serial.print(" - ");
        Serial.print(Polarities[pulseCounter]); Serial.print(" - ");
        Serial.print(PulseLengths[pulseCounter]); Serial.print(" - ");
        Serial.print(PulseLengthsMeasure[pulseCounter]); Serial.print(" - ");
        Serial.print(InterpulseLengths[pulseCounter]); Serial.print(" - ");
        Serial.println(InterpulseLengthsMeasure[pulseCounter]);

        pulseCounter++;
      }
    }
    ResetBuffer();
  }
}

float GetTimeFromInstruction(char *strtokIndx)
{
  measureUnity = 0;
  char timeWithoutUnity[15];
  strcpy(timeWithoutUnity, strtokIndx);
  float timeC = 0.0;
  for (int i = 0; i < sizeof(timeWithoutUnity); i++) {
    if (strtokIndx[i] == INSTRUCTION_UNITY_MS || strtokIndx[i] == INSTRUCTION_UNITY_US || strtokIndx[i] == INSTRUCTION_UNITY_S) {
      timeC = atof(timeWithoutUnity);
      measureUnity = strtokIndx[i];
      break;
    }
    else {
      timeWithoutUnity[i] = strtokIndx[i];
    }
  }
  return timeC;
}
