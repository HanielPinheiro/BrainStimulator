void Change(int direction, int amount) {
  amount = constrain(amount, 0, DIGIPOT_MAX_AMOUNT);
  digitalWrite(DIGIPOT_UD_PIN, direction);
  digitalWrite(DIGIPOT_INC_PIN, HIGH);
  digitalWrite(DIGIPOT_CS_PIN, LOW);

  for (int i = 0; i < amount; i++) {
    digitalWrite(DIGIPOT_INC_PIN, LOW);
    delayMicroseconds(2);
    digitalWrite(DIGIPOT_INC_PIN, HIGH);
    delayMicroseconds(2);
    if (Digipot_CurrentValue != DIGIPOT_UNKNOWN) {
      Digipot_CurrentValue += (direction == DIGIPOT_UP ? 1 : -1);
      Digipot_CurrentValue = constrain(Digipot_CurrentValue, 0, DIGIPOT_MAX_AMOUNT);
    }
  }
  digitalWrite(DIGIPOT_CS_PIN, HIGH);
}


void Decrease(int amount) {
  amount = constrain(amount, 0, DIGIPOT_MAX_AMOUNT);
  Change(DIGIPOT_DOWN, amount);
}


void SetPotentiometerValue(int value) {
  value = constrain(value, 0, DIGIPOT_MAX_AMOUNT);

  if (Digipot_CurrentValue == DIGIPOT_UNKNOWN) {
    Decrease(DIGIPOT_MAX_AMOUNT);
    Digipot_CurrentValue = 0;
  }

  if (Digipot_CurrentValue > value)
    Change(DIGIPOT_DOWN, Digipot_CurrentValue - value);

  if (Digipot_CurrentValue < value)
    Change(DIGIPOT_UP, value - Digipot_CurrentValue);
}
