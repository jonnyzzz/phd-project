using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.KernelActions.SavePoints;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.SavePoints
{
    /// <summary>
    /// Summary description for SavePointsAction.
    /// </summary>
    /// 
    [ActionMapping(typeof (SavePointsKernelAction), typeof (ISavePointsParameters))]
    public class SavePointsAction : Action
    {
        public SavePointsAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
        {
        }


        protected override ParametersControl GetParametersControlInternal(KernelNode node)
        {
            return new SavePointsParameters();
        }

        protected override IAction CreateAction()
        {
            return new SavePointsKernelAction();
        }

        public override bool PublishResults
        {
            get { return false; }
        }
    }
}