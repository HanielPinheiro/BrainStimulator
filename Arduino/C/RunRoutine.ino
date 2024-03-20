void RunRoutine() {
  for (int i = 0; i < pulseCounter; i++)
  {
    if (positiveCycle)
    {

      SetPositive();
      Wait(PulseLengths[globalCounter],  PulseLengthsFractional[globalCounter], PulseLengthsMeasure[globalCounter]);
    }
    else {
      SetNegative();
      Wait(InterpulseLengths[globalCounter],  InterpulseLengthsFractional[globalCounter], InterpulseLengthsMeasure[globalCounter]);
    }
  }
}

void RunCycle() {

  if (runDelayS || runDelayMs || runDelayUs) {
    IsWaiting = true;
  }
  else
  {

    IsWaiting = false;
    if (!positiveCycle)
    {
      globalCounter++;
      if (globalCounter == pulseCounter) {
        globalCounter = 0;
      }
    }

    positiveCycle = !positiveCycle;
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
      controlTimeMs++;
    if (controlTimeMs == targetValueMs) {
      runDelayMs = false;
      controlTimeMs = 0;
    }
  }

  if (runDelayUs)
    controlTimeUs++;
  if (controlTimeUs == targetValueUs) {
    runDelayUs = false;
    controlTimeUs = 0;
  }
}
}
else  RunRoutine();
}
