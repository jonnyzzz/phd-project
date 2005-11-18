using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.Tarjan
{
    /// <summary>
    /// Summary description for TarjanAction.
    /// </summary>
    /// 
    [ActionMapping(typeof (ITarjanAction), typeof (ITarjanParameters))]
    public class TarjanAction : Action
    {
        public TarjanAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
        {
        }

        protected override ParametersControl GetParametersControlInternal(KernelNode node)
        {
            return new TarjanParameters();
        }

        protected override IAction CreateAction()
        {
            return new CTarjanActionClass();
        }

    }
}