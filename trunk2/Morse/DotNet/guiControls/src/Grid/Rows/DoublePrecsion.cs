using System;

namespace EugenePetrenko.Gui2.Controls.Grid.Rows
{
    /// <summary>
    /// Summary description for DoublePrecsion.
    /// </summary>
    public class DoublePrecsion : IExGridRow
    {
        private double[] data;
        private string caption;

        public DoublePrecsion(double[] data, string caption)
        {
            this.data = data;
            this.caption = caption;
        }

        public void SetValue(int index, double val)
        {
            this.data[index] = val;
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

                    this.data[index] = v;
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