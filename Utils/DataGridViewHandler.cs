using System.ComponentModel;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BrainStimulator.Utils
{
    public static class DataGridViewHandler
    {
        #region Column Default

        /// <summary>
        /// Convert column to a default behavior (bool to checkbox, byte to text and list to nothing)
        /// </summary>
        public static void ConvertColumnDefault(this DataGridView sender, DataGridViewColumnEventArgs e)
        {
            if (sender == null)
                return;

            var columnType = sender.PropertyType(e.Column.DataPropertyName);
            if (columnType == typeof(bool))
            {
                sender.ConvertColumnToCheckBox(e);
                e.Column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            else if (columnType == typeof(byte[]))
            {
                sender.ConvertColumnToTextBox(e);
            }
            else if (columnType != null && columnType.IsGenericType && columnType.GetGenericTypeDefinition() == typeof(List<>))
            {
                (sender as DataGridView)!.Columns.Remove(e.Column);
            }
        }

        #endregion

        #region Column To Combobox

        /// <summary>
        /// Convert Column to ComboBox
        /// </summary>
        public static void ConvertColumnToComboBox(this DataGridView sender, DataGridViewColumnEventArgs e, object dataSource, string valueMember, string displayMember)
        {
            if (sender == null)
                return;

            if (e.Column.GetType() == typeof(DataGridViewComboBoxColumn))
            {
                foreach (DataGridViewRow row in (sender as DataGridView)!.Rows)
                {
                    (row.Cells[e.Column.Index] as DataGridViewComboBoxCell)!.ValueMember = valueMember;
                    (row.Cells[e.Column.Index] as DataGridViewComboBoxCell)!.DisplayMember = displayMember;
                    (row.Cells[e.Column.Index] as DataGridViewComboBoxCell)!.DataSource = dataSource;
                }

                DataGridViewComboBoxCell comboboxCell = new DataGridViewComboBoxCell();
                comboboxCell.ValueMember = valueMember;
                comboboxCell.DisplayMember = displayMember;
                comboboxCell.DataSource = dataSource;
                comboboxCell.FlatStyle = FlatStyle.Flat;
                e.Column.CellTemplate = comboboxCell;
                e.Column.Visible = true;
            }
            else
            {
                DataGridViewComboBoxColumn resetupColumn = new DataGridViewComboBoxColumn();
                sender.Columns.Remove(e.Column);
                sender.Columns.Add(resetupColumn);

                resetupColumn.Visible = false;
                resetupColumn.HeaderText = e.Column.HeaderText;
                resetupColumn.FlatStyle = FlatStyle.Flat;
                resetupColumn.DataPropertyName = e.Column.DataPropertyName;
            }
        }

        #endregion

        #region Column To Checkbox

        /// <summary>
        /// Convert Column to CheckBox
        /// </summary>
        public static void ConvertColumnToCheckBox(this DataGridView sender, DataGridViewColumnEventArgs e)
        {
            if (sender == null)
                return;

            if (e.Column.GetType() == typeof(DataGridViewCheckBoxColumn))
            {
                e.Column.CellTemplate = new DataGridViewCheckBoxCell();
                e.Column.Visible = true;
                e.Column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            else
            {
                var resetupColumn = new DataGridViewCheckBoxColumn();
                (sender as DataGridView)!.Columns.Remove(e.Column);
                (sender as DataGridView)!.Columns.Add(resetupColumn);
                resetupColumn.Visible = false;
                resetupColumn.DataPropertyName = e.Column.DataPropertyName;
                resetupColumn.HeaderText = e.Column.HeaderText;
            }
        }

        #endregion

        #region Column To TextBox

        /// <summary>
        /// Convert Column to TextBox
        /// </summary>
        public static void ConvertColumnToTextBox(this DataGridView sender, DataGridViewColumnEventArgs e)
        {
            if (sender == null)
                return;

            if (e.Column.GetType() == typeof(DataGridViewTextBoxColumn))
            {
                e.Column.CellTemplate = new DataGridViewTextBoxCell();
                e.Column.Visible = true;
            }
            else
            {
                var resetupColumn = new DataGridViewTextBoxColumn();
                (sender as DataGridView)!.Columns.Remove(e.Column);
                (sender as DataGridView)!.Columns.Add(resetupColumn);
                resetupColumn.Visible = false;
                resetupColumn.DataPropertyName = e.Column.DataPropertyName;
                resetupColumn.HeaderText = e.Column.HeaderText;
            }
        }

        #endregion

        #region Column Add From Member Set

        /// <summary>
        /// Dynamically add columns to a datagridview based on a string array of field names, where the field names can also be splited in by ';' to add additional data.
        /// </summary>
        /// <param name="members">field;header;width</param>
        /// <param name="replacements">oldField;newField</param>
        public static void ColumnAddFromMemberSet(this DataGridView sender, IEnumerable<string> members)
        {
            if (sender == null) return;
            if (sender.DataSource == null) return;

            int i = 0;
            foreach (var item in members)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        if (item.Trim().Equals("*"))
                        {
                            foreach (var col in sender.DataSource.GetType().GenericTypeArguments.First().GetProperties().Where(p => p.CanRead).ToList())
                                try { sender.ColumnAddFromMember(sender.Columns.Count, col.Name, col.Name); } catch { /*Ignore*/ }

                        }
                        else
                        {
                            string[] subItem = item.Split(new char[] { ';', '\n', '\r' });
                            if (subItem.Length > 0)
                            {
                                string dataPropertyName = subItem[0].Trim();

                                int newIndex = sender.ColumnAddFromMember(sender.Columns.Count, dataPropertyName, dataPropertyName);

                                if (subItem.Length >= 2 && !string.IsNullOrWhiteSpace(subItem[1]))
                                    sender.Columns[newIndex].HeaderText = subItem[1].Trim();


                                if (subItem.Length >= 3 && !string.IsNullOrWhiteSpace(subItem[2]))
                                {
                                    int widthParse = 100;
                                    Int32.TryParse(subItem[2].Trim(), out widthParse);
                                    sender.Columns[newIndex].Width = widthParse;
                                }

                                if (subItem.Length >= 4 && !string.IsNullOrWhiteSpace(subItem[3]))
                                    sender.Columns[newIndex].DefaultCellStyle.Format = subItem[3];

                            }
                        }
                    }
                }
                finally { i++; }
            }
        }

        #endregion

        #region Column Add From Member

        /// <summary>
        /// Dynamically add a colum to a datagridview.
        /// </summary>
        /// <param name="displayIndex">Position</param>
        /// <param name="headerText">Header</param>
        /// <param name="dataPropertyName"></param>
        /// <returns>Index of the new column</returns>
        public static int ColumnAddFromMember(this DataGridView sender, int displayIndex, string headerText, string dataPropertyName)
        {
            if (sender == null) throw new ArgumentNullException("DataGridView");

            int newColIndex = sender.Columns.Add(dataPropertyName, headerText);
            if (sender.Columns.Count >= newColIndex)
            {
                sender.Columns[newColIndex].DataPropertyName = dataPropertyName;

                if (!sender.PropertyExists(dataPropertyName))
                {
                    sender.Columns[newColIndex].ReadOnly = true;
                    sender.Columns[newColIndex].DefaultCellStyle.NullValue = "#N/A";
                }

                sender.Columns[newColIndex].DisplayIndex = displayIndex;

                if (!string.IsNullOrWhiteSpace(headerText))
                    if (!string.Equals(dataPropertyName, headerText, StringComparison.OrdinalIgnoreCase))
                        sender.Columns[newColIndex].HeaderText = headerText;
            }
            return newColIndex;
        }

        #endregion

        #region Set Persist String

        /// <summary>
        /// Set grid columns (single grid only) from a pipe-separated string
        /// </summary>
        public static void SetPersistString(this DataGridView source, string persistString)
        {
            if (source.DataSource is null) return;

            int formName = 1;
            IEnumerable<string> predefinedColumns = persistString.Split('|').Skip(formName);

            if (!predefinedColumns.Any()) return;

            source.SafeInvoke(p =>
            {
                p.AutoGenerateColumns = false;
                p.Visible = false;
                p.Columns.Clear();
                p.ColumnAddFromMemberSet(predefinedColumns);
                p.Visible = true;
            });
        }

        #endregion

        #region Set CellStyle

        /// <summary>
        /// Set CellStyle
        /// </summary>
        public static void SetCellStyle(this DataGridView source, DataGridViewCellStyle style)
        {
            if (source is null || style is null) return;

            foreach (DataGridViewColumn col in source.Columns) col.DefaultCellStyle = style;  
        }

        /// <summary>
        /// Set Header Text
        /// </summary>
        public static void SetHeaderText(this DataGridView source, Dictionary<string, string> data)
        {
            if (source is null || data is null) return;

            foreach (DataGridViewColumn col in source.Columns) col.HeaderText = data[col.DataPropertyName];
        }

        /// <summary>
        /// Set Header Text
        /// </summary>
        public static void SetWidth(this DataGridView source, Dictionary<string, int> data)
        {
            if (source is null || data is null) return;

            foreach (DataGridViewColumn col in source.Columns) col.Width = data[col.DataPropertyName];
        }


        #endregion

        #region Safe Invoke

        /// <summary>
        /// SafeInvoke
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isi"></param>
        /// <param name="call"></param>
        private static void SafeInvoke<T>(this T isi, Action<T> call) where T : ISynchronizeInvoke
        {
            if (isi.InvokeRequired)
            {
                IAsyncResult result = isi.BeginInvoke(call, new object[] { isi });
                object endResult = isi!.EndInvoke(result!)!;
            }
            else
                call(isi);
        }

        #endregion

        #region Default Config

        public static void DefaultConfiguration(this DataGridView source, object dataSource, Action standardLayout, bool autoGenerateColumns = false)
        {
            DefaultConfiguration(source, dataSource, autoGenerateColumns);

            standardLayout?.Invoke();
        }

        private static void DefaultConfiguration(this DataGridView source, object dataSource, bool autoGenerateColumns = false)
        {
            source.DoubleBuffered(true);
            source.Subscribe();

            source.AutoGenerateColumns = autoGenerateColumns;
            source.DataSource = dataSource;
        }

        private static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo? pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi!.SetValue(dgv, setting, null);
        }

        private static void Subscribe(this DataGridView dataGridView)
        {
            if (dataGridView != null)
            {
                dataGridView.EditingControlShowing += DataGridView_EditingControlShowing;
                dataGridView.CellEndEdit += DataGridView_CellEndEdit;
            }
        }

        private static void DataGridView_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dataGridView = (sender as DataGridView)!;
            if (sender != null)
            {
                var raiseListChangedEventsProp = dataGridView.DataSource.GetType().GetProperty("RaiseListChangedEvents");
                raiseListChangedEventsProp?.SetValue(dataGridView.DataSource, false);
            }
        }

        private static void DataGridView_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (sender as DataGridView)!;
            if (sender != null)
            {
                System.Reflection.PropertyInfo raiseListChangedEventsProp = dataGridView!.DataSource!.GetType()!.GetProperty("RaiseListChangedEvents")!;
                raiseListChangedEventsProp?.SetValue(dataGridView.DataSource, true);
                dataGridView.Refresh();
            }
        }

        #endregion
    }
}
