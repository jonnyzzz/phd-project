using guiActions.Parameters;
using guiKernel2.Actions;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.Actions
{
	/// <summary>
	/// Summary description for Action.
	/// </summary>
	public abstract class Action : ActionWrapper
	{
		public Action(bool isChainLeaf) : base(isChainLeaf)
		{
		}

		public override string ActionName
		{
			get { return this.GetType().Name; }
		}

		protected override MorseKernel2.IParameters Parameters
		{
			get { return cachedParameters; }
		}

		private IParameters cachedParameters = null;
		private ParametersControl cachedParametersControl = null;
		
		protected abstract ParametersControl GetParametersControlInternal(KernelNode node);

		public ParametersControl GetParametesControl(KernelNode node)
		{
			if (cachedParametersControl == null)
			{
				cachedParametersControl = GetParametersControlInternal(node);
				cachedParametersControl.DataSubmitted += new ParametersSubmitted(DataSubmitted);
			}
			return cachedParametersControl;
		}

		private void DataSubmitted(IParameters parameters)
		{
			cachedParameters = parameters;
		}
	}
}
