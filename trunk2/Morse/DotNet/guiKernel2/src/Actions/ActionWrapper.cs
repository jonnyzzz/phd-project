using System;
using guiKernel2.src.ActionFactory;
using MorseKernel2;

namespace guiKernel2.Actions
{
	/// <summary>
	/// Summary description for ActionWrapper.
	/// </summary>
	public abstract class ActionWrapper
	{
		private IAction action;

		public ActionWrapper(IAction action)
		{
			this.action = action;
		}

		public abstract string ActionName { get; }
		public abstract bool isChainLeaf { get; }
		protected abstract IParameters Parameters{ get; }
		
		public IResultSet Do(IResultSet input, IProgressBar progressBar)
		{
			action.SetActionParameters(Parameters);
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
				ActionMappingAttribute[] attributes = (ActionMappingAttribute[])this.GetType().GetCustomAttributes(typeof(ActionMappingAttribute), true);
				if (attributes.Length != 1) throw new ActionException("Incorrect Attribute");

				return attributes[0].ActionInterface.Name;
			}
		}

	}
}
