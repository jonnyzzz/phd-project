using gui.Attributes;
using gui.Tree.Node.ActionAllocator;
using MorseKernelATL;

namespace gui.Tree.OperationSelector
{
	/// <summary>
	/// Summary description for StrongComponentsWithNodesResultAction.
	/// </summary>
	public class StrongComponentsWithNodesResultAction : ResultAction
	{
		public IComputationGraphResult result;

		public StrongComponentsWithNodesResultAction(IComputationGraphResult result)
		{
			this.result = result;
			this.Text = "Localize Strong Components with edges";
		}

		public override void DoAction()
		{
			result.StrongComponentsEdges();
		}

		[InitializeOnRun]
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

			public ResultAction CreateAction(IComputationResult node)
			{
				return new StrongComponentsWithNodesResultAction((IComputationGraphResult) node);
			}
		}
	}
}