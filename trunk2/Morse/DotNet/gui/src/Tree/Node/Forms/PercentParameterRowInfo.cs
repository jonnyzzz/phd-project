using System;

namespace gui.Tree.Node.Forms
{
	/// <summary>
	/// Summary description for PercentParameterRowInfo.
	/// </summary>
	public class PercentParameterRowInfo : IParametersRowInfo
	{
		private int dimension;
		private double[] data;
		string caption;

		public PercentParameterRowInfo(int dimension, string caption)
		{
			this.dimension = dimension;
			this.caption = caption;

			data = new double[dimension];
		}

		public bool Submit(string inputed, int index)
		{
			data[index] = -10;
			try
			{
				data[index] = double.Parse(inputed);
				return data[index] >= 0 && data[index] < 100;
			} catch (Exception)
			{
				return false;
			}
		}

		public string Name
		{
			get
			{
				return caption;
			}
		}

		public string DefaultValue(int index)
		{
			return "0";
		}

		public int Dimension
		{
			get
			{
				return dimension;
			}
		}
	}
}
