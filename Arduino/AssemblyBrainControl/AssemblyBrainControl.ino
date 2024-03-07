//------------------------------------------------
// Programming Serial Port - Printing Text Message
//------------------------------------------------
extern "C"
{
  void init_serial();
  void print_msg();

  void defineDigiPotPins();
  void set_current_650();
}
//----------------------------------------------------
void setup()
{
  init_serial();
  defineDigiPotPins();
  set_current_650();
}
//----------------------------------------------------
void loop()
{
  //print_msg();  
}
