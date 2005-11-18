using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.PointMethod
{
    /// <summary>
    /// Summary description for MSPointMethodAction.
    /// </summary>
    /// 
    [ActionMapping(typeof (IMSMethodAction), typeof (IPointMethodParameters))]
    public class MSPointMethodAction : PointMethodAction
    {
        public MSPointMethodAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
        {
        }

        protected override IAction CreateAction()
        {
            return new CMSMethodActionClass();
        }
    }
}