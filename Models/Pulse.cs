using BrainStimulator.Utils;
using System.ComponentModel;
using System.Data;
using System.Globalization;

namespace BrainStimulator.Models
{
    /// <summary>
    /// Valência da corrente do pulso (essa é a corrente que vai fluir na carga)
    /// </summary>
    internal enum PulsePolariy
    {
        [DefaultValue("+")]
        Positive,
        [DefaultValue("-")]
        Negative
    }

    /// <summary>
    /// Pulsos de correntes em Micro Ampéres (uA) que o estimulador é capaz de reproduzir
    /// </summary>
    internal enum PulseCurrents
    {
        [DefaultValue(50)]
        Fifty,
        [DefaultValue(100)]
        Hundred,
        [DefaultValue(150)]
        HundredFifty,
        [DefaultValue(200)]
        TwoHundred,
        [DefaultValue(250)]
        TwoHundredFifty,
        [DefaultValue(300)]
        ThreeHundred,
        [DefaultValue(350)]
        ThreeHundredFifty,
        [DefaultValue(400)]
        FourHundred,
        [DefaultValue(450)]
        FourHundredFifty,
        [DefaultValue(500)]
        FiveHundred,
        [DefaultValue(550)]
        FiveHundredFifty,
        [DefaultValue(600)]
        SixHundred
    }

    /// <summary>
    /// Valência da corrente do pulso (essa é a corrente que vai fluir na carga)
    /// </summary>
    internal enum MeasureUnity
    {
        [DefaultValue("Segundos")]
        Seconds,
        [DefaultValue("Milissegundos")]
        Milliseconds,
        [DefaultValue("Microssegundos")]
        Microseconds
    }

    /// <summary>
    /// Classe que define o objeto Pulse que aparece no gráfico
    /// </summary>
    internal class Pulse
    {
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
        public MeasureUnity PulseMeasureUnity { get; set; } = MeasureUnity.Microseconds;

        [DisplayName("Unidade de medida do Intervalo entre pulsos"), ColumnSize(180)]
        public MeasureUnity AfterPulseMeasureUnity { get; set; } = MeasureUnity.Milliseconds;

        [DisplayName("Corrente [uA]"), ColumnSize(90)]
        public PulseCurrents Current { get; set; } = PulseCurrents.Hundred;

        [DisplayName("Polaridade [uA]"), ColumnSize(90)]
        public PulsePolariy Polarity { get; set; } = PulsePolariy.Positive;

        #region Static fields

        public static Dictionary<string, int> columSizeFromProperties = ReflectionHandler.GetFromProperties_ColumnSizeAttribute<Pulse>();
        public static Dictionary<string, string> displayNameFromProperties = ReflectionHandler.GetFromProperties_DisplayNameAttributes<Pulse>();
        public static List<string> pulsePolarityValues = ReflectionHandler.GetFromEnum_DefaultValueAttributes<PulsePolariy>();
        public static List<string> pulseCurrentValues = ReflectionHandler.GetFromEnum_DefaultValueAttributes<PulseCurrents>();
        public static List<string> measureUnityValues = ReflectionHandler.GetFromEnum_DefaultValueAttributes<MeasureUnity>();

        #endregion
    }



}