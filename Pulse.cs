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
public static class DataGridSuspendForEdit
{
    public static IDisposable SuspendWhileEditing(this DataGridView dataGridView)
    {
        return new DataGridViewLayoutSuspender(dataGridView);
    }
}

public class DataGridViewLayoutSuspender : IDisposable
{
    private DataGridView boundDataGridView;
    public DataGridViewLayoutSuspender(DataGridView dataGridView)
    {
        boundDataGridView = Subscribe(dataGridView);
    }

    private DataGridView Subscribe(DataGridView dataGridView)
    {
        if (dataGridView != null)
        {
            dataGridView.EditingControlShowing += DataGridView_EditingControlShowing;
            dataGridView.CellEndEdit += DataGridView_CellEndEdit;
        }
        return dataGridView;
    }

    private void Unsubscribe(DataGridView dataGridView)
    {
        if (dataGridView != null)
        {
            dataGridView.EditingControlShowing -= DataGridView_EditingControlShowing;
            dataGridView.CellEndEdit -= DataGridView_CellEndEdit;
        }
    }

    private void DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        DataGridView dataGridView = (sender as DataGridView);
        if (sender != null)
        {
            var raiseListChangedEventsProp = dataGridView.DataSource.GetType().GetProperty("RaiseListChangedEvents");
            raiseListChangedEventsProp?.SetValue(dataGridView.DataSource, false);
        }
    }

    private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        DataGridView dataGridView = (sender as DataGridView);
        if (sender != null)
        {
            System.Reflection.PropertyInfo raiseListChangedEventsProp = dataGridView.DataSource.GetType().GetProperty("RaiseListChangedEvents");
            raiseListChangedEventsProp?.SetValue(dataGridView.DataSource, true);
            dataGridView.Refresh();
        }
    }

    public void Dispose()
    {
        Unsubscribe(boundDataGridView);
    }
    public static void DefaultConfiguration(this DataGridView source, object dataSource, Action standardLayout, Action debugLayout, bool autoGenerateColumns = false)
    {
        DefaultConfiguration(source, dataSource, autoGenerateColumns);

        if (Control.ModifierKeys == Keys.Shift)
            debugLayout.Invoke();
        else
            standardLayout?.Invoke();
    }
    public static void DoubleBuffered(this DataGridView dgv, bool setting)
    {
        Type dgvType = dgv.GetType();
        PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);

        pi.SetValue(dgv, setting, null);
    }

    public static void DefaultConfiguration(this DataGridView source, object dataSource, bool autoGenerateColumns = false)
    {
        source.DoubleBuffered(true);
        source.SuspendWhileEditing();

        source.AutoGenerateColumns = autoGenerateColumns;
        source.DataSource = dataSource;
    }
}
