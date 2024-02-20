using BrainStimulator.Utils;
using MaterialSkin;
using MaterialSkin.Controls;
using System.IO.Ports;
using static BrainStimulator.BrainStimulator;

namespace SerialPortController
{
    public partial class Interface : MaterialForm
    {
        private ControlDevice? _control;
        private readonly Parameters? _parameters = new();
        private const string downline = "\r\n";

        public readonly MaterialButton controlButton;

        public Interface(MaterialButton btnReference)
        {
            controlButton = btnReference;

            InitializeComponent();

            #region Theme

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            #endregion

            RefreshCom();

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

            FillFieldsWithDefaultData(false);
            DisableFields();
        }

        #region Portas Seriais

        private void RefreshCom()
        {
            cbComPortsList.Items.Clear();
            cbComPortsList.Items.AddRange(SerialPort.GetPortNames());
            cbComPortsList.SelectedIndex = 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e) { RefreshCom(); }

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

            var param = new Parameters();

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
                _control = new ControlDevice(_parameters);
                _control.InitializeSerialPort();

                SetButtonsState(false);
            }
            catch (Exception ex) { Error("Problema ao tentar conectar na placa", ex); }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                _control!.Dispose();
                SetButtonsState(true);
            }
            catch (Exception ex) { Error("Problema ao tentar conectar na placa", ex); }
        }
        private void SetButtonsState(bool value)
        {
            btnConnect.Enabled = value;
            btnDisconnect.Enabled = !value;
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
            MessageBox.Show($"{errorMessage} {downline}{downline}Exception message:{downline} {e.Message}", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
        }

        private void Interface_FormClosed(object sender, FormClosedEventArgs e)
        {
            controlButton.Enabled = true;
            if (_control != null) try { _control!.Dispose(); } catch { /* Ignorado */ }
        }

        private void Interface_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_control != null && _control!.IsConnected)
            {
                string message = $"Você realmente deseja fechar esta janela? {downline}{downline} Isso irá cortar a comunicação com o estimulador.";
                string caption = "Fechar Interface";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No) e.Cancel = true;
            }
        }
    }
}