namespace BrainStimulator
{
    public partial class BrainStimulator : Form
    {
        private readonly List<Pulse> pulses = new List<Pulse>();
        public BrainStimulator()
        {
            InitializeComponent();
            //PeriodicTab_GridMain.DataSource = pulses;
            PeriodicTab_GridMain.DefaultConfiguration(pulses, () => SetCustomizedLayout(SetLayoutString()), () => SetDebugLayout());
        }

        #region Header

        private void btnSendDataToBoard_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateCom_Click(object sender, EventArgs e)
        {

        }

        private void btnStartStimulus_Click(object sender, EventArgs e)
        {
            btnStartStimulus.Enabled = false;
            btnStopStimulus.Enabled = true;
        }

        private void btnStopStimulus_Click(object sender, EventArgs e)
        {
            btnStartStimulus.Enabled = true; 
            btnStopStimulus.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            btnUpdateCom.Enabled = false;
            cbComPorts.Enabled = false;

            btnDisconnect.Enabled = true;
            btnStartStimulus.Enabled = true;
            btnStopStimulus.Enabled = false;
            btnSendDataToBoard.Enabled = true;
            txtTerminal.Enabled = true;
        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = true;
            btnUpdateCom.Enabled = true;
            cbComPorts.Enabled = true;

            btnDisconnect.Enabled = false;
            btnStartStimulus.Enabled = false;
            btnStopStimulus.Enabled = false;
            btnSendDataToBoard.Enabled = false;
            txtTerminal.Enabled = false;
        }
       

        #endregion

        #region Tabs

        #region Periodic Tab

        private void PeriodicTab_AddPulse_Click(object sender, EventArgs e)
        {
            pulses.Add(new Pulse());
            PeriodicTab_GridMain.Refresh();
        }

        private void PeriodicTab_RemovePulse_Click(object sender, EventArgs e)
        {
            if (sender is Pulse p) pulses.Remove(p);
        }

        #endregion

        #endregion

    }
}