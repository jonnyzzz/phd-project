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
		private IGraphResult result;
		private bool publishGraph;

		public HomotopParametersImpl(IGraphResult result, bool publishGraph)
		{
			this.result = result;
			this.publishGraph = publishGraph;
		}

		public bool PublishGraph
		{
			get { return publishGraph; }
		}

		public IGraphResult GetStartSet()
		{
			return result;	
		}
	}
}
