using System;
using guiActions.parameters;
using guiKernel2.Actions;
using MorseKernel2;

namespace guiActions.action
{
	/// <summary>
	/// Summary description for Action.
	/// </summary>
	public abstract class Action : ActionWrapper
	{
		public Action(IAction action, bool isChainLeaf) : base(action, isChainLeaf)
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
		
		protected abstract ParametersControl GetParametersControlInternal();

		public ParametersControl ParametesControl
		{
			get
			{
				if (cachedParametersControl == null)
				{
					cachedParametersControl = GetParametersControlInternal();
					cachedParametersControl.DataSubmitted +=new ParametersSubmitted(DataSubmitted);
				}
				return cachedParametersControl;				
			}
		}

		private void DataSubmitted(IParameters parameters)
		{
			cachedParameters = parameters;
		}
	}
}
