using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.MinimalLoopLocalization
{
    /// <summary>
    /// Summary description for MinimalLoopLocalization.
    /// </summary>
    /// 
    [ActionMapping(typeof (IMinimalLoopLocalizationAction), typeof (IMinimalLoopLocalizationParameters))]
    public class MinimalLoopLocalizationAction : Action
    {
        public MinimalLoopLocalizationAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
        {
        }

        private MinimalLoopLocalizationParameters parameters = null;

        public void FakeControl(MinimalLoopLocalizationParameters control)
        {
            SetFakeControl(control);
            parameters = control;
        }

        protected override ParametersControl GetParametersControlInternal(KernelNode node)
        {
            if (parameters == null)
            {
                int dimension = ((IMinimalLoopLocalizationAction) Action).GetDimension(node.Results.ToResultSet);
                return new MinimalLoopLocalizationParameters(dimension);
            }
            else
            {
                return parameters;
            }
        }

        protected override IAction CreateAction()
        {
            return new CMinimalLoopLocalizationActionClass();
        }
    }
}