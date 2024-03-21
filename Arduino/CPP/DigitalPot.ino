
void SetPotentiometerValue(int value) {
  int dir;
  int amount;

  if (Digipot_CurrentValue > value) {
    amount = Digipot_CurrentValue - value;
    dir = 0;
  }
  if (Digipot_CurrentValue < value) {
    amount = value - Digipot_CurrentValue;
    dir = 1;
  }

  if (amount > DIGIPOT_MAX_AMOUNT) amount = DIGIPOT_MAX_AMOUNT;
  if (amount < 0) amount = 0;

  if (dir == 1) setUd_On();//digitalWrite(DIGIPOT_UD_PIN, HIGH);
  else setUd_Off();
  
  setInc_On();
  setCs_Off();

  for (int i = 0; i < amount; i++) {
    setInc_On();
    delayMicroseconds(2);
    setInc_Off();
    delayMicroseconds(2);

    if (Digipot_CurrentValue != DIGIPOT_UNKNOWN) {
      Digipot_CurrentValue += (dir == 1 ? 1 : -1);

      if (Digipot_CurrentValue > DIGIPOT_MAX_AMOUNT) Digipot_CurrentValue = DIGIPOT_MAX_AMOUNT;
      if (Digipot_CurrentValue < 0) Digipot_CurrentValue = 0;
    }
  }

  setCs_On();
}

// =========================================================
void setInc_On(void) {
  PORTD |= (1 << PORTD2);
}
void setInc_Off(void) {
  PORTD &= ~(1 << PORTD2);
}

void setCs_On(void) {
  PORTD |= (1 << PORTD3);
}
void setCs_Off(void) {
  PORTD &= ~(1 << PORTD3);
}

void setUd_On(void) {
  PORTD |= (1 << PORTD3);
}
void setUd_Off(void) {
  PORTD &= ~(1 << PORTD3);
}
