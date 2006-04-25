using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.AdaptiveBox
{
  /// <summary>
  /// Summary description for AdaptiveBoxMethodAction.
  /// </summary>
  /// 
  [ActionMapping(typeof (IAdaptiveBoxMethod), typeof (IAdaptiveBoxParameters))]
  public class AdaptiveBoxMethodAction : Action
  {
    public AdaptiveBoxMethodAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
    {
    }

    protected override ParametersControl GetParametersControlInternal(KernelNode node)
    {
      IAdaptiveBoxMethod action = (IAdaptiveBoxMethod) Action;

      IResultSet set = node.Results.ToResultSet;
      int dim = action.GetDimensionFromParameters(set);
      double[] data = new double[dim];
      for (int i = 0; i < dim; i++)
      {
        data[i] = action.GetRecomendedPrecision(set, i);
      }
      return new AdaptiveBoxParameters(Core.Instance.KernelDocument.Function, dim, data);
    }

    protected override IAction CreateAction()
    {
      return new CAdaptiveBoxMethodClass();
    }
  }
}