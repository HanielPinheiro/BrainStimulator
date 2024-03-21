void ParseCommands(char target) {
  
  if (target == CONTROL_RESET_BOARD)  //D>
  {    
    Serial.end();
    asm ("jmp (0x0000)");
  }

  if (target == CONTROL_RESET_INSTRUCTION)  //R>
  {
    Serial_ResetBuffer();
  
    pulseCounter = 0;

    InterpulseLengths[numOfPulses] = { NULL };
    Currents[numOfPulses] = { NULL };
    Polarities[numOfPulses] = { NULL };
    PulseLengths[numOfPulses] = { NULL };

    HasInstruction = false;
    IsReading = false;
    IsRunning = false;

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
// =========================================================
void ParseInstruction(char* data) {
  char item[6];
  int ctItem = 0;
  int stepper = 0;
  int tempPolarity = 0;
  char *token = strtok(data, INSTRUCTION_SEPARATOR); //SET = ignore

  token = strtok(NULL, INSTRUCTION_SEPARATOR);
  SetCurrentValueToArr(token);

  token = strtok(NULL, INSTRUCTION_SEPARATOR);
  if (strcmp(token, INSTRUCTION_POLARITY_P) == 0)tempPolarity = 1; else tempPolarity = 0;
  Polarities[pulseCounter] = tempPolarity;

  token = strtok(NULL, INSTRUCTION_SEPARATOR);
  GetTimeFromInstruction(token, strlen(token), PulseLengths, PulseLengthsFractional, PulseLengthsMeasure);

  token = strtok(NULL, INSTRUCTION_SEPARATOR);
  GetTimeFromInstruction(token, strlen(token), InterpulseLengths, InterpulseLengthsFractional, InterpulseLengthsMeasure);

  pulseCounter++;
  Serial.println("Parsed");
}
// =========================================================
void GetTimeFromInstruction(char *data, int siz, int* lengths, int* fracs, int* measures)
{
  double intPart;
  double fractPart = modf(atof(data), &intPart);
  fractPart *=1000;
  
  int measureUnity = 0;

  for (int i = 0; i < siz; i++){
    if (data[i] == INSTRUCTION_UNITY_MS || data[i] == INSTRUCTION_UNITY_US || data[i] == INSTRUCTION_UNITY_S)     
      measureUnity = data[i];   
  }
  
    lengths[pulseCounter] = (int)intPart;
    fracs[pulseCounter] = (int)fractPart;
    measures[pulseCounter] = measureUnity;
      
  Serial.print("Data: "); Serial.println(data);
  Serial.print("Integer: "); Serial.println(lengths[pulseCounter]);
  Serial.print("Frac: "); Serial.println(fracs[pulseCounter]);
  Serial.print("Measure: "); Serial.println(measures[pulseCounter]);
}
// =========================================================
void SetCurrentValueToArr(char *nomCurr)
{
  Serial.print("nomCurr: ");Serial.println(nomCurr);
  if (strcmp(nomCurr, NOMINAL_50) == 0) Currents[pulseCounter] = CURRENT_50;
  else if   (strcmp(nomCurr, NOMINAL_100) == 0)Currents[pulseCounter] = CURRENT_100;
  else if   (strcmp(nomCurr, NOMINAL_150) == 0)Currents[pulseCounter] = CURRENT_150;
  else if   (strcmp(nomCurr, NOMINAL_200) == 0)Currents[pulseCounter] = CURRENT_200;
  else if   (strcmp(nomCurr, NOMINAL_250) == 0)Currents[pulseCounter] = CURRENT_250;
  else if   (strcmp(nomCurr, NOMINAL_300) == 0)Currents[pulseCounter] = CURRENT_300;
  else if   (strcmp(nomCurr, NOMINAL_350) == 0)Currents[pulseCounter] = CURRENT_350;
  else if   (strcmp(nomCurr, NOMINAL_400) == 0)Currents[pulseCounter] = CURRENT_400;
  else if   (strcmp(nomCurr, NOMINAL_450) == 0)Currents[pulseCounter] = CURRENT_450;
  else if   (strcmp(nomCurr, NOMINAL_500) == 0)Currents[pulseCounter] = CURRENT_500;
  else if   (strcmp(nomCurr, NOMINAL_600) == 0)Currents[pulseCounter] = CURRENT_550;
  else if   (strcmp(nomCurr, NOMINAL_650) == 0)Currents[pulseCounter] = CURRENT_650;
  Serial.print("Current: ");Serial.println(Currents[pulseCounter]);
}
