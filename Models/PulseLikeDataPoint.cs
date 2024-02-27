using OxyPlot;
using OxyPlot.Series;

namespace BrainStimulator.Models
{
    /// <summary>
    /// Classe que gera os dados pra preencher o combobox
    /// </summary>
    public class DataToCombobox
    {
        public DataToCombobox() { }

        public string? Name { get; set; }

        public static List<DataToCombobox> GetListFrom(List<string> itens)
        {
            var result = new List<DataToCombobox>();
            foreach (var item in itens) result.Add(new DataToCombobox() { Name = item });
            return result;
        }
    }

    /// <summary>
    /// Classe que convert o objeto Pulse que aparece no grid em um pulso no gráfico
    /// </summary>
    public class PulseLikeDataPoint
    {
        public PulseLikeDataPoint() { }

        public DataPoint FirstPoint { get; private set; }
        public DataPoint SecondPoint { get; private set; }
        public DataPoint ThirdPoint { get; private set; }
        public DataPoint FourthPoint { get; private set; }
        public DataPoint FifthPoint { get; private set; }

        public void SetDataPointsFrom(Pulse p, LineSeries lineSeries, PulseLikeDataPoint? predecessor)
        {
            var targetCurrent = Pulse.pulseCurrentToCombobox.Where(e => e.Value == p.Current).First();
            bool result = Pulse.pulseCurrentValues.TryGetValue(targetCurrent.Key, out double currentValue);
            if (!result) throw new Exception($"Failed when try to generate chart - {nameof(currentValue)}");

            var targetPolarity = Pulse.pulsePolarityToCombobox.Where(e => e.Value == p.Polarity).First();
            result = Pulse.pulsePolarityValues.TryGetValue(targetPolarity.Key, out double polarityValue);
            if (!result) throw new Exception($"Failed when try to generate chart - {nameof(polarityValue)}");

            var targetAfterPulseLength = Pulse.measureUnityToCombobox.Where(e => e.Value == p.AfterPulseMeasureUnity).First();
            result = Pulse.measureUnityValues.TryGetValue(targetAfterPulseLength.Key, out double afterPulseUnity);
            if (!result) throw new Exception($"Failed when try to generate chart - {nameof(afterPulseUnity)}");

            var targetPulseLength = Pulse.measureUnityToCombobox.Where(e => e.Value == p.PulseMeasureUnity).First();
            result = Pulse.measureUnityValues.TryGetValue(targetPulseLength.Key, out double pulseUnity);
            if (!result) throw new Exception($"Failed when try to generate chart - {nameof(pulseUnity)}");

            var firstX = (predecessor == null) ? 0 : predecessor.FifthPoint.X;

            FirstPoint = new DataPoint(firstX, 0);
            SecondPoint = new DataPoint(FirstPoint.X, currentValue * polarityValue);
            ThirdPoint = new DataPoint(SecondPoint.X + (p.PulseLength * pulseUnity), currentValue * polarityValue);
            FourthPoint = new DataPoint(ThirdPoint.X, 0);
            FifthPoint = new DataPoint(FourthPoint.X + (p.AfterPulseLength * afterPulseUnity), 0);

            lineSeries.Points.Add(FirstPoint);
            lineSeries.Points.Add(SecondPoint);
            lineSeries.Points.Add(ThirdPoint);
            lineSeries.Points.Add(FourthPoint);
            lineSeries.Points.Add(FifthPoint);
        }
    }
}
