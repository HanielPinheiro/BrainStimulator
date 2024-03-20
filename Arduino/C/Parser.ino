void ParseInstruction() {
  char item[6];
  int ctItem = 0;
  int stepper = 0;
  int tempPolarity = 0;
  float timeConverted;

  for (int i = 0; i < sizeof(tempData); i++)
  {
    if (tempData[i] != INSTRUCTION_SEPARATOR) {
      item[ctItem] = tempData[i];
      ctItem++;
    }
    else {

      if (stepper == 1)
        SetCurrentValueToArr(item);

      else if (stepper == 2) {

        if (strcmp(item, INSTRUCTION_POLARITY_P))tempPolarity = 1;
        else tempPolarity = 0;
        Polarities[pulseCounter] = tempPolarity;

      }
      else if (stepper == 3) {
        GetTimeFromInstruction(item, ctItem, PulseLengths, PulseLengthsFractional, PulseLengthsMeasure);
      }

      //USART_Transmit(newLine);
      //printArr(item, ctItem);

      ctItem = 0;
      stepper++;
    }
  }
  //USART_Transmit(newLine);
  //printArr(item, ctItem);

  //Step 4
  GetTimeFromInstruction(item, ctItem, InterpulseLengths, PulseLengthsFractional, InterpulseLengthsMeasure);
  pulseCounter++;
}

void GetTimeFromInstruction(char *data, int siz, int* lengths, int* fracs, int* measures)
{
  char parser[siz];
  int ctParse = 0;

  int measureUnity = 0;
  int integer = 0;
  int fractional = 0;

  for (int i = 0; i < siz; i++) {
    if (data[i] == INSTRUCTION_DECIMAL) {
      // printArr(parser, ctParse);
      //USART_Transmit(newLine);
      ctParse = 0;
      integer = atoi(parser);
      //if(integer == 885)printRoutineOn();
      memset(parser, 0, siz);
    }
    else if (data[i] == INSTRUCTION_UNITY_MS || data[i] == INSTRUCTION_UNITY_US || data[i] == INSTRUCTION_UNITY_S) {
      //printArr(parser, ctParse);
      //USART_Transmit(newLine);
      fractional = atoi(parser);
      //if(fractional == 9)printTryStartRoutine();
      measureUnity = data[i];
      break;
    }
    else {
      parser[ctParse] = data[i];
      ctParse++;
    }
  }

  lengths[pulseCounter] = integer;
  fracs[pulseCounter] = fractional;
  measures[pulseCounter] = measureUnity;
}

void SetCurrentValueToArr(char *nomCurr)
{
  if (strcmp(nomCurr, NOMINAL_50)) Currents[pulseCounter] = CURRENT_50;
  else if   (strcmp(nomCurr, NOMINAL_100))Currents[pulseCounter] = CURRENT_100;
  else if   (strcmp(nomCurr, NOMINAL_150))Currents[pulseCounter] = CURRENT_150;
  else if   (strcmp(nomCurr, NOMINAL_200))Currents[pulseCounter] = CURRENT_200;
  else if   (strcmp(nomCurr, NOMINAL_250))Currents[pulseCounter] = CURRENT_250;
  else if   (strcmp(nomCurr, NOMINAL_300))Currents[pulseCounter] = CURRENT_300;
  else if   (strcmp(nomCurr, NOMINAL_350))Currents[pulseCounter] = CURRENT_350;
  else if   (strcmp(nomCurr, NOMINAL_400))Currents[pulseCounter] = CURRENT_400;
  else if   (strcmp(nomCurr, NOMINAL_450))Currents[pulseCounter] = CURRENT_450;
  else if   (strcmp(nomCurr, NOMINAL_500))Currents[pulseCounter] = CURRENT_500;
  else if   (strcmp(nomCurr, NOMINAL_600))Currents[pulseCounter] = CURRENT_550;
  else if   (strcmp(nomCurr, NOMINAL_650))Currents[pulseCounter] = CURRENT_650;
}
