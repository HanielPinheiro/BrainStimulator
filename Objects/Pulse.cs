using System.ComponentModel;
using System.Reflection;

namespace BrainStimulator
{
    /// <summary>
    /// Valência da corrente do pulso (essa é a corrente que vai fluir na carga)
    /// </summary>
    internal enum PulseValence
    {
        [DefaultValue("Positive")]
        Positive,
        [DefaultValue("Negative")]
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
        [DefaultValue("Seconds")]
        Seconds,
        [DefaultValue("Miliseconds")]
        Miliseconds,
        [DefaultValue("Microseconds")]
        Microseconds
    }

    /// <summary>
    /// Classe que define o objeto Pulse que aparece no gráfico
    /// </summary>
    internal class Pulse
    {
        public int AfterPulseLength { get; set; }
        public int PulseLength { get; set; }

        public MeasureUnity AfterPulseMeasureUnity { get; set; }
        public MeasureUnity PulseMeasureUnity { get; set; }

        public PulseCurrents Current { get; set; }
        public PulseValence Valence { get; set; }

        public static List<string> pulseValenceValues = GetDefaultValueAttributes(typeof(PulseValence));
        public static List<string> pulseCurrentValues = GetDefaultValueAttributes(typeof(PulseCurrents));
        public static List<string> measureUnityValues = GetDefaultValueAttributes(typeof(MeasureUnity));


        public static List<string> GetDefaultValueAttributes(Type enumType)
        {
            try
            {
                List<string> descriptions = new List<string>();
                var properties = enumType.GetProperties();
                foreach (var property in properties)
                {
                    var attribute = property.GetCustomAttributes(typeof(DefaultValueAttribute), true)[0];
                    if (attribute is DescriptionAttribute descAttribute) descriptions.Add(descAttribute.Description);
                }

                if (descriptions.Count == 0)
                {
                    FieldInfo[] fields = enumType!.GetFields();
                    foreach (var field in fields)
                    {
                        object[] attribArray = field.GetCustomAttributes(false);

                        if (attribArray.Length == 0) continue;

                        foreach (var atrib in attribArray)
                            if (atrib is DefaultValueAttribute attrib && attrib != null) descriptions.Add(attrib.Value!.ToString()!);
                    }
                }

                return descriptions;
            }
            catch { throw; };
        }
    }
}