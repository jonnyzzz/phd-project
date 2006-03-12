using EugenePetrenko.Gui2.Actions.Filters;
using EugenePetrenko.Gui2.Kernell2.ActionFactory.ActionInfos;
using EugenePetrenko.Gui2.Logging;

namespace EugenePetrenko.Gui2.Application.TreeNodes
{
    /// <summary>
    /// Summary description for ActionTreeMenuItem.
    /// </summary>
    public class ActionTreeMenuItem : TreeMenuItem
    {
        private ActionRef action;
        private Node node;

        public ActionTreeMenuItem(Node node, ActionRef action) : base(action.ActionCaption, action.IsLeaf)
        {
            this.action = action;
            this.node = node;

            this.MenuItems.Clear();            
            this.OwnerDraw = true;
		}


        protected override void EventClick()
        {
            if (action.IsLeaf)
            {
                Logger.LogMessage("Event Click");
                Runner.Runner.Instance.ComputationForm.AcceptActionChain(node, Filter.FilterActions(action.GetActionPath()));
            }
        }
    }
}