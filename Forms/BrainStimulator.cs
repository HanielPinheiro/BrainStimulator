using BrainStimulator.Models;
using MaterialSkin;
using MaterialSkin.Controls;
using OxyPlot;
using OxyPlot.Series;
using SerialPortController;
using System.ComponentModel;
using System.Data;

namespace BrainStimulator
{
    public partial class BrainStimulator : MaterialForm
    {
        private readonly BindingList<Pulse> pulses = new();
        private Interface? boardConnection;
        private MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        private DataGridViewCellStyle? DefaultCellStyle;
        public BrainStimulator()
        {
            InitializeComponent();

            SetFormTheme();
        }

        #region On Load

        private void SetFormTheme()
        {
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            DefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = materialSkinManager.ColorScheme.PrimaryColor,
                ForeColor = materialSkinManager.ColorScheme.TextColor,
                SelectionBackColor = materialSkinManager.ColorScheme.PrimaryColor,
                SelectionForeColor = materialSkinManager.ColorScheme.TextColor,
            };
        }


        private void BrainStimulator_Load(object sender, EventArgs e)
        {
            PeriodicTab_SetChart();

            PeriodicTab_GridMain.DataSource = pulses;
            PeriodicTab_GridMain.AutoGenerateColumns = false;
            PeriodicTab_SetColumnsToGrid();
        }

        private void PeriodicTab_SetColumnsToGrid()
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
                        item.DefaultCellStyle = DefaultCellStyle;
                        columns.Add(item);
                        break;
                }
            }

            PeriodicTab_GridMain.Columns.Clear();
            PeriodicTab_GridMain.Columns.AddRange(columns.ToArray());
        }

        #endregion

        #region Charts        

        private PlotModel GetModel()
        {
            var model = new PlotModel();
            var lineSeries = new LineSeries()
            {
                SeriesGroupName = "Series 1",
                Color = OxyColor.FromRgb(materialSkinManager.ColorScheme.PrimaryColor.R, materialSkinManager.ColorScheme.PrimaryColor.G, materialSkinManager.ColorScheme.PrimaryColor.B),
                MarkerType = MarkerType.Circle,
                MarkerSize = 6,
                MarkerStroke = OxyColor.FromRgb(materialSkinManager.ColorScheme.DarkPrimaryColor.R, materialSkinManager.ColorScheme.DarkPrimaryColor.G, materialSkinManager.ColorScheme.DarkPrimaryColor.B),
                MarkerFill = OxyColor.FromRgb(materialSkinManager.ColorScheme.LightPrimaryColor.R, materialSkinManager.ColorScheme.LightPrimaryColor.G, materialSkinManager.ColorScheme.LightPrimaryColor.B),
                MarkerStrokeThickness = 1.5,

            };
            model.Series.Add(lineSeries);
            return model;
        }

        private void SetPoints()
        {
            var model = GetModel();
            LineSeries? lineSeries = model.Series[0] as LineSeries;
            lineSeries!.Points.Add(new OxyPlot.DataPoint(0, 0));
            lineSeries!.Points.Add(new OxyPlot.DataPoint(10, 4));
            lineSeries!.Points.Add(new OxyPlot.DataPoint(30, 2));
            lineSeries!.Points.Add(new OxyPlot.DataPoint(40, 12));
            PeriodicTab_ChartPlotView.Model = model;
        }

        #endregion

        #region GenerateComboBoxColumn

        private DataGridViewComboBoxColumn GenerateComboBoxColumn(string name, List<string> values)
        {
            DataTable defaultValues = new();
            defaultValues.Columns.Add("Id", typeof(string));
            defaultValues.Columns.Add("Item", typeof(string));
            foreach (string item in values) defaultValues.Rows.Add(name, item);

            DataGridViewComboBoxColumn col = new()
            {
                Name = name,
                DataPropertyName = name,

                DataSource = defaultValues,
                DisplayMember = "Id",
                ValueMember = "Item",

                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                DefaultCellStyle = DefaultCellStyle,
                DisplayStyleForCurrentCellOnly = true,

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
            SetPoints();
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

        private void PeriodicTab_SetChart()
        {
            PeriodicTab_ChartPlotView.Model = GetModel();
        }


        private void PeriodicTab_GridMain_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Ignore
        }

        #endregion



    }
}
