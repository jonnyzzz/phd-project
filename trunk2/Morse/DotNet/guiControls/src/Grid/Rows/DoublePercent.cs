using System;

namespace EugenePetrenko.Gui2.Controls.Grid.Rows
{
    /// <summary>
    /// Summary description for DoublePercent.
    /// </summary>
    public class DoublePercent : IExGridRow
    {
        private double[] data;
        private string caption;

        public DoublePercent(string caption, int dimension) : this(caption, new double[dimension])
        {
            for (int i = 0; i < dimension; i++)
            {
                data[i] = 0;
            }
        }

        public DoublePercent(string caption, double[] data)
        {
            this.caption = caption;
            this.data = data;
        }

        public string this[int index]
        {
            get { return ExGridsParseUtil.DoubleToString(data[index]); }
            set
            {
				double v = ExGridsParseUtil.ParseDouble(value, index);
				if (v < 0) throw new ExGridCellException(index, "Value should be positive at {0}");
				if (v > 100) throw new ExGridCellException(index, "Value should be lover than 100 at {0}");

				this.data[index] = v/100;
			}
        }

        public string Caption
        {
            get { return caption; }
        }

        public double[] Data
        {
            get { return data; }
        }

    }
}