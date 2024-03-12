void RunRoutine() {
  // for (int i = 0; i < pulseCounter; i++)
  //{
  USART_Transmit('a');
  if (positiveCycle)
  {
    USART_Transmit('b');
    SetPotentiometerValue(Currents[globalCounter]);
USART_Transmit('c');
    if (Polarities[globalCounter] == 1) setPD11_On();   else setPD12_On();
USART_Transmit('d');
    Wait(PulseLengths[globalCounter],  PulseLengthsFractional[globalCounter], PulseLengthsMeasure[globalCounter]);
    USART_Transmit('e');
  }
  else {
    USART_Transmit('f');
    setPD11_Off(); setPD12_Off();
USART_Transmit('g');
    Wait(InterpulseLengths[globalCounter],  InterpulseLengthsFractional[globalCounter], InterpulseLengthsMeasure[globalCounter]);
  }
  USART_Transmit('h');
  //}
}

void RunCycle() {

  if (runDelayS || runDelayMs || runDelayUs) {IsWaiting = true; USART_Transmit('i');}
  else
  {
    USART_Transmit('j');
    IsWaiting = false;
    if (!positiveCycle)
    {
      USART_Transmit('k');
      globalCounter++;
      if (globalCounter == pulseCounter) {globalCounter = 0;USART_Transmit('l');}
    }
USART_Transmit('m');
    positiveCycle = !positiveCycle;
  }

  if (IsWaiting) {
    USART_Transmit('n');
    if (runDelayS)
    {
      USART_Transmit('o');
      controlTimeS++;
      if (controlTimeS == targetValueS) {
        USART_Transmit('p');
        runDelayS = false;
        controlTimeS = 0;
      }
    }

    if (runDelayMs)
    {USART_Transmit('q');
      controlTimeMs++;
      if (controlTimeMs == targetValueMs) {
        USART_Transmit('r');
        runDelayMs = false;
        controlTimeMs = 0;
      }
    }

    if (runDelayUs)
    {USART_Transmit('s');
      controlTimeUs++;
      if (controlTimeUs == targetValueUs) {
        USART_Transmit('t');
        runDelayUs = false;
        controlTimeUs = 0;
      }
    }
    USART_Transmit('u');
  }
  else  RunRoutine();
  USART_Transmit('v');
}

// =========================================================
// --- Delay control ---
void Wait(int timer, int fracTimer, int timeUnity)
{
  if (timeUnity == INSTRUCTION_UNITY_US)
  {
    SetDelayUs(timer);
  }
  else if (timeUnity == INSTRUCTION_UNITY_MS)
  {
    SetDelayMs(timer);
    if (fracTimer > 0) SetDelayUs(fracTimer);
  }
  else if (timeUnity == INSTRUCTION_UNITY_S)
  {
    SetDelayS(timer);
    if (fracTimer > 0) SetDelayMs(fracTimer);
  }
}

void SetDelayS(int timer) {
  runDelayS = true;
  controlTimeS = 0;
  targetValueS = timer;
}

void SetDelayMs(int timer) {
  runDelayMs = true;
  controlTimeMs = 0;
  targetValueMs = timer;
}

void SetDelayUs(int timer) {
  runDelayUs = true;
  controlTimeUs = 0;
  targetValueUs = timer;
}

// =========================================================
// --- Potentiometer ---
void Change(int dir, int amount) {
  if (amount > DIGIPOT_MAX_AMOUNT) amount = DIGIPOT_MAX_AMOUNT;
  if (amount < 0) amount = 0;

  if (dir == 1) setUd_On; else setUd_Off;
  setInc_On;
  setCs_Off;

  for (int i = 0; i < amount; i++) {
    setInc_Off;
    Wait(2, 0, INSTRUCTION_UNITY_US);

    setInc_On;
    Wait(2, 0, INSTRUCTION_UNITY_US);

    if (Digipot_CurrentValue != DIGIPOT_UNKNOWN) {
      Digipot_CurrentValue += (dir == 1 ? 1 : -1);

      if (Digipot_CurrentValue > DIGIPOT_MAX_AMOUNT) Digipot_CurrentValue = DIGIPOT_MAX_AMOUNT;
      if (Digipot_CurrentValue < 0) Digipot_CurrentValue = 0;
    }
  }

  setCs_On;
}

void SetPotentiometerValue(int value) {
  if (Digipot_CurrentValue > value)
    Change(0, Digipot_CurrentValue - value);

  if (Digipot_CurrentValue < value)
    Change(1, value - Digipot_CurrentValue);
}
