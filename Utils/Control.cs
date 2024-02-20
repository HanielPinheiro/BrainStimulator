using System.IO.Ports;

namespace BrainStimulator.Utils
{
    public class ControlDevice : IDisposable
    {
        private const int defaultSleep = 1000;

        private readonly Parameters parameters = new Parameters();
        private readonly SerialPort serialPort;
        public bool IsConnected { get => serialPort!.IsOpen; }

        public ControlDevice() { serialPort = new SerialPort(); }

        /// <summary>
        /// This constructor use <see cref="DefaultBoardConfiguration"/>
        /// </summary>
        /// <param name="portName"></param>
        public ControlDevice(string _portName)
        {
            serialPort = new SerialPort();

            parameters.PortName = _portName;
            parameters.CopyTo(serialPort);
        }

        public ControlDevice(Parameters _parameters)
        {
            serialPort = new SerialPort();

            parameters.CopyFrom(_parameters);
            parameters.CopyTo(serialPort);
        }        

        #region Reset

        /// <summary>
        /// Reset serialPort
        /// </summary>
        public void Reset(bool defaultConfiguration)
        {
            Dispose();

            parameters.CopyFrom(new Parameters());
            parameters.CopyTo(serialPort);

            InitializeSerialPort();
        }

        #endregion

        #region Open / Dispose

        /// <summary>
        /// Initialize serial port = serialPort.Open()
        /// </summary>
        public void InitializeSerialPort() { serialPort!.Open(); }

        /// <summary>
        /// Following IDispose
        /// </summary>
        public void Dispose() => Dispose(null);

        /// <summary>
        /// Dispose Serial Port Connection
        /// </summary>
        public void Dispose(string? instructionToSendToTurnOffBoard)
        {
            if (IsConnected)
            {
                if (!string.IsNullOrEmpty(instructionToSendToTurnOffBoard))
                {
                    serialPort!.Write(instructionToSendToTurnOffBoard);
                    Thread.Sleep(defaultSleep);
                }

                serialPort!.Dispose();
            }
        }

        #endregion

        /// <summary>
        /// Set a Received Event Handler to handler data received from board
        /// </summary>
        /// <param name="dataReceivedHandler"></param>
        public void SetDataReceivedEventHandler(SerialDataReceivedEventHandler dataReceivedHandler)
        {   
            serialPort!.DataReceived += dataReceivedHandler; 
        }


    }
}

