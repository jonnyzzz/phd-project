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
			Logger.Logger.LogMessage("Tarjan Parameters [NeedResolve = {0} ]", needResolve);
			this.needResolve = needResolve;
		}

		public bool NeedEdgeResolve()
		{
			Logger.Logger.LogMessage("Tarjan Parameters Call [NeedResolve = {0} ]", needResolve);
			return needResolve;
		}
	}
}
