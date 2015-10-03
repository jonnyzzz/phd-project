using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;
using EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot2;
using EugenePetrenko.Gui2.Visualization.KernelAction;

namespace EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot
{
  /// <summary>
  /// Summary description for GnuPlotAction.
  /// </summary>
  /// 
  //[ActionMapping(typeof (GnuPlotVisualizationKernelAction), typeof (IGnuPlotVisualizationKernelParameters))]
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