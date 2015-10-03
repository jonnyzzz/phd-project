using gui.Attributes;
using gui.Tree.Node.ActionAllocator;
using gui.Tree.Node.Factory;
using MorseKernelATL;

namespace gui.Tree.OperationSelector
{
	/// <summary>
	/// Summary description for ExtendPointResultAction.
	/// </summary>
	public class ExtendPointResultAction : ResultAction
	{
		private IComputationExtendingResult result;

		public ExtendPointResultAction(IComputationExtendingResult result)
		{
			this.result = result;
			this.Text = "Projective Extension for Point Methods";
		}


		public override void DoAction()
		{
			IExtendablePointParams param = ComputationParametersFactory.ParamsExtend(null, result, null);
			if (param != null)
			{
				result.PointMethodProjectiveExtension(param);
			}
		}

		[InitializeOnRun]
		public static void Register()
		{
			DynamicResultTest.Instance.RegisterAction(new ExtendPointResultActionFactory());
		}

		private class ExtendPointResultActionFactory : IResultActionFactory
		{
			public bool Corresponds(IComputationResult node)
			{
				return node is IComputationExtendingResult;
			}

			public ResultAction CreateAction(IComputationResult node)
			{
				return new ExtendPointResultAction((IComputationExtendingResult) node);
			}
		}
	}
}