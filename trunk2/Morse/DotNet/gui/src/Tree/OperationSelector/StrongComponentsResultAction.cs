using gui.Attributes;
using gui.Tree.Node.ActionAllocator;
using MorseKernelATL;

namespace gui.Tree.OperationSelector
{
	/// <summary>
	/// Summary description for StrongComponentsResultAction.
	/// </summary>
	public class StrongComponentsResultAction : ResultAction
	{
		private IComputationGraphResult result;

		public StrongComponentsResultAction(IComputationGraphResult result)
		{
			this.result = result;
			this.Text = "Localize Strong Components without edges";

		}

		public override void DoAction()
		{
			result.StrongComponents();
		}

		[InitializeOnRun]
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

			public ResultAction CreateAction(IComputationResult node)
			{
				return new StrongComponentsResultAction((IComputationGraphResult) node);
			}
		}


	}
}