using System;
using guiActions.Parameters;
using guiVisualization.KernelAction;
using MorseKernel2;

namespace guiVisualization.src.actionImpl.GnuPlot
{
	/// <summary>
	/// Summary description for GnuPlotParameters.
	/// </summary>
	public class GnuPlotParameters : ParametersControl, IGnuPlotVisualizationKernelParameters
	{
		protected override IParameters SubmitDataInternal()
		{
			return this;
		}

		public override string BoxCaption
		{
			get { return "Visualization settings"; }
		}

		public override bool NeedShowForm
		{
			get { return false; } 
		}
	}
}
