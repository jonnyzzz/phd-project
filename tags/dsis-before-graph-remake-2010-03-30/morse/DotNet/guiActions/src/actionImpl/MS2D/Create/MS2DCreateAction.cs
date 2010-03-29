using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.MS2D.Create
{
  /// <summary>
  /// Summary description for MS2DCreateAction.
  /// </summary>
  /// 
  [ActionMapping(typeof (IMS2DCreationAction), typeof (IMS2DCreationParameters))]
  public class MS2DCreateAction : Action
  {
    public MS2DCreateAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
    {
    }

    protected override ParametersControl GetParametersControlInternal(KernelNode node)
    {
      return new MS2DCreateActionParameters();
    }

    protected override IAction CreateAction()
    {
      return new CMS2DCreationActionClass();
    }
  }
}