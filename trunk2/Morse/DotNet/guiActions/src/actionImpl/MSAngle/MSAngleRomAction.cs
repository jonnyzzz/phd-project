using EugenePetrenko.Gui2.Actions.ActionImpl.MS2D.Morse;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.MSAngle
{
  /// <summary>
  /// Summary description for MSAngleRomAction.
  /// </summary>
  /// 
  [ActionMapping(typeof (IMSAngleRomProcess), typeof (IComputationParameters))]
  public class MSAngleRomAction : MS2DMorseAction
  {
    public MSAngleRomAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
    {
    }

    protected override IAction CreateAction()
    {
      return new CMSAngleRomProcessClass();
    }
  }
}