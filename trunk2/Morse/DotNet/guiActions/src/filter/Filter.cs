using System;
using System.Collections;
using guiActions.action;
using guiKernel2.Actions;

namespace guiActions.src.filter
{
	/// <summary>
	/// Summary description for Filter.
	/// </summary>
	public class Filter
	{
		public static Action[] FilterActions(ActionWrapper[] actions)
		{
			ArrayList actionList = new ArrayList();
			foreach (ActionWrapper actionWrapper in actions)
			{
				Action action = actionWrapper as Action;
				if (action != null)
				{
					actionList.Add(action);
				}
			}
			return (Action[])actionList.ToArray(typeof(Action));
		}

		public static ActionWrapper[] ToActionWrapper(Action[] actions)
		{
			return actions;
		}
	}
}
