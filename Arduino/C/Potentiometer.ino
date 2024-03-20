void Change(int dir, int amount) {
  if (amount > DIGIPOT_MAX_AMOUNT) amount = DIGIPOT_MAX_AMOUNT;
  if (amount < 0) amount = 0;

  if (dir == 1) setUd_On; else setUd_Off;
  setInc_On;
  setCs_Off;

  for (int i = 0; i < amount; i++) {
    setInc_Off;
    
    setInc_On;

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
