using System;

namespace gui.Tree.Node.Forms
{
	/// <summary>
	/// Summary description for DoubleParametersRow.
	/// </summary>
	public class DoubleParametersRow : IParametersRowInfo
	{
		private int dimension; 
		private string caption;
		private double[] data;

		public DoubleParametersRow(int dimension, string caption)
		{
			this.dimension = dimension;
			this.caption = caption;

			data = new double[dimension];
		}

		public bool Submit(string inputed, int index)
		{
			data[index] = 0;
			try
			{
				data[index] = double.Parse(inputed);
				return true;
			} catch (Exception)
			{
				return false;
			}
		}

		public string Name
		{
			get { return caption; }
		}

		public string DefaultValue(int index)
		{
			return "0";
		}

		public int Dimension
		{
			get { return dimension; }
		}

		public double[] Inputed
		{
			get
			{
				return data;
			}
		}
	}
}
