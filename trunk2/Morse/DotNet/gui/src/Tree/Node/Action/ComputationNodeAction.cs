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

		public override string ToString()
		{
			ComputationNodeMenuItem[] itms = getMenuItems();
			if (itms.Length == 0) return "zzzzzz";
			
			return itms[0].Text;
		}
	}
}