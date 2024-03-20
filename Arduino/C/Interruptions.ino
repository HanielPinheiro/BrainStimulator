//=================================================
void setInterruptions(void)
{
  //menor tempo aprox 4uS
  cli();                             //desliga interrupções
  TCCR0B = 0x00;                     //timer 0 desligado
  TCNT0 = valorTimer0;               //inicia timer0
  TCCR0B = 0x01;                     //prescaler 1
  TIMSK0 = 0x01;                     //habilita interrupção do Timer0
  sei();                             //liga interrupções
}

// =========================================================
// --- Interrupção --- SET$150$+$200U$999.8M> SET$350$-$100M$100U>
ISR(TIMER0_OVF_vect)
{
  TCNT0 = valorTimer0; //reinicializa Timer0

  if (IsRunning)
  {
    if (IsWaiting)
      DelayControl();

    else {
      if (step1)
      {
        if (Polarities[globalCounter] == 1) SetPositive(); else SetNegative();
        DelayConfig(PulseLengths[globalCounter],  PulseLengthsFractional[globalCounter], PulseLengthsMeasure[globalCounter]);
      }
      else
      {
        SetZero(); //Interpulse don't have current
        DelayConfig(InterpulseLengths[globalCounter],  InterpulseLengthsFractional[globalCounter], InterpulseLengthsMeasure[globalCounter]);
      }
      step1 = !step1;
    }
  }
}
