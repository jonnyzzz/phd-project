
namespace EugenePetrenko.Gui2.Controls.Grid.Rows
{
    /// <summary>
    /// Summary description for DoubleCoordinatesRow.
    /// </summary>
    public class DoubleCoordinatesRow : IExGridRow
    {
        private readonly string caption;
        private readonly double[] data;

        public DoubleCoordinatesRow(string caption, int dimension) : this(caption, new double[dimension])
        {
        }

        public DoubleCoordinatesRow(string caption, double[] data)
        {
            this.caption = caption;
            this.data = data;
        }

        public string this[int index]
        {
            get { return ExGridsParseUtil.DoubleToString(data[index]); }
            set { data[index] = ExGridsParseUtil.ParseDouble(value, index); }
        }

        public double[] Data
        {
            get { return data; }
        }

        public string Caption
        {
            get { return caption; }
        }
    }
}