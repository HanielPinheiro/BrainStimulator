using System.ComponentModel;
using System.Reflection;

namespace BrainStimulator
{
    /// <summary>
    /// Valência da corrente do pulso (essa é a corrente que vai fluir na carga)
    /// </summary>
    internal enum PulseValence
    {
        Positive,
        Negative
    }

    /// <summary>
    /// Pulsos de correntes em Micro Ampéres (uA) que o estimulador é capaz de reproduzir
    /// </summary>
    internal enum PulseCurrents
    {
        Fifty = 50,
        Hundred = 100,
        HundredFifty = 150,
        TwoHundred = 200,
        TwoHundredFifty = 250,
        ThreeHundred = 300,
        ThreeHundredFifty = 350,
        FourHundred = 400,
        FourHundredFifty = 450,
        FiveHundred = 500,
        FiveHundredFifty = 550,
        SixHundred = 600
    }

    /// <summary>
    /// Classe que define o objeto Pulse que aparece no gráfico
    /// </summary>
    internal class Pulse
    {
        public int AfterPulseLength { get; set; }
        public int PulseLength { get; set; }
        public PulseCurrents Current { get; set; }
        public PulseValence Valence { get; set; }
    }

}