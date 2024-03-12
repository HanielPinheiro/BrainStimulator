#define DIGIPOT_UP   HIGH
#define DIGIPOT_DOWN LOW
#define DIGIPOT_MAX_AMOUNT 99
#define DIGIPOT_UNKNOWN 255

uint8_t _currentValue = 0;
uint8_t _incPin = 2;
uint8_t _udPin = 3;
uint8_t _csPin = 4;



uint8_t _turnOnOffPin = 5;
uint8_t _clock1Pin = 11;
uint8_t _clock2Pin = 12;
uint8_t _ledPin = 13;

void setup() {
  Serial.begin(115200);
  DefineDigitalPins();
  Set(55);

  //delta(vh - vl) = 1k100Ohm
  //58 = 654
  //54 = 596
  //51 = 556  
  //47 = 504
  //43 = 455
  //38 = 395
  //34 = 346
  //30 = 300
  //26 = 250
  //22 = 195
  //19 = 155
  //15 = 100uA
  //11 = 51 uA 
  Serial.println("Stimulator is ready");
}

void loop()
{
Serial.println("Stimulator is ready");
//  digitalWrite(_clock2Pin, DIGIPOT_DOWN);
//  digitalWrite(_clock2Pin, DIGIPOT_UP);
//  delay(3000);
  /*int v = 10;
  while(true)
  {  Set(v);
  v+=10;
  delay(200);
  if(v >= DIGIPOT_MAX_AMOUNT) break;
  }*/
//  for (int i = 0; i < 5; i++)
//  {
//    digitalWrite(_clock1Pin, DIGIPOT_UP);
//    digitalWrite(_ledPin, DIGIPOT_UP);
//    delayMicroseconds(125);
//
//    digitalWrite(_clock1Pin, DIGIPOT_DOWN);
//    digitalWrite(_ledPin, DIGIPOT_DOWN);
//    delayMicroseconds(25);
//  }

  digitalWrite(_clock1Pin, DIGIPOT_UP);
  digitalWrite(_clock2Pin, DIGIPOT_UP);
  digitalWrite(_ledPin, DIGIPOT_UP);
  delay(3000);

  digitalWrite(_clock1Pin, DIGIPOT_DOWN);
  digitalWrite(_clock2Pin, DIGIPOT_DOWN);
  digitalWrite(_ledPin, DIGIPOT_DOWN);
  delay(3000);
}


void DefineDigitalPins() {
  _currentValue = DIGIPOT_UNKNOWN;

  pinMode(_incPin, OUTPUT);
  pinMode(_udPin, OUTPUT);
  pinMode(_csPin, OUTPUT);
  digitalWrite(_csPin, HIGH);

  pinMode(_clock1Pin, OUTPUT);
  pinMode(_clock2Pin, OUTPUT);
  pinMode(_ledPin, OUTPUT);

  pinMode(_turnOnOffPin, OUTPUT);
  digitalWrite(_turnOnOffPin, HIGH);
}

void Set(uint8_t value) {
  value = constrain(value, 0, DIGIPOT_MAX_AMOUNT);

  if (_currentValue == DIGIPOT_UNKNOWN) Reset();

  if (_currentValue > value) Change(DIGIPOT_DOWN, _currentValue - value);

  if (_currentValue < value) Change(DIGIPOT_UP, value - _currentValue);
}



void Reset() {
  // change down maximum number of times to ensure the value is 0
  Decrease(DIGIPOT_MAX_AMOUNT);
  _currentValue = 0;
}

void Increase(uint8_t amount) {
  amount = constrain(amount, 0, DIGIPOT_MAX_AMOUNT);
  Change(DIGIPOT_UP, amount);
}

void Decrease(uint8_t amount) {
  amount = constrain(amount, 0, DIGIPOT_MAX_AMOUNT);
  Change(DIGIPOT_DOWN, amount);
}

void Change(uint8_t direction, uint8_t amount) {
  amount = constrain(amount, 0, DIGIPOT_MAX_AMOUNT);
  digitalWrite(_udPin, direction);
  digitalWrite(_incPin, HIGH);
  digitalWrite(_csPin, LOW);

  for (uint8_t i = 0; i < amount; i++) {
    digitalWrite(_incPin, LOW);
    delayMicroseconds(2);
    digitalWrite(_incPin, HIGH);
    delayMicroseconds(2);
    if (_currentValue != DIGIPOT_UNKNOWN) {
      _currentValue += (direction == DIGIPOT_UP ? 1 : -1);
      _currentValue = constrain(_currentValue, 0, DIGIPOT_MAX_AMOUNT);
    }

  }
  digitalWrite(_csPin, HIGH);
}
