using System;

namespace gui.Tree.Node.Forms
{
	/// <summary>
	/// Summary description for IntParametersRowInfo.
	/// </summary>
	public class IntParametersRowInfo : IParametersRowInfo
	{
		private int dimension;
		private string caption;

		private int[] data;

		public IntParametersRowInfo(int dimension, string caption)
		{
			this.dimension = dimension;
			this.caption = caption;

			data = new int[dimension];
		}

		public bool Submit(string inputed, int index)
		{
			data[index] = -10;
			try
			{
				data[index] = int.Parse(inputed);
				return data[index] > 0;
			} catch (Exception)
			{
				return false;
			}
		}

		public string Name
		{
			get { return this.caption; }
		}

		public string DefaultValue(int index)
		{
			return "2";
		}

		public int Dimension
		{
			get { return this.dimension; }
		}

		public int[] Inputed
		{
			get { return data; }
		}
	}
}
