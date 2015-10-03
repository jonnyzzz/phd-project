using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.MS2D.Next
{
  /// <summary>
  /// Summary description for MS2DMethodAction.
  /// </summary>
  /// 
  [ActionMapping(typeof (IMS2DProcessAction), typeof (IMS2DProcessParameters))]
  public class MS2DMethodAction : Action
  {
    public MS2DMethodAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
    {
    }

    protected override ParametersControl GetParametersControlInternal(KernelNode node)
    {
      return new MS2DMethodParameters(Core.Instance.KernelDocument.Function);
    }

    protected override IAction CreateAction()
    {
      return new CMS2DProcessActionClass();
    }
  }
}