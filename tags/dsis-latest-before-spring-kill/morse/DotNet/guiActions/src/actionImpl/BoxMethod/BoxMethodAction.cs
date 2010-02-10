using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl
{
  /// <summary>
  /// Summary description for BoxMethodAction.
  /// </summary>
  /// 
  [ActionMapping(typeof (IBoxMethodAction), typeof (IBoxMethodParameters))]
  public class BoxMethodAction : Action
  {
    public BoxMethodAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
    {
    }

    protected override ParametersControl GetParametersControlInternal(KernelNode node)
    {
      int dim = ((IBoxMethodAction) Action).GetDimensionForParameters(node.Results.ToResultSet);
      return new BoxMethodParameters(dim, Core.Instance.KernelDocument.Function);
    }

    protected override IAction CreateAction()
    {
      return new CBoxMethodActionClass();
    }
  }
}