using EugenePetrenko.Gui2.Actions.ActionImpl.AdaptiveMethod;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.MSAngle
{
  /// <summary>
  /// Summary description for MSAngleAdaptive.
  /// </summary>
  [ActionMapping(typeof (IMSAngleMethod), typeof (IAdaptiveMethodParameters))]
  public class MSAngleAdaptive : AdaptiveMethodAction
  {
    public MSAngleAdaptive(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
    {
    }

    protected override IAction CreateAction()
    {
      return new CMSAngleMethodClass();
    }
  }
}