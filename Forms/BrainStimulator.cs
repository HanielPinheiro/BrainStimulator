using BrainStimulator.Utils;
using MaterialSkin;
using MaterialSkin.Controls;
using SerialPortController;
using System.ComponentModel;
using static SerialPortController.Interface;

namespace BrainStimulator
{
    public partial class BrainStimulator : MaterialForm
    {
        private readonly BindingList<Pulse> pulses = new();
        private Interface? boardConnection;

        public BrainStimulator()
        {
            InitializeComponent();

            #region Form Theme

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            #endregion

            PeriodicTab_GridMain.DataSource = pulses;
            PeriodicTab_GridMain.AutoGenerateColumns = false;
            PeriodicTab_SetGridColumns();
        }

        #region GenerateComboBoxColumn

        private DataGridViewComboBoxColumn GenerateComboBoxColumn(string name, List<string> values)
        {
            DataGridViewComboBoxColumn col = new()
            {
                DataSource = values,
                HeaderText = Pulse.displayNameFromProperties.GetValueOrDefault(name),
                Width = Pulse.columSizeFromProperties.GetValueOrDefault(name)
            };
            return col;
        }

        #endregion

        #region Periodic Tab

        #region Header Panel

        private void PeriodicTab_AddPulse_Click(object sender, EventArgs e)
        {
            pulses.Add(new Pulse());
        }

        private void PeriodicTab_RemovePulse_Click(object sender, EventArgs e)
        {
            HashSet<Pulse> pulsesToRemove = new();

            foreach (DataGridViewCell cell in PeriodicTab_GridMain.SelectedCells)
                if (PeriodicTab_GridMain.Rows[cell.RowIndex].DataBoundItem is Pulse pulse) pulsesToRemove.Add(pulse);

            foreach (Pulse pulse in pulsesToRemove) pulses.Remove(pulse);
        }

        public delegate void Callback(string message);

        private void PeriodicTab_ConnectBoard_Click(object sender, EventArgs e)
        {   
            if (Application.OpenForms.OfType<Interface>().Count() == 0)
            {
                boardConnection = new Interface(PeriodicTab_ConnectBoard);
                boardConnection.Show();
                PeriodicTab_ConnectBoard.Enabled = false;
            }
            else boardConnection!.Focus();
        }

        #endregion

        private void PeriodicTab_SetGridColumns()
        {
            List<DataGridViewColumn> columns = new();

            foreach (DataGridViewColumn item in PeriodicTab_GridMain.Columns)
            {
                switch (item.DataPropertyName)
                {

                    case nameof(Pulse.AfterPulseMeasureUnity):
                    case nameof(Pulse.PulseMeasureUnity):
                        columns.Add(GenerateComboBoxColumn(item.Name, Pulse.measureUnityValues));
                        break;

                    case nameof(Pulse.Current):
                        columns.Add(GenerateComboBoxColumn(item.Name, Pulse.pulseCurrentValues));
                        break;

                    case nameof(Pulse.Polarity):
                        columns.Add(GenerateComboBoxColumn(item.Name, Pulse.pulsePolarityValues));
                        break;

                    default:
                        item.HeaderText = Pulse.displayNameFromProperties.GetValueOrDefault(item.DataPropertyName);
                        item.Width = Pulse.columSizeFromProperties.GetValueOrDefault(item.DataPropertyName);
                        columns.Add(item);
                        break;
                }
            }

            PeriodicTab_GridMain.Columns.Clear();
            PeriodicTab_GridMain.Columns.AddRange(columns.ToArray());
        }

        private void PeriodicTab_GridMain_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Ignore
        }

        #endregion
    }
}
