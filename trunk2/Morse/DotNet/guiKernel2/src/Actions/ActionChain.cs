using System.Collections;
using MorseKernel2;

namespace guiKernel2.Actions
{
	/// <summary>
	/// Summary description for ComputationChain.
	/// </summary>
	public class ActionChain
	{
		
		ArrayList actions = new ArrayList();

		public ActionChain()
		{
		}

		public void AddAction(ActionWrapper action)
		{
			actions.Add(action);
		}

		public void AddActionRange(ActionWrapper[] actions)
		{
			this.actions.AddRange(actions);
		}

		public ActionWrapper[] Actions {
			get
			{
				return (ActionWrapper[])actions.ToArray(typeof(ActionWrapper));
			}
		}

		public IResultSet Do(IResultSet resultSet, IProgressBar progressBar)
		{
			IResultSet tmp = resultSet;
			foreach (ActionWrapper action in actions)
			{
				tmp = action.Do(tmp, progressBar);
			}
			return tmp;
		}

		public ActionWrapper[] NextActions
		{
			get
			{
				return new ActionWrapper[0];
			}
		}
	}
}
