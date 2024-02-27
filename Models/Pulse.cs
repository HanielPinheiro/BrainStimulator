using BrainStimulator.Utils;
using System.ComponentModel;
using System.Globalization;

namespace BrainStimulator.Models
{
    /// <summary>
    /// Classe que define o objeto Pulse que aparece no grid
    /// </summary>
    public class Pulse
    {
        #region Static fields

        public static Dictionary<string, int> columSizeFromProperties = ReflectionHandler.GetFromProperties_ColumnSizeAttribute<Pulse>();
        public static Dictionary<string, string> displayNameFromProperties = ReflectionHandler.GetFromProperties_DisplayNameAttributes<Pulse>();

        public static Dictionary<PulsePolariy, string> pulsePolarityToCombobox = ReflectionHandler.GetFromEnum_DescriptionAttributes<PulsePolariy>();
        public static Dictionary<PulseCurrents, string> pulseCurrentToCombobox = ReflectionHandler.GetFromEnum_DescriptionAttributes<PulseCurrents>();
        public static Dictionary<MeasureUnity, string> measureUnityToCombobox = ReflectionHandler.GetFromEnum_DescriptionAttributes<MeasureUnity>();

        public static Dictionary<PulsePolariy, double> pulsePolarityValues = ReflectionHandler.GetFromEnum_DefaultValueAttributes<PulsePolariy>();
        public static Dictionary<PulseCurrents, double> pulseCurrentValues = ReflectionHandler.GetFromEnum_DefaultValueAttributes<PulseCurrents>();
        public static Dictionary<MeasureUnity, double> measureUnityValues = ReflectionHandler.GetFromEnum_DefaultValueAttributes<MeasureUnity>();

        public static string Layout = $"|{nameof(Pulse.PulseLength)}|{nameof(Pulse.PulseMeasureUnity)}|{nameof(Pulse.AfterPulseLength)}"
                                    + $"|{nameof(Pulse.AfterPulseMeasureUnity)}|{nameof(Pulse.Current)}|{nameof(Pulse.Polarity)}";

        #endregion

        public Pulse(){}

        #region Largura do Pulso

        private double _pulseLength = 100;

        [DisplayName("Largura do Pulso"), ColumnSize(90)]
        public double PulseLength
        {
            get { return _pulseLength; }
            set
            {
                var val = double.Parse(value.ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                if (PulseMeasureUnity.Equals(MeasureUnity.Microseconds)) _pulseLength = Math.Round(val, 0);
                else _pulseLength = val;
            }
        }

        #endregion

        #region Intervalo entre Pulsos

        private double _afterPulseLength = 100;

        [DisplayName("Intervalo entre Pulsos"), ColumnSize(110)]
        public double AfterPulseLength
        {
            get { return _afterPulseLength; }
            set
            {
                var val = double.Parse(value.ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                if (PulseMeasureUnity.Equals(MeasureUnity.Microseconds)) _afterPulseLength = Math.Round(val, 0);
                else _afterPulseLength = val;
            }
        }

        #endregion

        [DisplayName("Unidade de medida da largura do pulso"), ColumnSize(180)]
        public string PulseMeasureUnity { get; set; } = measureUnityToCombobox[MeasureUnity.Microseconds];

        [DisplayName("Unidade de medida do Intervalo entre pulsos"), ColumnSize(180)]
        public string AfterPulseMeasureUnity { get; set; } = measureUnityToCombobox[MeasureUnity.Milliseconds];

        [DisplayName("Corrente [uA]"), ColumnSize(90)]
        public string Current { get; set; } = pulseCurrentToCombobox[PulseCurrents.Hundred];

        [DisplayName("Polaridade [uA]"), ColumnSize(90)]
        public string Polarity { get; set; } = pulsePolarityToCombobox[PulsePolariy.Positive];        
    }

}