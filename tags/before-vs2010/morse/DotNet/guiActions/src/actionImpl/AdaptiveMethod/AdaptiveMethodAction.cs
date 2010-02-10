using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.AdaptiveMethod
{
  /// <summary>
  /// Summary description for AdaptiveMethodAction.
  /// </summary>
  /// 
  [ActionMapping(typeof (IAdaptiveMethodAction), typeof (IAdaptiveMethodParameters))]
  public class AdaptiveMethodAction : Action  
  {
    public AdaptiveMethodAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
    {
    }

    protected override ParametersControl GetParametersControlInternal(KernelNode node)
    {
      IAdaptiveMethodAction action = (IAdaptiveMethodAction) Action;
      int dim = action.GetDimension(node.Results.ToResultSet);
      double[] precision = new double[dim];
      for (int i = 0; i < dim; i++)
      {
        precision[i] = action.GetRecomendedPrecision(node.Results.ToResultSet, i);
      }
      return new AdaptiveMethodParameters(dim, Core.Instance.KernelDocument.Function, precision);
    }

    protected override IAction CreateAction()
    {
      return new CAdaptiveMethodActionClass();
    }
  }
}