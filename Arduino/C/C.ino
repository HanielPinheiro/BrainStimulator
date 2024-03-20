#define DIGIPOT_MAX_AMOUNT 99
#define DIGIPOT_UNKNOWN 255
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

#define NOMINAL_650 "650"
#define NOMINAL_600 "600"
#define NOMINAL_550 "550"
#define NOMINAL_500 "500"
#define NOMINAL_450 "450"
#define NOMINAL_400 "400"
#define NOMINAL_350 "350"
#define NOMINAL_300 "300"
#define NOMINAL_250 "250"
#define NOMINAL_200 "200"
#define NOMINAL_150 "150"
#define NOMINAL_100 "100"
#define NOMINAL_50  "50"

#define CONTROL_START_ROUTINE 'A'
#define CONTROL_STOP_ROUTINE 'B'
#define CONTROL_READ_INSTRUCTIONS 'C'
#define CONTROL_STOP_READ_INSTRUCTIONS 'D'
#define CONTROL_RESET_INSTRUCTION 'E'
#define CONTROL_RESET_BOARD 'F'

#define INSTRUCTION_POLARITY_P "+"
#define INSTRUCTION_UNITY_MS 77
#define INSTRUCTION_UNITY_US 85
#define INSTRUCTION_UNITY_S 83
#define INSTRUCTION_DECIMAL '.'
#define INSTRUCTION_SEPARATOR '$'

int pulseCounter = 0;
const int numOfPulses = 10;                         //This was defined by consense between the developers

int Digipot_CurrentValue = 0;

int Currents[numOfPulses];                          // listed currents above
int Polarities[numOfPulses];                        //+1 or -1

int PulseLengths[numOfPulses];                   //time of pulse length
int PulseLengthsFractional[numOfPulses];                   //frac part of time of pulse length
int PulseLengthsMeasure[numOfPulses];                   //meas unity time of pulse length

int InterpulseLengths[numOfPulses];              //time of interpulse interval
int InterpulseLengthsFractional[numOfPulses];              //frac part of time of interpulse interval
int InterpulseLengthsMeasure[numOfPulses];              //meas unity time of interpulse interval
// =========================================================
// --- Control Flags ---
bool HasInstruction = false;
bool IsReading = false;
bool IsRunning = false;
bool IsWaiting = false;
int globalCounter = 0;
bool step1 = true; // the concept is: step1 = true → PulseLength delay, false → InterpulseLength delay

// =========================================================
// --- Interrupção ---
int controlTimeS = 0, controlTimeMs = 0, controlTimeUs = 0;
int targetValueS = 0, targetValueMs = 0, targetValueUs = 0;
bool runDelayS = false, runDelayMs = false, runDelayUs = false;
int valorTimer0 = 255;

// =========================================================
// --- Serial ---
const int bufferSize = 30;
unsigned char serialData;
int counterBuffer = 0;
char tempData[bufferSize];
const char newLine = '\n';

// =========================================================
// --- Função Principal ---
int main()
{
  setDigitalPorts();
  //setInterruptions();
  setSerialPorts();

  while (1) {
    USART_Transmit(newLine);
    USART_Receive();   
  }

  return 0;
}
