
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

  if (dir == 1)      setUd_On();//digitalWrite(DIGIPOT_UD_PIN, HIGH);
  else     setUd_Off();//digitalWrite(DIGIPOT_UD_PIN, LOW);
  setInc_On();//digitalWrite(DIGIPOT_INC_PIN, HIGH);
  setCs_Off();//digitalWrite(DIGIPOT_CS_PIN, LOW);

  for (int i = 0; i < amount; i++) {
    setInc_On();//digitalWrite(DIGIPOT_INC_PIN, LOW);
    delay_us();
    setInc_Off();//digitalWrite(DIGIPOT_INC_PIN, HIGH);
    delay_us();


    if (Digipot_CurrentValue != DIGIPOT_UNKNOWN) {
      Digipot_CurrentValue += (dir == 1 ? 1 : -1);

      if (Digipot_CurrentValue > DIGIPOT_MAX_AMOUNT) Digipot_CurrentValue = DIGIPOT_MAX_AMOUNT;
      if (Digipot_CurrentValue < 0) Digipot_CurrentValue = 0;
    }
  }

  setCs_On();// digitalWrite(DIGIPOT_CS_PIN, HIGH);


}

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
