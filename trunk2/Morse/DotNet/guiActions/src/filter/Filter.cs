using System.Collections;
using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Kernell2.Actions;

namespace EugenePetrenko.Gui2.Actions.Filters
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
            return (Action[]) actionList.ToArray(typeof (Action));
        }

        public static ActionWrapper[] ToActionWrapper(Action[] actions)
        {
            return actions;
        }
    }
}