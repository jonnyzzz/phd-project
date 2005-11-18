using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.Projector
{
    /// <summary>
    /// Summary description for ProjectorAction.
    /// </summary>
    /// 
    [ActionMapping(typeof (IProjectAction), typeof (IProjectActionParameters))]
    public class ProjectorAction : Action
    {
        public ProjectorAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
        {
        }

        protected override ParametersControl GetParametersControlInternal(KernelNode node)
        {
            int dim = ((IProjectAction) Action).GetDimention(node.Results.ToResultSet);
            return new ProjectorParameters(dim);
        }

        protected override IAction CreateAction()
        {
            return new CProjectActionClass();
        }
    }
}