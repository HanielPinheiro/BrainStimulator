void RunRoutine() {
  for (int i = 0; i < pulseCounter; i++)
  {
    Serial.print(" Loop: "); Serial.print(i);
    SetCurrentBasedOnNominalCurrent(Currents[i]);

    if (Polarities[i] == 1) {
      Serial.print(" Pin11 High ");
      digitalWrite(CLOCK_1_PIN, HIGH);
    }
    else {
      Serial.print(" Pin12 High ");
      digitalWrite(CLOCK_2_PIN, HIGH);
    }
    Wait(PulseLengths[i],  PulseLengthsMeasure[i]);

    digitalWrite(CLOCK_1_PIN, LOW);
    digitalWrite(CLOCK_2_PIN, LOW);
    Wait(InterpulseLengths[i],  InterpulseLengthsMeasure[i]);
    Serial.println("");
  }
}

void SetCurrentBasedOnNominalCurrent(int nominalCurrentValue)
{
  Serial.print(" Current: "); Serial.print(nominalCurrentValue);
  switch (nominalCurrentValue)
  {
    case NOMINAL_650:
      SetPotentiometerValue(CURRENT_650);
      break;
    case NOMINAL_600:
      SetPotentiometerValue(CURRENT_600);
      break;
    case NOMINAL_550:
      SetPotentiometerValue(CURRENT_550);
      break;
    case NOMINAL_500:
      SetPotentiometerValue(CURRENT_500);
      break;
    case NOMINAL_450:
      SetPotentiometerValue(CURRENT_450);
      break;
    case NOMINAL_400:
      SetPotentiometerValue(CURRENT_400);
      break;
    case NOMINAL_350:
      SetPotentiometerValue(CURRENT_350);
      break;
    case NOMINAL_300:
      SetPotentiometerValue(CURRENT_300);
      break;
    case NOMINAL_250:
      SetPotentiometerValue(CURRENT_250);
      break;
    case NOMINAL_200:
      SetPotentiometerValue(CURRENT_200);
      break;
    case NOMINAL_150:
      SetPotentiometerValue(CURRENT_150);
      break;
    case NOMINAL_100:
      SetPotentiometerValue(CURRENT_100);
      break;
    case NOMINAL_50:
      SetPotentiometerValue(CURRENT_50);
      break;
  }
}

void Wait(double time, int timeUnity)
{
  Serial.print(" Wait: "); Serial.print(time); Serial.print(" "); Serial.print(timeUnity);

  int integral;
  double temp;
  double fractional;
  fractional = modf(time, &temp);
  fractional *= 1000;
  integral = (int) temp;

  if (timeUnity == INSTRUCTION_UNITY_US)
    delayMicroseconds(integral);
  else if (timeUnity == INSTRUCTION_UNITY_MS)
  {
    delay(integral);
    delayMicroseconds(fractional);
  }
  else if (timeUnity == INSTRUCTION_UNITY_S)
  {
    for (int i = 0; i < integral; i++)
      delay(1000);

    delay(fractional);
  }
  else Serial.println("ERROR: Problem in wait function");
}
