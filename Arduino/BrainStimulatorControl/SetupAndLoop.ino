void setup() {
  Digipot_CurrentValue = DIGIPOT_UNKNOWN;
  pinMode(DIGIPOT_INC_PIN, OUTPUT);
  pinMode(DIGIPOT_UD_PIN, OUTPUT);
  pinMode(DIGIPOT_CS_PIN, OUTPUT);
  digitalWrite(DIGIPOT_CS_PIN, HIGH);

  pinMode(ON_OFF_PIN, OUTPUT);
  digitalWrite(ON_OFF_PIN, HIGH);
  pinMode(CLOCK_1_PIN, OUTPUT);
  pinMode(CLOCK_2_PIN, OUTPUT);

  Serial.begin(115200);
  Serial.println("Stimulator is ready");
}

void loop()
{
  MonitoringSerialData();
  if (IsReading) ReceivingInstruction();
  else if (IsRunning) RunRoutine();
}
