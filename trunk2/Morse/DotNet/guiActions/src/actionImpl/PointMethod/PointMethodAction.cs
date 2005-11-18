using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.PointMethod
{
    /// <summary>
    /// Summary description for PointMethodAction.
    /// </summary>
    /// 
    [ActionMapping(typeof (IPointMethodAction), typeof (IPointMethodParameters))]
    public class PointMethodAction : Action
    {
        public PointMethodAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
        {
        }

        protected override ParametersControl GetParametersControlInternal(KernelNode node)
        {
            int dim = ((IPointMethodAction) Action).GetDimensionForParameters(node.Results.ToResultSet);
            return new PointMethodParameters(dim, Core.Instance.KernelDocument.Function);
        }

        protected override IAction CreateAction()
        {
            return new CPointMethodActionClass();
        }
    }
}