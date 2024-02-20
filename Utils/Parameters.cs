using System.IO.Ports;

namespace BrainStimulator.Utils
{
    public class Parameters
    {
        public Parameters() { SetDefaultConfiguration(); }

        public Parameters(Parameters other) { CopyFrom(other); }


        public string? PortName { get; set; }

        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public int ReadTimeOut { get; set; }
        public int WriteTimeOut { get; set; }

        public Parity Parity { get; set; }
        public StopBits StopBits { get; set; }
        public Handshake HandShake { get; set; }


        public void CopyTo(SerialPort serialPort)
        {
            serialPort.PortName = PortName;

            serialPort.BaudRate = BaudRate;
            serialPort.DataBits = DataBits;
            serialPort.ReadTimeout = ReadTimeOut;
            serialPort.WriteTimeout = WriteTimeOut;

            serialPort.Parity = Parity;
            serialPort.StopBits = StopBits;
            serialPort.Handshake = HandShake;
        }

        public void CopyFrom(Parameters other)
        {
            PortName = other.PortName;

            BaudRate = other.BaudRate;
            DataBits = other.DataBits;
            ReadTimeOut = other.ReadTimeOut;
            WriteTimeOut = other.WriteTimeOut;

            Parity = other.Parity;
            StopBits = other.StopBits;
            HandShake = other.HandShake;
        }

        public void SetDefaultConfiguration()
        {
            BaudRate = 115200;
            DataBits = 8;
            ReadTimeOut = 20;
            WriteTimeOut = 20;

            Parity = Parity.None;
            StopBits = StopBits.One;
            HandShake = Handshake.None;
        }
    }
}
