using System;

namespace guiControls.Grid.Rows
{
	/// <summary>
	/// Summary description for DoubleCoordinatesRow.
	/// </summary>
	public class DoubleCoordinatesRow : IExGridRow
	{
		private readonly string caption;
		private readonly double[] data;
		private readonly int dimension;

		public DoubleCoordinatesRow(string caption, int dimension) : this(caption, new double[dimension])
		{			
		}

		public DoubleCoordinatesRow(string caption, double[] data)
		{
			this.caption = caption;
			this.data = data;
			this.dimension = data.Length;
		}

		public string this[int index]
		{
			get
			{
				return data[index].ToString();
			}
			set
			{
				try
				{
					double d = Double.Parse(value);
					data[index] = d;
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
