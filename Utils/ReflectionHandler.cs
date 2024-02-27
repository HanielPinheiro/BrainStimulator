using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace BrainStimulator.Utils
{
    public static class ReflectionHandler
    {
        /// <summary>
        /// Get Type of the given class of the List<class>/BindingList<class> bound to the grid.
        /// </summary>
        public static Type PropertyType(this DataGridView sender, string dataPropertyName)
        {
            if (sender == null) throw new ArgumentNullException("DataGridView");

            Type result = typeof(string);
            if (sender.DataSource != null)
            {
                Type senderDataSourceType = sender.DataSource.GetType();
                foreach (Type senderDataSourceTypeGeneric in senderDataSourceType.GenericTypeArguments)
                {
                    if (senderDataSourceTypeGeneric.GetMembers().Any(p => p.Name == dataPropertyName))
                        result = ((PropertyInfo)senderDataSourceTypeGeneric.GetMembers().First(p => p.Name == dataPropertyName)).PropertyType;
                }
            }
            return result;
        }

        /// <summary>
        /// Get the firt Attribute of type T of a given PropertyName of the class of the List<class>/BindingList<class> bound to the grid.
        /// </summary>
        public static bool PropertyExists(this DataGridView sender, string dataPropertyName)
        {
            if (sender == null) throw new ArgumentNullException("DataGridView");

            bool result = false;

            if (sender.DataSource != null)
            {
                Type senderDataSourceType = sender.DataSource.GetType();
                foreach (Type senderDataSourceTypeGeneric in senderDataSourceType.GenericTypeArguments)
                {
                    if (senderDataSourceTypeGeneric.GetMembers().Any(p => p.Name == dataPropertyName))
                        result = true;
                }
            }
            return result;
        }

        public static Dictionary<T, string> GetFromEnum_DescriptionAttributes<T>() where T : struct, Enum
        {
            try
            {
                Dictionary<T, string> defaultValues = new();
                FieldInfo[] fields = typeof(T)!.GetFields();
                foreach (var field in fields)
                {
                    object[] attribArray = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (attribArray.Length == 0) continue;

                    var descriptionAttribute = (DescriptionAttribute)attribArray.First();
                    string? value = descriptionAttribute.Description;

                    object? obj = field.GetValue(null);
                    T enumValue = (T)Enum.ToObject(typeof(T), obj!);

                    defaultValues.Add(enumValue, value!);
                }

                return defaultValues;
            }
            catch (Exception ex) { throw new Exception($"Problem in {nameof(GetFromEnum_DescriptionAttributes)} - {ex.Message}"); };
        }

        public static Dictionary<T, double> GetFromEnum_DefaultValueAttributes<T>() where T : struct, Enum
        {
            try
            {
                Dictionary<T, double> defaultValues = new();
                FieldInfo[] fields = typeof(T)!.GetFields();
                foreach (var field in fields)
                {
                    object[] attribArray = field.GetCustomAttributes(typeof(DefaultValueAttribute), false);
                    if (attribArray.Length == 0) continue;

                    DefaultValueAttribute defaultValueAttribute = (DefaultValueAttribute)attribArray.First();
                    double? value =  double.Parse(defaultValueAttribute.Value!.ToString()!);

                    object? obj = field.GetValue(null);
                    T enumValue = (T)Enum.ToObject(typeof(T), obj!);

                    defaultValues.Add(enumValue, value.GetValueOrDefault(0d));
                }

                return defaultValues;
            }
            catch (Exception ex) { throw new Exception($"Problem in {nameof(GetFromEnum_DefaultValueAttributes)} - {ex.Message}"); };
        }

        public static Dictionary<string, string> GetFromProperties_DisplayNameAttributes<T>()
        {
            try
            {
                Dictionary<string, string> relation_Name_DisplayName = new();

                PropertyInfo[] properties = typeof(T).GetProperties();
                foreach (var property in properties)
                {
                    var attribute = property.GetCustomAttributes(typeof(DisplayNameAttribute), true)[0];
                    if (attribute != null && attribute is DisplayNameAttribute d) relation_Name_DisplayName.Add(property.Name, d.DisplayName);
                }
                return relation_Name_DisplayName;
            }
            catch (Exception ex) { throw new Exception($"Problem in {nameof(GetFromProperties_DisplayNameAttributes)} - {ex.Message}"); };
        }

        public static Dictionary<string, int> GetFromProperties_ColumnSizeAttribute<T>()
        {
            try
            {
                Dictionary<string, int> relation_Name_ColumnSize = new();

                PropertyInfo[] properties = typeof(T).GetProperties();
                foreach (var property in properties)
                {
                    var attribute = property.GetCustomAttributes(typeof(ColumnSizeAttribute), true)[0];
                    if (attribute != null && attribute is ColumnSizeAttribute d) relation_Name_ColumnSize.Add(property.Name, d.ColumSize);
                }
                return relation_Name_ColumnSize;
            }
            catch (Exception ex) { throw new Exception($"Problem in {nameof(GetFromProperties_ColumnSizeAttribute)} - {ex.Message}"); };
        }

    }

}
