using System;
using MorseKernel2;

namespace guiVisualization.KernelAction.GnuPlot
{
	/// <summary>
	/// Summary description for EmptyResultSet.
	/// </summary>
	public class EmptyResultSet : IResultSet
	{
		public EmptyResultSet()
		{
		}

		public int GetCount()
		{
			return 0;
		}

		public IResultBase GetResult(int index)
		{
			return null;
		}
	}
}
