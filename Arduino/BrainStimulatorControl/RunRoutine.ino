void RunRoutine() {
  Serial.println("Running");
  for (int i = 0; i < pulseCounter; i++)
  {
    Serial.print("Loop: "); Serial.println(i);
    SetCurrentBasedOnNominalCurrent(Currents[i]);

    if (Polarities[i] == 1) {
      Serial.println("Pin11 High");
      digitalWrite(CLOCK_1_PIN, HIGH);
    }
    else {
      Serial.println("Pin12 High");
      digitalWrite(CLOCK_2_PIN, HIGH);
    }
    Wait(PulseLengths[i],  PulseLengthsMeasure[i]); //pulse length

digitalWrite(CLOCK_1_PIN, LOW);
digitalWrite(CLOCK_2_PIN, LOW);
    Wait(InterpulseLengths[i],  InterpulseLengthsMeasure[i]); //pulse length
  }
}

void SetCurrentBasedOnNominalCurrent(int nominalCurrentValue)
{
  Serial.print("Current:"); Serial.println(nominalCurrentValue);
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
  Serial.print("Wait:"); Serial.print(time); Serial.print(" "); Serial.println(timeUnity);

  int integral;
  double temp;
  double fractional;
  fractional = modf(time, &temp);
  fractional *= 1000;
  integral = (int) temp;
  Serial.print("fractional:"); Serial.println(fractional);
  Serial.print("integral:"); Serial.println(integral);

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
