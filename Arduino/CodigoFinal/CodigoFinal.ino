#include "arduino_aux.h"

#define DIGIPOT_UP   HIGH
#define DIGIPOT_DOWN LOW
#define DIGIPOT_MAX_AMOUNT 99
#define DIGIPOT_UNKNOWN 255
#define DIGIPOT_INC_PIN 2
#define DIGIPOT_UD_PIN 3
#define DIGIPOT_CS_PIN 4

//delta(vh - vl) = 1k100Ohm
//58 = 654 //54 = 596 //51 = 556 //47 = 504 //43 = 455 //38 = 395 //34 = 346
//30 = 300 //26 = 250 //22 = 195 //19 = 155 //15 = 100uA //11 = 51 uA
#define CURRENT_650 58
#define CURRENT_600 54
#define CURRENT_550 51
#define CURRENT_500 47
#define CURRENT_450 43
#define CURRENT_400 38
#define CURRENT_350 34
#define CURRENT_300 30
#define CURRENT_250 26
#define CURRENT_200 22
#define CURRENT_150 19
#define CURRENT_100 15
#define CURRENT_50  11

#define CONTROL_SERIAL_NUMCHARS 32
#define CONTROL_SERIAL_START '<'
#define CONTROL_SERIAL_END '>'

#define CONTROL_BOARD_WAIT_INSTRUCTION 'W'
#define CONTROL_BOARD_RESET_INSTRUCTION 'R'
//#define CONTROL_BOARD_START_STIMULATION 'O'
//#define CONTROL_BOARD_STOP_STIMULATION 'X'

#define CONTROL_INSTRUCTION_CURRENT 'I'
#define CONTROL_INSTRUCTION_POLARITY 'P'
#define CONTROL_INSTRUCTION_PULSE_LENGTH 'L'
#define CONTROL_INSTRUCTION_AFTER_PULSE_LENGTH 'D'
#define CONTROL_INSTRUCTION_UNITY_MS 'M'
#define CONTROL_INSTRUCTION_UNITY_US 'U'

#define SUCCESS "OK"
#define FAIL "ERROR"

//===============================================================================
//                                Variables
//===============================================================================
uint8_t Digipot_CurrentValue = 0;

byte Control_Index = 0;
char Control_Instructions[CONTROL_SERIAL_NUMCHARS];
char Control_ReceivedChars[CONTROL_SERIAL_NUMCHARS];
char Control_IncomingChar;

boolean HasInstructions = false; 
boolean IsReceiving = false; 

//===============================================================================
//                              Main Func
//===============================================================================
int main()
{
  InitializeDelayCounterAndSetClockPins(); //arquivo .S

  Digipot_CurrentValue = DIGIPOT_UNKNOWN;
  pinMode(DIGIPOT_INC_PIN, OUTPUT);
  pinMode(DIGIPOT_UD_PIN, OUTPUT);
  pinMode(DIGIPOT_CS_PIN, OUTPUT);
  digitalWrite(DIGIPOT_CS_PIN, HIGH);

  Serial.begin(115200);
  Serial.println("Stimulator is ready");

  while (1) {
    MonitoringSerialData();
  }

  return 0;
}

//===============================================================================
//                             Serial Monitor
//===============================================================================

void MonitoringSerialData() {
  
  while (Serial.available() > 0) {
    Control_IncomingChar = Serial.read();
    Serial.write(SUCCESS);
    
    switch (Control_IncomingChar)
    {
      case CONTROL_BOARD_WAIT_INSTRUCTION:
        IsReceiving = !IsReceiving; 
        
        if(IsReceiving){ Serial.write("RECEIVING");}
        else
        {
          Serial.write("RECEIVED");
          HasInstructions = true;
        }
        break;

      case CONTROL_BOARD_RESET_INSTRUCTION:
        for (int i = 0; i < CONTROL_SERIAL_NUMCHARS; i++){  Control_Instructions[i] = 0; }
          
        HasInstructions = false;
        
        Serial.write("RESETED");
        break;

      default:
        if(IsReceiving)
        {
          if(!HasInstructions)
          {
            switch (Control_IncomingChar)
            {
               case CONTROL_INSTRUCTION_CURRENT:
               break;
          
                case CONTROL_INSTRUCTION_POLARITY:
               break;
          
                case CONTROL_INSTRUCTION_PULSE_LENGTH:
               break;
          
                case CONTROL_INSTRUCTION_AFTER_PULSE_LENGTH:
               break;
          
                case CONTROL_INSTRUCTION_UNITY_MS:
               break;
          
                case CONTROL_INSTRUCTION_UNITY_US:
               break;
            }
          }
        }
        
        break;
    }
    
  }
  
}

//===============================================================================
//                                      Delay
//===============================================================================

void DelaySec(int value)
{
  for (int i = 0; i < value; i++) Delay_1s();
}

void DelayMs(int value)
{
  for (int i = 0; i < value; i++) Delay_1ms();
}

void DelayUs(int value)
{
  for (int i = 0; i < value; i++) Delay_1us();
}

//===============================================================================
//                        Digital Potentiometer
//===============================================================================

void SetPotentiometerValue(uint8_t value) {
  value = constrain(value, 0, DIGIPOT_MAX_AMOUNT);

  if (Digipot_CurrentValue == DIGIPOT_UNKNOWN)
  {
    //RESET THE POTENTIOMETER TO 0
    Decrease(DIGIPOT_MAX_AMOUNT);
    Digipot_CurrentValue = 0;
  }

  if (Digipot_CurrentValue > value) Change(DIGIPOT_DOWN, Digipot_CurrentValue - value);

  if (Digipot_CurrentValue < value) Change(DIGIPOT_UP, value - Digipot_CurrentValue);
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
  digitalWrite(DIGIPOT_UD_PIN, direction);
  digitalWrite(DIGIPOT_INC_PIN, HIGH);
  digitalWrite(DIGIPOT_CS_PIN, LOW);

  for (uint8_t i = 0; i < amount; i++) {
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
