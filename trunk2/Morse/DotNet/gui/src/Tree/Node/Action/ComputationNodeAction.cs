using gui.Tree.Node.Menu;

namespace gui.Tree.Node.Action
{
	/// <summary>
	/// Summary description for ComputationNodeAction.
	/// </summary>
	public abstract class ComputationNodeAction
	{
		protected ComputationNodeAction() : base()
		{
		}

		public abstract ComputationNodeMenuItem[] getMenuItems();
	}
}