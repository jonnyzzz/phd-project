using guiKernel2.Node;
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
		private string actionName;

		public ActionWrapper(string actionName, bool isChainLeaf)
		{
			this.actionName = actionName;
			this.isChainLeaf = isChainLeaf;
			this.action = CreateAction();
		}		

		public bool IsChainLeaf
		{
			get { return isChainLeaf; }
		}

		public string ActionName
		{
			get
			{
				return actionName;
			}
		}
		protected abstract IParameters Parameters{ get; }
		protected abstract IAction CreateAction();
		
		
		public virtual bool PublishResults
		{
			get { return true; }
		}
		
		public ResultSet Do(ResultSet input, ProgressBarInfo info)
		{
			return ResultSet.FromResultSet(Do(input.ToResultSet, info.GetProgressBarInfo(this)));
		}


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
