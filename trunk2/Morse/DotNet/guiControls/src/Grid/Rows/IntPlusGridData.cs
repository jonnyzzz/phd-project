using System;

namespace guiControls.Grid.Rows
{
	/// <summary>
	/// Summary description for IntPlusGridData.
	/// </summary>
	public class IntPlusGridData : IExGridRow
	{
		private int[] data;
		private string caption;

		public IntPlusGridData(string caption, int dimension) : this(caption, new int[dimension])
		{
			for (int i=0; i<dimension; i++)
			{
				data[i] = 2;
			}
		}

		public IntPlusGridData(string caption, int[] data)
		{
			this.caption = caption;
			this.data = data;
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
					int v = Int32.Parse(value);
					if (v < 0) throw new ExGridException("Value should be positive at col {0}", index);
					
					this.data[index] = v;
				} catch (FormatException)
				{
					throw new ExGridException("Number has incorect format at col {0}", index);
				} catch (OverflowException)
				{
					throw new ExGridException("Number too much at col {0}", index);
				}				
			}
		}

		public string Caption
		{
			get { return caption; }
		}

		public int[] Data
		{
			get { return data; }
		}
	}
}