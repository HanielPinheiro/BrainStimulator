using BrainStimulator.Models;
using MaterialSkin;
using MaterialSkin.Controls;
using System.IO.Ports;

namespace SerialPortController
{
    public partial class Interface : MaterialForm
    {
        private const string SAVED_DATA = "Saved data: ";
        private const string READING = "Reading";
        private const string LOOP = "Loop";
        private const string START_ROUTINE = "Start Routine\r\n";
        private const string JUMPLINE = "\r\n";

        private readonly DeviceControlParameters? _parameters = new();
        public readonly MaterialButton externalSendDataButton;
        public readonly MaterialButton externalConnectButton;

        private DeviceControl? _control;
        private string? receivedData;

        public bool IsRunning { get; private set; } = false;
        private bool readAllData = false;
        public int numberOfPulses = 0;

        public Interface(MaterialButton btnConnect, MaterialButton btnSend)
        {
            externalConnectButton = btnConnect;
            externalSendDataButton = btnSend;

            InitializeComponent();

            #region Theme

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            #endregion

            #region Set combo boxes

            cbParity.Items.Clear();
            cbParity.Items.AddRange(Enum.GetNames(typeof(Parity)));
            cbParity.SelectedIndex = 0;

            cbStopBits.Items.Clear();
            cbStopBits.Items.AddRange(Enum.GetNames(typeof(StopBits)));
            cbStopBits.SelectedIndex = 0;

            cbHandShake.Items.Clear();
            cbHandShake.Items.AddRange(Enum.GetNames(typeof(Handshake)));
            cbHandShake.SelectedIndex = 0;

            #endregion

            RefreshCom();
            FillFieldsWithDefaultData(false);
            DisableFields();

        }

        public void ResetControllers(int newNumberOfPulses)
        {
            IsRunning = false;
            readAllData = false;
            numberOfPulses = newNumberOfPulses;
            receivedData = txtReceivedData.Text = string.Empty;
        }

        private void txtReceivedData_TextChanged(object sender, EventArgs e)
        {
            txtReceivedData.SelectionStart = txtReceivedData.TextLength;
            txtReceivedData.ScrollToCaret();
        }

        #region Portas Seriais

        private void RefreshCom()
        {
            cbComPortsList.Items.Clear();
            cbComPortsList.Items.AddRange(SerialPort.GetPortNames());
            cbComPortsList.SelectedIndex = 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e) { RefreshCom(); }

        private void SetDataCommunication() { _control!.SetDataReceivedEventHandler(new SerialDataReceivedEventHandler(DataReceivedHandler)); }

        private void ResetDataCommunication()
        {
            _control!.SendData(BrainStimulator.BrainStimulator.STOP_READ);
            Thread.Sleep(100);

            _control!.SendData(BrainStimulator.BrainStimulator.RESET_BOARD);
            Thread.Sleep(100);

            _control!.UnSetDataReceivedEventHandler(new SerialDataReceivedEventHandler(DataReceivedHandler));
            Thread.Sleep(100);

            receivedData = txtReceivedData.Text = string.Empty;
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string newText = ((SerialPort)sender).ReadExisting();
            if (!IsRunning)
            {
                if (newText.Contains(LOOP) && readAllData) IsRunning = true; else IsRunning = false;

                var separarDadosLidos = newText.Split(new string[] { "R\r\n", "Re\r\n", "Rea\r\n", "Read\r\n", "Readi\r\n", "Readin\r\n", "Reading\r\n", "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                separarDadosLidos.RemoveAll(x => x.Contains(READING));
                receivedData += string.Join(JUMPLINE, separarDadosLidos);
                if (receivedData.Contains(SAVED_DATA))
                {
                    int result = 0;
                    var separate = receivedData.Split(SAVED_DATA);
                    if (separate.Length > 0)
                    {
                        var separate2 = separate[1].Split(START_ROUTINE);
                        int.TryParse(separate2[0].Replace(JUMPLINE, string.Empty), out result);
                    }

                    var step1 = receivedData.Split("Reseted");
                    if (step1.Length > 1) receivedData = step1[1];

                    if (result == numberOfPulses && !receivedData.Contains(LOOP))
                    {
                        readAllData = true;
                        var empty = receivedData.Replace(READING, string.Empty).Split(JUMPLINE, StringSplitOptions.RemoveEmptyEntries);
                        receivedData = null;
                        Thread.Sleep(10);
                        this.BeginInvoke(() => { txtReceivedData.Text = $"{string.Join(JUMPLINE, empty)}{JUMPLINE}{START_ROUTINE}"; });
                    }
                }
                Thread.Sleep(10);
            }
        }

        public void SendData(string text)
        {
            try
            {
                _control!.SendData(text);
            }
            catch (Exception ex)
            {
                Error($"Error when try to{nameof(SendData)}!", ex);
            }
        }

        #endregion

        #region Controle dos parametros

        #region Switch On / Off

        private void switchDefaultParameters_CheckedChanged(object sender, EventArgs e)
        {
            if (switchDefaultParameters.Checked)
            {
                FillFieldsWithDefaultData(true);
                DisableFields();
            }
            else
            {
                FillFieldsWithLastData();
                EnableFields();
            }
        }

        private void EnableFields()
        {
            SetState(true);
        }

        private void DisableFields()
        {
            SetState(false);
        }

        private void SetState(bool enable)
        {
            txtBaudRate.Enabled = enable;
            txtDataBits.Enabled = enable;
            txtReadTimeOut.Enabled = enable;
            txtWriteTimeOut.Enabled = enable;

            cbParity.Enabled = enable;
            cbStopBits.Enabled = enable;
            cbHandShake.Enabled = enable;
        }

        #endregion

        #region CopyFromParametersToFields

        private void FillFieldsWithLastData()
        {
            txtBaudRate.Text = _parameters!.BaudRate.ToString();
            txtDataBits.Text = _parameters!.DataBits.ToString();
            txtReadTimeOut.Text = _parameters!.ReadTimeOut.ToString();
            txtWriteTimeOut.Text = _parameters!.WriteTimeOut.ToString();

            cbParity.SelectedIndex = cbParity.Items.IndexOf(_parameters!.Parity.ToString());
            cbStopBits.SelectedIndex = cbStopBits.Items.IndexOf(_parameters!.StopBits.ToString());
            cbHandShake.SelectedIndex = cbHandShake.Items.IndexOf(_parameters!.HandShake.ToString());
        }

        private void FillFieldsWithDefaultData(bool savePreviousParams)
        {
            if (savePreviousParams) CopyFieldsValuesToParameters();

            var param = new DeviceControlParameters();

            txtBaudRate.Text = param.BaudRate.ToString();
            txtDataBits.Text = param.DataBits.ToString();
            txtReadTimeOut.Text = param.ReadTimeOut.ToString();
            txtWriteTimeOut.Text = param.WriteTimeOut.ToString();

            cbParity.SelectedIndex = cbParity.Items.IndexOf(param.Parity.ToString());
            cbStopBits.SelectedIndex = cbStopBits.Items.IndexOf(param.StopBits.ToString());
            cbHandShake.SelectedIndex = cbHandShake.Items.IndexOf(param.HandShake.ToString());
        }

        #endregion

        #endregion

        #region Conectar / Disconectar

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                CopyFieldsValuesToParameters();
                _parameters!.PortName = cbComPortsList.SelectedItem.ToString();
                _control = new DeviceControl(_parameters);
                _control.InitializeSerialPort();

                SetButtonsState(false);

                SetDataCommunication();
            }
            catch (Exception ex) { Error("Problema ao tentar conectar na placa", ex); }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                ResetDataCommunication();

                _control!.Dispose();

                SetButtonsState(true);
            }
            catch (Exception ex) { Error("Problema ao tentar conectar na placa", ex); }
        }
        private void SetButtonsState(bool value)
        {
            btnConnect.Enabled = value;
            externalSendDataButton.Enabled = !value;
            btnDisconnect.Enabled = !value;

            cbComPortsList.Enabled = value;
            cbHandShake.Enabled = value;
            cbParity.Enabled = value;
            cbStopBits.Enabled = value;
            switchDefaultParameters.Enabled = value;

            btnUpdate.Enabled = value;
            txtBaudRate.Enabled = value;
            txtDataBits.Enabled = value;
            txtReadTimeOut.Enabled = value;
            txtWriteTimeOut.Enabled = value;
        }

        #endregion

        #region Form Closed / Closing

        private void Interface_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResetDataCommunication();

            externalConnectButton.Enabled = true;
            externalSendDataButton.Enabled = false;

            if (_control != null) try { _control!.Dispose(); } catch { /* Ignorado */ }
        }

        private void Interface_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_control != null && _control!.IsConnected)
            {
                string message = $"Você realmente deseja fechar esta janela? {JUMPLINE}{JUMPLINE} Isso irá cortar a comunicação com o estimulador.";
                string caption = "Fechar Interface";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No) e.Cancel = true;
            }
        }

        #endregion

        #region CopyTo

        private void CopyFieldsValuesToParameters()
        {
            try { _parameters!.BaudRate = int.Parse(txtBaudRate.Text); }
            catch (Exception e) { Error($"Falha ao converter valor do campo BaudRate", e); }

            try { _parameters!.DataBits = int.Parse(txtDataBits.Text); }
            catch (Exception e) { Error($"Falha ao converter valor do campo DataBits", e); }

            try { _parameters!.ReadTimeOut = int.Parse(txtReadTimeOut.Text); }
            catch (Exception e) { Error($"Falha ao converter valor do campo ReadTimeOut", e); }

            try { _parameters!.WriteTimeOut = int.Parse(txtWriteTimeOut.Text); }
            catch (Exception e) { Error($"Falha ao converter valor do campo WriteTimeOut", e); }

            try
            {
                var str = cbParity.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(str)) _parameters!.Parity = Enum.Parse<Parity>(str);
            }
            catch (Exception e) { Error($"Falha ao converter valor do campo Parity", e); }

            try
            {
                var str = cbStopBits.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(str)) _parameters!.StopBits = Enum.Parse<StopBits>(str);
            }
            catch (Exception e) { Error($"Falha ao converter valor do campo StopBits", e); }

            try
            {
                var str = cbHandShake.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(str)) _parameters!.HandShake = Enum.Parse<Handshake>(str);
            }
            catch (Exception e) { Error($"Falha ao converter valor do campo HandShake", e); }
        }

        #endregion

        private void Error(string errorMessage, Exception e)
        {
            MessageBox.Show($"{errorMessage} {JUMPLINE}{JUMPLINE}Exception message:{JUMPLINE} {e.Message}", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
        }


    }
}