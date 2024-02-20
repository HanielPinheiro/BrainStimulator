using System.ComponentModel;
using System.Reflection;

namespace BrainStimulator.Utils
{
    public static class ReflectionHandler
    {
        public static List<string> GetFromEnum_DefaultValueAttributes<T>()
        {
            try
            {
                List<string> descriptions = new();

                FieldInfo[] fields = typeof(T)!.GetFields();
                foreach (var field in fields)
                {
                    object[] attribArray = field.GetCustomAttributes(false);

                    if (attribArray.Length == 0) continue;

                    foreach (var atrib in attribArray)
                        if (atrib is DefaultValueAttribute attrib && attrib != null) descriptions.Add(attrib.Value!.ToString()!);
                }

                return descriptions;
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
            catch (Exception ex) { throw new Exception($"Problem in {nameof(GetFromProperties_DisplayNameAttributes)} - {ex.Message}"); };
        }

    }

}
