using EugenePetrenko.Gui2.Actions.ActionImpl.MS2D.Morse;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.MSSegment.Morse
{
  /// <summary>
  /// Summary description for MSSegmentMorseAction.
  /// </summary>
  /// 
  [ActionMapping(typeof (IMSSegmentRom), typeof (IComputationParameters))]
  public class MSSegmentMorseAction : MS2DMorseAction
  {
    public MSSegmentMorseAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
    {
    }

    protected override IAction CreateAction()
    {
      return new CMSSegmentRomClass();
    }
  }
}