using BrainStimulator.Models;
using BrainStimulator.Utils;
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
        private const string downline = "\r\n";

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
                Alignment = DataGridViewContentAlignment.MiddleCenter,
            };
        }

        private void BrainStimulator_Load(object sender, EventArgs e)
        {
            PeriodicTab_SetChart();
            PeriodicTab_GridMain.DefaultConfiguration(pulses, () => PeriodicTab_GridMain.SetPersistString(this.GetType().FullName + Pulse.Layout));
            PeriodicTab_GridMain.SetCellStyle(DefaultCellStyle!);
            PeriodicTab_GridMain.SetHeaderText(Pulse.displayNameFromProperties);
            PeriodicTab_GridMain.SetWidth(Pulse.columSizeFromProperties);
        }

        #endregion

        #region Charts

        private void RefreshChart()
        {
            try
            {
                PlotModel model = GetModel();
                LineSeries? lineSeries = model.Series[0] as LineSeries;
                PulseLikeDataPoint chartPoints;
                PulseLikeDataPoint? predecessor = null;

                foreach (DataGridViewRow row in PeriodicTab_GridMain.Rows)
                    if (row.DataBoundItem is Pulse pulse)
                    {
                        chartPoints = new PulseLikeDataPoint();
                        chartPoints.SetDataPointsFrom(pulse, lineSeries!, predecessor);
                        predecessor = chartPoints;
                    }

                PeriodicTab_ChartPlotView.Model = model;
            }
            catch (Exception ex) { Error($"Problema ao tentar executar {nameof(RefreshChart)}", ex); }
        }


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

        #endregion

        #region Periodic Tab

        #region Header Panel

        private void PeriodicTab_AddPulse_Click(object sender, EventArgs e)
        {
            var p = new Pulse();
            pulses.Add(p);
            RefreshChart();
        }

        private void PeriodicTab_RemovePulse_Click(object sender, EventArgs e)
        {
            HashSet<Pulse> pulsesToRemove = new();

            foreach (DataGridViewCell cell in PeriodicTab_GridMain.SelectedCells)
                if (PeriodicTab_GridMain.Rows[cell.RowIndex].DataBoundItem is Pulse pulse) pulsesToRemove.Add(pulse);

            foreach (Pulse pulse in pulsesToRemove) pulses.Remove(pulse);

            RefreshChart();
        }

        private void PeriodicTab_ConnectBoard_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Interface>().Count() == 0)
            {
                boardConnection = new Interface(PeriodicTab_ConnectBoard, PeriodicTab_SendConfigToBoard);
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

        private void PeriodicTab_GridMain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RefreshChart();
        }

        private void PeriodicTab_GridMain_ColumnDataPropertyNameChanged(object sender, DataGridViewColumnEventArgs e)
        {
            switch (e.Column.DataPropertyName)
            {
                case nameof(Pulse.AfterPulseMeasureUnity):
                case nameof(Pulse.PulseMeasureUnity):
                    (sender as DataGridView)!.ConvertColumnToComboBox(e, DataToCombobox.GetListFrom(Pulse.measureUnityToCombobox.Select(p => p.Value).ToList()), "Name", "Name");
                    break;

                case nameof(Pulse.Current):
                    (sender as DataGridView)!.ConvertColumnToComboBox(e, DataToCombobox.GetListFrom(Pulse.pulseCurrentToCombobox.Select(p => p.Value).ToList()), "Name", "Name");
                    break;

                case nameof(Pulse.Polarity):
                    (sender as DataGridView)!.ConvertColumnToComboBox(e, DataToCombobox.GetListFrom(Pulse.pulsePolarityToCombobox.Select(p => p.Value).ToList()), "Name", "Name");
                    break;

                default:
                    (sender as DataGridView)!.ConvertColumnDefault(e);
                    break;
            }
        }

        #endregion

        private void Error(string errorMessage, Exception e)
        {
            MessageBox.Show($"{errorMessage} {downline}{downline}Exception message:{downline} {e.Message}", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
        }


    }


}
