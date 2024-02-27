using System.ComponentModel;

namespace BrainStimulator.Models
{
    /// <summary>
    /// Valência da corrente do pulso (essa é a corrente que vai fluir na carga)
    /// </summary>
    public enum PulsePolariy
    {
        [Description("+"), DefaultValue(1)]
        Positive,
        [Description("-"), DefaultValue(-1)]
        Negative
    }

    /// <summary>
    /// Pulsos de correntes em Micro Ampéres (uA) que o estimulador é capaz de reproduzir
    /// </summary>
    public enum PulseCurrents
    {
        [Description("50"), DefaultValue(50)]
        Fifty,
        [Description("100"), DefaultValue(100)]
        Hundred,
        [Description("150"), DefaultValue(150)]
        HundredFifty,
        [Description("200"), DefaultValue(200)]
        TwoHundred,
        [Description("250"), DefaultValue(250)]
        TwoHundredFifty,
        [Description("300"), DefaultValue(300)]
        ThreeHundred,
        [Description("350"), DefaultValue(350)]
        ThreeHundredFifty,
        [Description("400"), DefaultValue(400)]
        FourHundred,
        [Description("450"), DefaultValue(450)]
        FourHundredFifty,
        [Description("500"), DefaultValue(500)]
        FiveHundred,
        [Description("550"), DefaultValue(550)]
        FiveHundredFifty,
        [Description("600"), DefaultValue(600)]
        SixHundred
    }

    /// <summary>
    /// Valência da corrente do pulso (essa é a corrente que vai fluir na carga)
    /// </summary>
    public enum MeasureUnity
    {
        [Description("Segundos"), DefaultValue(1)]
        Seconds,
        [Description("Milissegundos"), DefaultValue(0.001)]
        Milliseconds,
        [Description("Microssegundos"), DefaultValue(0.000001)]
        Microseconds
    }

}
