//#include "arduino_aux.h"

#define DIGIPOT_UP HIGH
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
#define CURRENT_50 11

#define CONTROL_START_ROUTINE 'J'
#define CONTROL_STOP_ROUTINE 'K'
#define CONTROL_READ_INSTRUCTIONS 'L'
#define CONTROL_STOP_READ_INSTRUCTIONS 'M'
#define CONTROL_RESET_INSTRUCTION 'R'

#define INSTRUCTION_POLARITY_P '+'
#define INSTRUCTION_POLARITY_N '-'
#define INSTRUCTION_UNITY_MS 'M'
#define INSTRUCTION_UNITY_US 'U'
#define INSTRUCTION_SEPARATOR '$'
#define INSTRUCTION_END '>'

//===============================================================================
//                                Variables
//===============================================================================
int Digipot_CurrentValue = 0;

bool HasInstruction = false;
bool IsReading = false;
bool IsRunning = false;

const double mili = 0.001;
const double micro = 0.000001;

const int buffer = 250;
int counterBuffer = 0;
char tempData[buffer] = { NULL };

int pulseCounter = 0;
const int numOfPulses = 50;
int Currents[numOfPulses] = { NULL };              // listed currents above
int Polarities[numOfPulses] = { NULL };            //+1 or -1
double PulseLengths[numOfPulses] = { NULL };       //time of pulse length
double InterpulseLengths[numOfPulses] = { NULL };  // //time of interpulse interval

//===============================================================================
//                              Main Func
//===============================================================================
int main() {
  //InitializeDelayCounterAndSetClockPins(); //arquivo .S

  Digipot_CurrentValue = DIGIPOT_UNKNOWN;
  pinMode(DIGIPOT_INC_PIN, OUTPUT);
  pinMode(DIGIPOT_UD_PIN, OUTPUT);
  pinMode(DIGIPOT_CS_PIN, OUTPUT);
  digitalWrite(DIGIPOT_CS_PIN, HIGH);

  Serial.begin(115200);
  Serial.println("Stimulator is ready");

  while (1) {
    MonitoringSerialData();
    if (IsReading) HandleReceivedData();
    else if (IsRunning) RunRoutine();
  }

  return 0;
}
//===============================================================================
//                             RunRoutine
//===============================================================================

void RunRoutine() {
}

//===============================================================================
//                             Serial Monitor
//===============================================================================

void MonitoringSerialData() {
  while (Serial.available() > 0) {
    int readedBytes = Serial.readBytesUntil(INSTRUCTION_END, tempData, buffer);
    if (readedBytes == 0) Serial.write("ERROR WHEN TRY TO READ BYTES");
    else {
      Serial.print("Received data: ");
      Serial.println(tempData);
      if (tempData < 2) {

        if (tempData[0] == CONTROL_RESET_INSTRUCTION)  //R>
        {
          ResetBuffer();
          pulseCounter = 0;

          InterpulseLengths[numOfPulses] = { NULL };
          Currents[numOfPulses] = { NULL };
          Polarities[numOfPulses] = { NULL };
          PulseLengths[numOfPulses] = { NULL };

          HasInstruction = false;
          Serial.write("RESETED");
        }

        if (tempData[0] == CONTROL_START_ROUTINE)  //J>
        {
          Serial.write("Start Routine");
          if (!IsReading) {
            if (!HasInstruction) Serial.write("ERROR: Dont have a routine loaded");
            else IsRunning = true;
          } else Serial.write("ERROR: Must stop reading before run routine");
        }

        if (tempData[0] == CONTROL_STOP_ROUTINE)  //K>
        {
          Serial.write("Stop Routine");
          if (!IsReading) {
            if (!HasInstruction) Serial.write("ERROR: Dont have a routine loaded");
            else IsRunning = false;
          } else Serial.write("ERROR: Must stop reading before run routine");
        }

        if (tempData[0] == CONTROL_READ_INSTRUCTIONS)  //L>
        {
          Serial.write("Read Routine");
          if (!IsRunning) {
            if (HasInstruction) Serial.write("ERROR: Must reset pre-loaded routine first");
            else IsReading = true;
          } else Serial.write("ERROR: Must stop running before send new routine");
        }

        if (tempData[0] == CONTROL_STOP_READ_INSTRUCTIONS)  //M>
        {
          Serial.write("Stop Read Routine");
          if (!IsRunning) {
            if (IsReading && !HasInstruction) {
              IsReading = false;
              HasInstruction = true;
            }
          } else Serial.write("ERROR: Must stop running before send new routine");
        }
      }
    }
  }
}
//===============================================================================
//                             Received Data
//===============================================================================

void HandleReceivedData() {

  //char phrase[] = "250$+$50U$500M>";
  //printf(tempData);

  // get the first part - the current	==================================
  char* strtokIndx = strtok(tempData, INSTRUCTION_SEPARATOR);
  int tempCurrent = atoi(strtokIndx);
  printf("\n");
  printf("%d", tempCurrent);

  // get the second part - the polarity	==================================
  char polarity[1] = { NULL };
  int tempPolarity = 0;

  strtokIndx = strtok(NULL, INSTRUCTION_SEPARATOR);
  strcpy(polarity, strtokIndx);  // copy it to messageFromPC
  if (polarity[0] == '+') tempPolarity = 1;
  if (polarity[0] == '-') tempPolarity = -1;
  printf("\n");
  printf("\n");
  printf("%d", tempPolarity);

  // get the third part - the pulse length	==================================
  char timeWithoutUnity[15];
  strtokIndx = strtok(NULL, INSTRUCTION_SEPARATOR);
  int length = sizeof(strtokIndx) / sizeof(strtokIndx[0]);
  printf("\n");
  printf("\n");
  double timeC = 0.0;
  for (int i = 0; i < length; i++) {
    if (strtokIndx[i] == 'U') {
      timeC = atof(timeWithoutUnity) * 0.000001;
      break;
    } else if (strtokIndx[i] == 'M') {
      timeC = atof(timeWithoutUnity) * 0.001;
      printf("%f", timeC);
      break;
    } else {
      timeWithoutUnity[i] = strtokIndx[i];
    }
  }

  // get the fourth part - the interpulse length	==================================

  memset(timeWithoutUnity, 0, 15);
  strtokIndx = strtok(NULL, INSTRUCTION_SEPARATOR);
  length = sizeof(strtokIndx) / sizeof(strtokIndx[0]);
  printf("\n");
  printf("\n");
  timeC = 0.0;
  for (int i = 0; i < length; i++) {
    if (strtokIndx[i] == 'U') {
      timeC = atof(timeWithoutUnity) * 0.000001;
      printf("%f", timeC);
      break;
    } else if (strtokIndx[i] == 'M') {
      timeC = atof(timeWithoutUnity) * 0.001;
      printf("%f", timeC);
      break;
    } else {
      timeWithoutUnity[i] = strtokIndx[i];
    }
  }
}


void ResetBuffer() {
  tempData[buffer] = { NULL };
  counterBuffer = 0;
}

//===============================================================================
//                                      Delay
//===============================================================================

// void
// DelaySec (int value)
// {
//   for (int i = 0; i < value; i++)
// 	Delay_1s ();
// }

// void
// DelayMs (int value)
// {
//   for (int i = 0; i < value; i++)
// 	Delay_1ms ();
// }

// void
// DelayUs (int value)
// {
//   for (int i = 0; i < value; i++)
// 	Delay_1us ();
// }

//===============================================================================
//                        Digital Potentiometer
//===============================================================================

void SetPotentiometerValue(uint8_t value) {
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
      Digipot_CurrentValue =
        constrain(Digipot_CurrentValue, 0, DIGIPOT_MAX_AMOUNT);
    }
  }
  digitalWrite(DIGIPOT_CS_PIN, HIGH);
}
