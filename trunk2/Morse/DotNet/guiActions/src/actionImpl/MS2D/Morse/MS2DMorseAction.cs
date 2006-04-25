using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.MS2D.Morse
{
  /// <summary>
  /// Summary description for MS2DMorseAction.
  /// </summary>
  /// 
  [ActionMapping(typeof (IMS2DRomAction), typeof (IComputationParameters))]
  public class MS2DMorseAction : Action
  {
    public MS2DMorseAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
    {
    }

    protected override ParametersControl GetParametersControlInternal(KernelNode node)
    {
      return new MS2DMorseActionParameters(Core.Instance.KernelDocument.Function);
    }

    protected override IAction CreateAction()
    {
      return new CMS2DRomActionClass();
    }
  }
}