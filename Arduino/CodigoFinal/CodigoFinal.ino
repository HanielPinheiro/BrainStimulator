#include "arduino_aux.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

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

#define INSTRUCTION_POLARITY_P '+'
#define INSTRUCTION_POLARITY_N '-'
#define INSTRUCTION_UNITY_MS 'M'
#define INSTRUCTION_UNITY_US 'U'
#define INSTRUCTION_UNITY_S 'S'

#define INSTRUCTION_SEPARATOR "$"
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
char tempData[buffer];

int pulseCounter = 0;
const int numOfPulses = 10;
int Currents[numOfPulses];                           // listed currents above
int Polarities[numOfPulses];                         //+1 or -1
double PulseLengths[numOfPulses];                    //time of pulse length
char InterpulseLengths[numOfPulses];               //time of interpulse interval
double PulseLengthsMeasure[numOfPulses];             //time of pulse length
char InterpulseLengthsMeasure[numOfPulses];        //time of interpulse interval
char measureUnity;
//===============================================================================
//                              Main Func
//===============================================================================
void setup() {
  InitializeDelayCounterAndSetClockPins(); //arquivo .S

  Digipot_CurrentValue = DIGIPOT_UNKNOWN;
  pinMode(DIGIPOT_INC_PIN, OUTPUT);
  pinMode(DIGIPOT_UD_PIN, OUTPUT);
  pinMode(DIGIPOT_CS_PIN, OUTPUT);
  digitalWrite(DIGIPOT_CS_PIN, HIGH);
  
  Serial.begin(115200);
  Serial.print("Stimulator is ready");
}

void loop()
{
  MonitoringSerialData();
  if (IsReading) ReceivingInstruction();  
  else if (IsRunning) RunRoutine();
}

//===============================================================================
//                             RunRoutine
//===============================================================================

void RunRoutine() {
  for(int i =0; i < pulseCounter; i++)
  {
     Serial.println("Running");
    SetCurrentBasedOnNominalCurrent(Currents[i]);
  //      Delay_1us;
        if(Polarities[i] == 1){Set_Pin11_High;Set_Pin12_Low;} //Seta o pino do clock1
    else{Set_Pin12_High;Set_Pin11_Low;} //Seta o pino do clock 2
//        Delay_1us;
    Wait(PulseLengths[i],  InterpulseLengths[i]); //pulse length

    Wait(PulseLengthsMeasure[i],  InterpulseLengthsMeasure[i]); //pulse length
  }  
}

void SetCurrentBasedOnNominalCurrent(int nominal)
{
  switch(nominal)
    {
      case NOMINAL_650:
        SetPotentiometerValue(CURRENT_650);
        break;
      case NOMINAL_600: 
          SetPotentiometerValue(CURRENT_600);
        break;
        case NOMINAL_550:
            SetPotentiometerValue(CURRENT_550);
        break;
      case NOMINAL_500:
          SetPotentiometerValue(CURRENT_500);
        break;
      case NOMINAL_450:
          SetPotentiometerValue(CURRENT_450);
        break;
      case NOMINAL_400: 
          SetPotentiometerValue(CURRENT_400);
        break;
      case NOMINAL_350:
          SetPotentiometerValue(CURRENT_350);
        break;
      case NOMINAL_300:
          SetPotentiometerValue(CURRENT_300);
        break;
      case NOMINAL_250:
          SetPotentiometerValue(CURRENT_250);
        break;
      case NOMINAL_200:
          SetPotentiometerValue(CURRENT_200);
        break;
        case NOMINAL_150:
            SetPotentiometerValue(CURRENT_150);
        break;
        case NOMINAL_100:
            SetPotentiometerValue(CURRENT_100);
        break;
        case NOMINAL_50:
            SetPotentiometerValue(CURRENT_50);
        break;
    }
}

void Wait(int time, char timeUnity)
{
    double integral;
  double fractional;
  if(timeUnity == INSTRUCTION_UNITY_US)
      DelayUs (time);
    else if(timeUnity == INSTRUCTION_UNITY_MS)
  {
      fractional = modf(time, &integral);
      DelayMs(integral);
      DelayUs(fractional;
  }
      else if(timeUnity == INSTRUCTION_UNITY_S)
      {
         fractional = modf(time, &integral);
      DelayS(integral);
      DelayMs(fractional;
      }
      else Serial.println("ERROR: Problem in wait function");
}

//===============================================================================
//                             Serial Monitor
//===============================================================================

void ResetBuffer() {
  memset(tempData, 0, buffer);
  counterBuffer = 0;
}

void MonitoringSerialData() {
  while (Serial.available() > 0) {
    int readedBytes = Serial.readBytesUntil(INSTRUCTION_END, tempData, buffer);
    Serial.print("Received data - Monitor ");      Serial.println(tempData);

    if (readedBytes == 0) Serial.write("ERROR WHEN TRY TO READ BYTES");
    else if (tempData[0] != '\n') {
      if (readedBytes < 2) {
        HandleControlData();
      }
    }
    ResetBuffer();
  }
}

void HandleControlData() {


  if (tempData[0] == CONTROL_RESET_INSTRUCTION)  //R>
  {
    ResetBuffer();
    pulseCounter = 0;

    InterpulseLengths[numOfPulses] = { NULL };
    Currents[numOfPulses] = { NULL };
    Polarities[numOfPulses] = { NULL };
    PulseLengths[numOfPulses] = { NULL };

    HasInstruction = false;
    Serial.println("RESETED");
  }

  if (tempData[0] == CONTROL_START_ROUTINE)  //J>
  {
    Serial.println("Start Routine");
    if (!IsReading) {
      if (!HasInstruction) Serial.println("ERROR: Dont have a routine loaded");
      else
      {
        IsRunning = true;
        Serial.println("Routine Enabled");
      }
    } else Serial.println("ERROR: Must stop reading before run routine");
  }

  if (tempData[0] == CONTROL_STOP_ROUTINE)  //K>
  {
    Serial.println("Stop Routine");
    if (!IsReading) {
      if (!HasInstruction) Serial.println("ERROR: Dont have a routine loaded");
      else
      {
        IsRunning = false;
        Serial.println("Routine Disabled");
      }
    } else Serial.println("ERROR: Must stop reading before run routine");
  }

  if (tempData[0] == CONTROL_READ_INSTRUCTIONS)  //L>
  { Serial.println("Start Read Instructions");
    if (!IsRunning) {
      if (HasInstruction) Serial.println("ERROR: Must reset pre-loaded routine first");
      else {
        IsReading = true;
        Serial.println("Read Routine Enabled");
      }
    } else Serial.println("ERROR: Must stop running before send new routine");
  }

  if (tempData[0] == CONTROL_STOP_READ_INSTRUCTIONS)  //M>
  {
    Serial.println("Stop Read Instructions");
    if (!IsRunning) {
      if (IsReading && !HasInstruction) {
        IsReading = false;
        HasInstruction = true;
        Serial.println("Read Routine Disabled");
      }
    } else Serial.println("ERROR: Must stop running before send new routine");
  }

}

//===============================================================================
//                          Receiving Instruction
//===============================================================================
//Exemplo: 250$+$189.5M$78.7U>
//Exemplo: 50$-$0.5S$787.48M>
//Exemplo: 150$-$43.4U$7.28S>
void ReceivingInstruction() {
  Serial.println("Reading");
  while (Serial.available() > 0) {

    int readedBytes = Serial.readBytesUntil(INSTRUCTION_END, tempData, buffer);
    Serial.print("Received data: ");      Serial.println(tempData);

    if (readedBytes == 0) Serial.write("ERROR WHEN TRY TO READ BYTES");
    else if (tempData[0] != '\n') {
      if (readedBytes < 2) {
        HandleControlData();
      }
      else {
        // get the first part - the current  ==================================
        char* strtokIndx = strtok(tempData, INSTRUCTION_SEPARATOR);
        int tempCurrent = atoi(strtokIndx);        
        Currents[pulseCounter] = tempCurrent;

        // get the second part - the polarity ==================================
        char polarity[1];
        int tempPolarity = 0;
        strtokIndx = strtok(NULL, INSTRUCTION_SEPARATOR);
        strcpy(polarity, strtokIndx);  // copy it to messageFromPC
        if (polarity[0] == INSTRUCTION_POLARITY_P) tempPolarity = 1;
        if (polarity[0] == INSTRUCTION_POLARITY_N) tempPolarity = -1;
        Polarities[pulseCounter] = tempPolarity;

        // get the third part - the pulse length  ==================================
        strtokIndx = strtok(NULL, INSTRUCTION_SEPARATOR);
        float timeConverted = GetTimeFromInstruction(strtokIndx);     
        PulseLengths[pulseCounter] = timeConverted;
        PulseLengthsMeasure[pulseCounter] = measureUnity;

        // get the fourth part - the interpulse length  ==================================
        strtokIndx = strtok(NULL, INSTRUCTION_SEPARATOR);
        timeConverted = GetTimeFromInstruction(strtokIndx);       
        InterpulseLengths[pulseCounter] = timeConverted;
        InterpulseLengthsMeasure[pulseCounter] = measureUnity;

        Serial.print(pulseCounter); Serial.print(": ");
        Serial.print(Currents[pulseCounter]); Serial.print(" - ");
        Serial.print(Polarities[pulseCounter]); Serial.print(" - ");
        Serial.print(PulseLengths[pulseCounter]); Serial.print(" - ");
        Serial.print(PulseLengthsMeasure[pulseCounter]); Serial.print(" - ");
        Serial.print(InterpulseLengths[pulseCounter]); Serial.print(" - ");
        Serial.println(InterpulseLengthsMeasure[pulseCounter]);

        pulseCounter++;
      }
    }
    ResetBuffer();
  }
}

float GetTimeFromInstruction(char *strtokIndx)
{
  measureUnity = 0;
  char timeWithoutUnity[15];
  strcpy(timeWithoutUnity, strtokIndx);
  float timeC = 0.0;
  for (int i = 0; i < sizeof(timeWithoutUnity); i++) {
    if (strtokIndx[i] == INSTRUCTION_UNITY_MS || strtokIndx[i] == INSTRUCTION_UNITY_US || strtokIndx[i] == INSTRUCTION_UNITY_S) {
      timeC = atof(timeWithoutUnity);
      measureUnity = strtokIndx[i];
      break;
    } else {
      timeWithoutUnity[i] = strtokIndx[i];
    }
  }
  return timeC;
}

//===============================================================================
//                                      Delay
//===============================================================================

void DelaySec (int value)
{
  for (int i = 0; i < value; i++)
    Delay_1s ();
}

void DelayMs (int value)
{
  for (int i = 0; i < value; i++)
    Delay_1ms ();
}

void DelayUs (int value)
{
  for (int i = 0; i < value; i++)
    Delay_1us ();
}

//===============================================================================
//                        Digital Potentiometer
//===============================================================================

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
      Digipot_CurrentValue =
        constrain(Digipot_CurrentValue, 0, DIGIPOT_MAX_AMOUNT);
    }
  }
  digitalWrite(DIGIPOT_CS_PIN, HIGH);
}

void Increase(int amount) {
  amount = constrain(amount, 0, DIGIPOT_MAX_AMOUNT);
  Change(DIGIPOT_UP, amount);
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
