void DelayControl() {

  if (runDelayS || runDelayMs || runDelayUs)
    IsWaiting = true;
  else
  {
    IsWaiting = false;
    globalCounter++;

    if (globalCounter == pulseCounter)
      globalCounter = 0;
  }

  if (IsWaiting) {
    if (runDelayS)
    {
      controlTimeS++;
      if (controlTimeS == targetValueS) {
        runDelayS = false;
        controlTimeS = 0;
      }
    }

    if (runDelayMs)
    {
      controlTimeMs++;
      if (controlTimeMs == targetValueMs) {
        runDelayMs = false;
        controlTimeMs = 0;
      }
    }

    if (runDelayUs)
    {
      controlTimeUs++;
      if (controlTimeUs == targetValueUs) {
        runDelayUs = false;
        controlTimeUs = 0;
      }
    }
  }

}
