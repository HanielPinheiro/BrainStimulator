#include "arduino_aux.h"

#define DIGIPOT_UP HIGH
#define DIGIPOT_DOWN LOW
#define DIGIPOT_MAX_AMOUNT 99
#define DIGIPOT_UNKNOWN 255
#define DIGIPOT_INC_PIN 2
#define DIGIPOT_UD_PIN 3
#define DIGIPOT_CS_PIN 4

#define CLOCK_1_PIN 11
#define CLOCK_2_PIN 12
#define ON_OFF_PIN 8

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
#define CURRENT_50 11

#define NOMINAL_650 650
#define NOMINAL_600 600
#define NOMINAL_550 550
#define NOMINAL_500 500
#define NOMINAL_450 450
#define NOMINAL_400 400
#define NOMINAL_350 350
#define NOMINAL_300 300
#define NOMINAL_250 250
#define NOMINAL_200 200
#define NOMINAL_150 150
#define NOMINAL_100 100
#define NOMINAL_50 50

#define CONTROL_START_ROUTINE 'J'
#define CONTROL_STOP_ROUTINE 'K'
#define CONTROL_READ_INSTRUCTIONS 'L'
#define CONTROL_STOP_READ_INSTRUCTIONS 'M'
#define CONTROL_RESET_INSTRUCTION 'R'
#define CONTROL_RESET_BOARD 'D'

#define INSTRUCTION_POLARITY_P '+'
#define INSTRUCTION_POLARITY_N '-'
#define INSTRUCTION_UNITY_MS 77
#define INSTRUCTION_UNITY_US 85
#define INSTRUCTION_UNITY_S 83

#define INSTRUCTION_SEPARATOR "$"
#define INSTRUCTION_END '>'

int Digipot_CurrentValue = 0;

bool HasInstruction = false;
bool IsReading = false;
bool IsRunning = false;

const double mili = 0.001;
const double micro = 0.000001;

const int buffer = 250;
int counterBuffer = 0;
char tempData[buffer];

int measureUnity;
int pulseCounter = 0;
const int numOfPulses = 10;

int Currents[numOfPulses];                          // listed currents above
int Polarities[numOfPulses];                        //+1 or -1

double PulseLengths[numOfPulses];                   //time of pulse length
double InterpulseLengths[numOfPulses];              //time of interpulse interval

int PulseLengthsMeasure[numOfPulses];               //time of pulse length
int InterpulseLengthsMeasure[numOfPulses];          //time of interpulse interval
