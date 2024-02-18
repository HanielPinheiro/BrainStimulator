using BrainStimulator.Utils;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace BrainStimulator
{
    public partial class BrainStimulator : MaterialForm
    {
        private readonly SortableBindingList<Pulse> pulses = new SortableBindingList<Pulse>();
        public BrainStimulator()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;

            // Set this to false to disable backcolor enforcing on non-materialSkin components
            // This HAS to be set before the AddFormToManage()
            materialSkinManager.EnforceBackcolorOnAllComponents = true;

            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            PeriodicTab_GridMain.DefaultConfiguration(pulses);
        }

        #region Comunicacao Placa

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnSendDataToBoard.Enabled = true;
            txtTerminal.Enabled = true;
        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            btnSendDataToBoard.Enabled = false;
            txtTerminal.Enabled = false;
        }


        #endregion

        #region Tabs que controlam estimulos

        #region Periodic Tab

        private void PeriodicTab_AddPulse_Click(object sender, EventArgs e)
        {
            try
            {
                PeriodicTab_GridMain.EndEdit(DataGridViewDataErrorContexts.LeaveControl);

                pulses.Add(new Pulse());

                PeriodicTab_GridMain.Refresh();
            }
            catch (Exception ex) { Error("Problema ao adicionar linha ao grid", ex); }
        }

        private void PeriodicTab_RemovePulse_Click(object sender, EventArgs e)
        {
            try
            {
                PeriodicTab_GridMain.EndEdit(DataGridViewDataErrorContexts.LeaveControl);

                if (sender is Pulse p) pulses.Remove(p);

                PeriodicTab_GridMain.Refresh();
            }
            catch (Exception ex) { Error("Problema ao remover linha do grid", ex); }
        }

        #endregion

        #endregion


        private void Error(string message, Exception e)
        {
            MessageBox.Show($"{message} - {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}