using gui.Attributes;
using gui.Tree.Node.ActionAllocator;
using MorseKernelATL;

namespace gui.Tree.OperationSelector
{
	/// <summary>
	/// Summary description for LoopsResultAction.
	/// </summary>
	public class LoopsResultAction : ResultAction
	{
		private IComputationGraphResult result;

		public LoopsResultAction(IComputationGraphResult result)
		{
			this.result = result;
			this.Text = "Fixed Points";
		}

		public override void DoAction()
		{
			result.Loops();
		}

		[InitializeOnRun]
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

			public ResultAction CreateAction(IComputationResult node)
			{
				return new LoopsResultAction((IComputationGraphResult) node);
			}
		}
	}
}