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
            get { return data[index].ToString(); }
            set
            {
                try
                {
                    double v = Double.Parse(value.Replace('.', ','));
                    if (v < 0) throw new ExGridException("Value should be positive at col {0}", index);
                    if (v > 100) throw new ExGridException("Value should be lover than 100 at col {0}", index);

                    this.data[index] = v/100;
                }
                catch (FormatException)
                {
                    throw new ExGridException("Number has incorect format at col {0}", index);
                }
                catch (OverflowException)
                {
                    throw new ExGridException("Number too much at col {0}", index);
                }
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