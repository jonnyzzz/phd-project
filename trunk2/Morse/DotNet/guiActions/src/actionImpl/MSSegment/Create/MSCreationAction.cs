using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.MSSegment.Create
{
    /// <summary>
    /// Summary description for MSCreationAction.
    /// </summary>
    /// 
    [ActionMapping(typeof (IMSCreationProcess), typeof (IMSCreationParameters))]
    public class MSCreationAction : Action
    {
        public MSCreationAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
        {
        }

        protected override ParametersControl GetParametersControlInternal(KernelNode node)
        {
            int dim = ((IMSCreationProcess) Action).GetDimension(node.Results.ToResultSet);
            return new MSCreationControl(dim);
        }

        protected override IAction CreateAction()
        {
            return new CMSCreationProcessClass();
        }
    }
}