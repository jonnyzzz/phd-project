using System;
using guiKernel2.src.ActionFactory;
using guiKernel2.src.Actions;
using MorseKernel2;

namespace guiKernel2.Actions
{
	/// <summary>
	/// Summary description for ActionWrapper.
	/// </summary>
	public abstract class ActionWrapper : AttributeHolder
	{
		private IAction action;
		private readonly bool isChainLeaf;

		public ActionWrapper(IAction action, bool isChainLeaf)
		{
			this.action = action;
			this.isChainLeaf = isChainLeaf;
		}

		public bool IsChainLeaf
		{
			get { return isChainLeaf; }
		}

		public abstract string ActionName { get; }
		protected abstract IParameters Parameters{ get; }
		
		public IResultSet Do(IResultSet input, IProgressBar progressBar)
		{
			IParameters parameters = Parameters;
			if (parameters.GetType().GetInterface(ActionParametersName) == null)
			{
				throw new ActionPerformException("Parameter class does not match meta-defined interface");
			}

			action.SetActionParameters(parameters);
			action.SetProgressBarInfo(progressBar.GetProgressBarInfo(this));
			if (!action.CanDo(input))
			{
				throw new ActionPerformException("CanDo call returned FALSE");
			}
			return action.Do(input);
		}


		public string ActionMappingName
		{
			get
			{
				return MyAttribute.ActionInterface.Name;
			}
		}

		public string ActionParametersName
		{
			get
			{
				return MyAttribute.ParametersInterface.Name;
			}
		}


		public override string ToString()
		{
			return string.Format("ActionWrapper class [action = {0}, params = {1}]", ActionMappingName, ActionParametersName);
		}

	}
}
