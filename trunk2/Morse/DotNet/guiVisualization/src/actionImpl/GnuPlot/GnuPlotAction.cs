using System;
using guiActions.Actions;
using guiActions.Parameters;
using guiKernel2.ActionFactory;
using guiKernel2.Node;
using guiVisualization.KernelAction;
using guiVisualization.src.actionImpl.GnuPlot;
using MorseKernel2;

namespace guiVisualization.actionImpl.GnuPlot
{
	/// <summary>
	/// Summary description for GnuPlotAction.
	/// </summary>
	/// 
	[ActionMapping(typeof(GnuPlotVisualizationKernelAction), typeof(IGnuPlotVisualizationKernelParameters))]
	public class GnuPlotAction : Action
	{
		public GnuPlotAction(string caption, bool isLeaf) : base(caption, isLeaf)
		{
		}

		protected override ParametersControl GetParametersControlInternal(KernelNode node)
		{
			return new GnuPlotParameters();
		}

		protected override IAction CreateAction()
		{
			return new GnuPlotVisualizationKernelAction();
		}

		public override bool PublishResults
		{
			get { return false; }
		}
	}
}
