using System;
using gui.Attributes;
using gui.src.Tree.Node.ActionAllocator;
using gui.Tree.Node.ActionAllocator;
using MorseKernelATL;

namespace gui.Tree.OperationSelector
{
	/// <summary>
	/// Summary description for LoopsResultAction.
	/// </summary>
	[InitializeStaticAttrubute("Register")]
	public class LoopsResultAction : IResultAction
	{
        IComputationGraphResult result;
		public LoopsResultAction(IComputationGraphResult result)
		{
			this.result = result;
            this.Text = "Localize Loops";
		}

	    public override void DoAction()
	    {
            result.Loops();
	    }

        public static void Register()
        {
            DynamicResultTest.Instance.RegisterAction(new LoopsResultActionFactory());
        }

        private class LoopsResultActionFactory : IResultActionFactory
        {
            public bool Corresponds(IComputationResult node)
            {
                return node is IComputationGraphResult;
            }

            public IResultAction CreateAction(IComputationResult node)
            {
                return new LoopsResultAction((IComputationGraphResult)node);
            }
        }
	}
}
