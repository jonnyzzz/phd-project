using System;
using gui.Attributes;
using gui.src.Tree.Node.ActionAllocator;
using gui.Tree.Node.Action;
using gui.Tree.Node.ActionAllocator;
using MorseKernelATL;

namespace gui.Tree.OperationSelector
{
	/// <summary>
	/// Summary description for StrongComponentsWithNodesResultAction.
	/// </summary>
	[InitializeStaticAttrubute("Register")]
	public class StrongComponentsWithNodesResultAction : IResultAction
	{
        public IComputationGraphResult result;
		public StrongComponentsWithNodesResultAction(IComputationGraphResult result)
		{
			this.result = result;
            this.Text = "Chain Reccurent set with edges";
		}

	    public override void DoAction()
	    {
	        result.StrongComponentsEdges();
	    }

        public static void Register()
        {
            DynamicResultTest.Instance.RegisterAction(new StrongComponentsWithNodesResultActionFactory());
        }


        private class StrongComponentsWithNodesResultActionFactory : IResultActionFactory
        {
            public bool Corresponds(IComputationResult node)
            {
                return node is IComputationGraphResult;
            }

            public IResultAction CreateAction(IComputationResult node)
            {
                return new StrongComponentsWithNodesResultAction((IComputationGraphResult)node);
            }
        }
	}
}
