using System;
using gui.Attributes;
using gui.src.Tree.Node.ActionAllocator;
using gui.Tree.Node.ActionAllocator;
using MorseKernelATL;

namespace gui.Tree.OperationSelector
{
	/// <summary>
	/// Summary description for StrongComponentsResultAction.
	/// </summary>
	[InitializeStaticAttrubute("Register")]
	public class StrongComponentsResultAction : IResultAction
	{
        private IComputationGraphResult result;

		public StrongComponentsResultAction(IComputationGraphResult result)
		{
            this.result = result;
            this.Text = "Strong Components without edges";
			
		}

	    public override void DoAction()
	    {
	        result.StrongComponents();
	    }

        public static void Register()
        {
            DynamicResultTest.Instance.RegisterAction(new StrongComponentsResultActionFactory());
        }

        private class StrongComponentsResultActionFactory : IResultActionFactory
        {
            public bool Corresponds(IComputationResult node)
            {
                return node is IComputationGraphResult;
            }

            public IResultAction CreateAction(IComputationResult node)
            {
                return new StrongComponentsResultAction((IComputationGraphResult)node);
            }
        }


	}
}
