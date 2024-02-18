using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BrainStimulator.Utils
{
    public static class GridViewActivityController
    {
        public static IDisposable SuspendWhileEditing(this DataGridView dataGridView)
        {
            return new GridHandler(dataGridView);
        }

        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo? pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);

            pi?.SetValue(dgv, setting, null);
        }


        public static void DefaultConfiguration(this DataGridView source, object dataSource)
        {
            source.DoubleBuffered(true);
            source.SuspendWhileEditing();

            source.AutoGenerateColumns = true;
            source.DataSource = dataSource;
        }
    }

    public class GridHandler : IDisposable
    {
        private DataGridView? extraGridView;
        public GridHandler() { }

        public GridHandler(DataGridView dataGridView)
        {
            SetEvents(dataGridView);
        }

        private void SetEvents(DataGridView dataGridView)
        {
            if (dataGridView != null)
            {
                dataGridView.EditingControlShowing += DataGridView_EditingControlShowing;
                dataGridView.CellEndEdit += DataGridView_CellEndEdit;
            }
            extraGridView = dataGridView;
        }

        private void UnsetEvents(DataGridView dataGridView)
        {
            if (dataGridView != null)
            {
                dataGridView.EditingControlShowing -= DataGridView_EditingControlShowing;
                dataGridView.CellEndEdit -= DataGridView_CellEndEdit;
            }
        }

        private void DataGridView_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView? dataGridView = sender as DataGridView;
            if (sender != null)
            {
                PropertyInfo? raiseListChangedEventsProp = dataGridView!.DataSource.GetType().GetProperty("RaiseListChangedEvents");
                raiseListChangedEventsProp?.SetValue(dataGridView!.DataSource, false);
            }
        }

        private void DataGridView_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            DataGridView? dataGridView = sender as DataGridView;
            if (sender != null)
            {
                PropertyInfo? raiseListChangedEventsProp = dataGridView!.DataSource.GetType().GetProperty("RaiseListChangedEvents");
                raiseListChangedEventsProp?.SetValue(dataGridView.DataSource, true);
                dataGridView.Refresh();
            }
        }

        public void Dispose() => UnsetEvents(extraGridView!);
    }
}
