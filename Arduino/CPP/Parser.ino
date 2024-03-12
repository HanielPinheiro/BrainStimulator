void ParseInstruction() {
  char item[6];
  int ctItem = 0;
  int stepper = 0;
  int tempPolarity = 0;
  char *token = strtok(tempData, INSTRUCTION_SEPARATOR); //SET = ignore

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
      
  /*Serial.print("Data: "); Serial.println(data);
  Serial.print("Integer: "); Serial.println(lengths[pulseCounter]);
  Serial.print("Frac: "); Serial.println(fracs[pulseCounter]);
  Serial.print("Measure: "); Serial.println(measures[pulseCounter]);*/
}
void SetCurrentValueToArr(char *nomCurr)
{
  //Serial.print("nomCurr: ");Serial.println(nomCurr);
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
  //Serial.print("Current: ");Serial.println(Currents[pulseCounter]);
}
