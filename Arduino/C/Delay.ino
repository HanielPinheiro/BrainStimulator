// =========================================================
// --- Delay config ---
void DelayConfig(int timer, int fracTimer, int timeUnity)
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
  IsWaiting = true;
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
