using guiKernel2.Container;
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

		public ActionWrapper(bool isChainLeaf)
		{
			this.isChainLeaf = isChainLeaf;
			this.action = CreateAction();
		}		

		public bool IsChainLeaf
		{
			get { return isChainLeaf; }
		}

		public abstract string ActionName { get; }
		protected abstract IParameters Parameters{ get; }
		protected abstract IAction CreateAction();
		
		public IResultSet Do(IResultSet input, IProgressBarInfo progressBarInfo)
		{
			IParameters parameters = Parameters;
			action.SetActionParameters(parameters);
			action.SetProgressBarInfo(progressBarInfo);
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

		public IAction Action
		{
			get { return action; }
		}

		public override string ToString()
		{
			return string.Format("ActionWrapper class [action = {0}, params = {1}]", ActionMappingName, ActionParametersName);
		}

	}
}
