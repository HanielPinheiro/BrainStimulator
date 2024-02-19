using BrainStimulator.Utils;
using MaterialSkin;
using MaterialSkin.Controls;

namespace BrainStimulator
{
    public partial class BrainStimulator : MaterialForm
    {
        private readonly SortableBindingList<Pulse> pulses = new SortableBindingList<Pulse>();

        public BrainStimulator()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            PeriodicTab_GridMain.DataSource = pulses;
            PeriodicTab_GridMain.AutoGenerateColumns = false;
            SetColumns();
        }

        private void SetColumns()
        {
            List<DataGridViewColumn> columns = new List<DataGridViewColumn>();

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

                    case nameof(Pulse.Valence):
                        columns.Add(GenerateComboBoxColumn(item.Name, Pulse.pulseValenceValues));
                        break;

                    default:
                        columns.Add(item);
                        break;
                }
            }

            PeriodicTab_GridMain.Columns.Clear();
            PeriodicTab_GridMain.Columns.AddRange(columns.ToArray());
        }

        private DataGridViewComboBoxColumn GenerateComboBoxColumn(string name, List<string> values)
        {
            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.DataSource = values;
            //col.ValueMember = name;
            //col.DisplayMember = values.FirstOrDefault();
            //col.DataPropertyName = name;
            col.HeaderText = name;
            col.Width = 160;
            return col;
        }

        private void PeriodicTab_AddPulse_Click(object sender, EventArgs e)
        {
            pulses.Add(new Pulse());
        }

        private void PeriodicTab_RemovePulse_Click(object sender, EventArgs e)
        {
            HashSet<Pulse> pulsesToRemove = new HashSet<Pulse>();
            foreach (DataGridViewCell cell in PeriodicTab_GridMain.SelectedCells)

                if (PeriodicTab_GridMain.Rows[cell.RowIndex].DataBoundItem is Pulse pulse) pulsesToRemove.Add(pulse);
            foreach (Pulse pulse in pulsesToRemove) pulses.Remove(pulse);
        }

        private void PeriodicTab_GridMain_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Log or handle the error here
        }
    }
}
