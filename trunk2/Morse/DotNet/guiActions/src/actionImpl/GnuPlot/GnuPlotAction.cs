using System;
using guiActions.Actions;
using guiActions.Parameters;
using guiActions.src.KernelAction;
using guiKernel2.ActionFactory;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.actionImpl.GnuPlot
{
	/// <summary>
	/// Summary description for GnuPlotAction.
	/// </summary>
	/// 
	[ActionMapping(typeof(GnuPlotVisualizationKernelAction), typeof(GnuPlotVisualizationKernelParameters))]
	public class GnuPlotAction : Action
	{
		public GnuPlotAction(string caption, bool isLeaf) : base(caption, isLeaf)
		{
		}

		protected override ParametersControl GetParametersControlInternal(KernelNode node)
		{
			throw new NotImplementedException();
		}

		protected override IAction CreateAction()
		{
			return new GnuPlotVisualizationKernelAction();
		}
	}
}
