using System;
using MorseKernel2;

namespace guiActions.actionImpl.Tarjan
{
	/// <summary>
	/// Summary description for TarjanParametersImpl.
	/// </summary>
	public class TarjanParametersImpl : ITarjanParameters
	{
		private bool needResolve;

		public TarjanParametersImpl(bool needResolve)
		{
			this.needResolve = needResolve;
		}

		public bool NeedEdgeResolve()
		{
			return needResolve;
		}
	}
}
