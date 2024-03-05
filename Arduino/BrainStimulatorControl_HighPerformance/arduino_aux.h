extern "C"
{
  void InitializeDelayCounterAndSetClockPins(void);

  void Set_Pin8_High(void);
  void Set_Pin8_Low(void);

  void Set_Pin11_High(void);
  void Set_Pin11_Low(void);

  void Set_Pin12_High(void);
  void Set_Pin12_Low(void);

  void Delay_1s(void);
  void Delay_1ms(void);
  void Delay_1us(void);
}
