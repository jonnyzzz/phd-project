using System.Collections;
using guiKernel2.Node;
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

		public ResultSet Do(ResultSet resultSet, ProgressBarInfo progressBarInfo)
		{
			IResultSet tmp = resultSet.ToResultSet;
			foreach (ActionWrapper action in actions)
			{
				tmp = action.Do(tmp, progressBarInfo.GetProgressBarInfo(action));
			}
			return ResultSet.FromResultSet(tmp);
		}
	}
}
