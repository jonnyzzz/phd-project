using System;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.actionImpl.HomotopAction
{
	/// <summary>
	/// Summary description for HomotopParametersImpl.
	/// </summary>
	public class HomotopParametersImpl : IIsolatedSetParameters
	{
		IGraphResult result;

		public HomotopParametersImpl(IGraphResult result)
		{
			this.result = result;
		}

		public IGraphResult GetStartSet()
		{
			return result;	
		}
	}
}
