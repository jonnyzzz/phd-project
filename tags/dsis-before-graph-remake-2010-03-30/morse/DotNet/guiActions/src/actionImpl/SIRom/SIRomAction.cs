using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.SIRom
{
  /// <summary>
  /// Summary description for SIRomAction.
  /// </summary>
  /// 
  [ActionMapping(typeof (ISIRomAction), typeof (ISIRomActionParameters))]
  public class SIRomAction : Action
  {
    public SIRomAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
    {
    }

    protected override ParametersControl GetParametersControlInternal(KernelNode node)
    {
      return new SIRomActionParameters();
    }

    protected override IAction CreateAction()
    {
      return new CSIRomActionClass();
    }
  }
}