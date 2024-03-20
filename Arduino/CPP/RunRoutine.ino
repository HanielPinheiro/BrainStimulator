void RunRoutine() {
  for (int i = 0; i < pulseCounter; i++)
  {
    //SetPotentiometerValue(Currents[i]);
    //Serial.print("Current");Serial.println(Currents[i]);
    
    //Serial.print("Polarities");Serial.println(Polarities[i]);
    if (Polarities[i] == 1) 
    {
      digitalWrite(CLOCK_1_PIN, LOW);   
      digitalWrite(CLOCK_2_PIN, LOW);   
    }
    else 
    {
      digitalWrite(CLOCK_1_PIN, HIGH);   
      digitalWrite(CLOCK_2_PIN, HIGH);  
    }
    
    /*Serial.print("Wait int: ");Serial.println(PulseLengths[i]);
    Serial.print("Wait frac: ");Serial.println(PulseLengthsFractional[i]);
    Serial.print("Wait meas: ");Serial.println(PulseLengthsMeasure[i]);    */
    Wait(PulseLengths[i],  PulseLengthsFractional[i], PulseLengthsMeasure[i]);
    
    /*Serial.print("Wait int: ");Serial.println(InterpulseLengths[i]);
    Serial.print("Wait frac: ");Serial.println(InterpulseLengthsFractional[i]);
    Serial.print("Wait meas: ");Serial.println(InterpulseLengthsMeasure[i]);    */
    digitalWrite(CLOCK_1_PIN, LOW); digitalWrite(CLOCK_2_PIN, HIGH);
    Wait(InterpulseLengths[i],  InterpulseLengthsFractional[i], InterpulseLengthsMeasure[i]);
  }
}

// =========================================================
// --- Delay control ---
void Wait(int timer, int fracTimer, int timeUnity)
{
  if (timeUnity == INSTRUCTION_UNITY_US)
  {
    delayMicroseconds(timer);
    //(timer);
  }
  else if (timeUnity == INSTRUCTION_UNITY_MS)
  {
    delay(timer);
    if (fracTimer > 0) delay_us();
  }
  else if (timeUnity == INSTRUCTION_UNITY_S)
  {
    for(int i=0;i<timer; i++) delay(1000);
    if (fracTimer > 0) delay(fracTimer);
  }
}
