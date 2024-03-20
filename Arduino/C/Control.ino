void ControlWithSerialKeywords() {
  char target = tempData[1];

  // =========================================================
  // --- Reset ---
  if (target == CONTROL_RESET_INSTRUCTION)  //E>
  {
    ResetBufferUART();
    pulseCounter = 0;

    InterpulseLengths[numOfPulses] = { NULL };
    Currents[numOfPulses] = { NULL };
    Polarities[numOfPulses] = { NULL };
    PulseLengths[numOfPulses] = { NULL };

    HasInstruction = false;
    printReseted();
  }

  // =========================================================
  // --- Routine ---
  if (target == CONTROL_START_ROUTINE)  //A>
  {
    printTryStartRoutine();
    if (!IsReading && HasInstruction)
    {
      IsRunning = true;
      printRoutineOn();
      SetPotentiometerValue(Currents[0]);
    }
  }
  if (target == CONTROL_STOP_ROUTINE)  //B>
  {
    printTryStopRoutine();
    if (!IsReading && IsRunning && HasInstruction)
    {
      IsRunning = false;
      printRoutineOff();
    }
  }
  // =========================================================
  // --- Instructions ---
  if (target == CONTROL_READ_INSTRUCTIONS)  //C>
  {
    printTryStartRead();
    if (!IsRunning && !HasInstruction)
    {
      IsReading = true;
      printReadOn();
    }
  }

  if (target == CONTROL_STOP_READ_INSTRUCTIONS)  //D>
  {
    printTryStopRead();
    if (!IsRunning && IsReading && !HasInstruction) {
      IsReading = false;
      HasInstruction = true;
      printReadOff();
    }
  }
}
