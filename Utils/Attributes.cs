namespace BrainStimulator.Utils
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Event | AttributeTargets.Class | AttributeTargets.Method)]
    public class ColumnSizeAttribute : Attribute
    {
        public static readonly ColumnSizeAttribute Default = new ColumnSizeAttribute();

        public ColumnSizeAttribute() : this(0) { }
        public ColumnSizeAttribute(int columnSize) { ColumSizeValue = columnSize; }

        public virtual int ColumSize => ColumSizeValue;

        /// <summary>
        /// Gets or sets the column size.
        /// </summary>
        protected int ColumSizeValue { get; set; }
    }
}
