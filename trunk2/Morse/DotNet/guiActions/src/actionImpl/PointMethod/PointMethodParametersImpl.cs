using System;
using MorseKernel2;

namespace guiActions.src.actionImpl.PointMethod
{
	/// <summary>
	/// Summary description for PointMethodParametersImpl.
	/// </summary>
	public class PointMethodParametersImpl : IPointMethodParameters
	{
		private readonly bool useOffsets;
		private readonly IFunction function;
		private readonly int[] factor;
		private readonly int[] ks;
		private readonly double[] offset1;
		private readonly double[] offset2;

		public PointMethodParametersImpl(IFunction function, int[] factor, int[] ks, double[] offset1, double[] offset2, bool useOffsets)
		{
			this.useOffsets = useOffsets;
			this.function = function;
			this.factor = factor;
			this.ks = ks;
			this.offset1 = offset1;
			this.offset2 = offset2;
		}

		public IFunction GetFunction()
		{
			return function;
		}

		public int GetFactor(int index)
		{
			return factor[index];
		}

		public int GetPoints(int index)
		{
			return ks[index];
		}

		public bool UseOffsets()
		{
			return useOffsets;
		}

		public void GetOffset(int index, out double offset1, out double offset2)
		{
			offset1 = this.offset1[index];
			offset2 = this.offset2[index];
		}
	}
}