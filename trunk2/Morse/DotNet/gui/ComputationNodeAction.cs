using System;

namespace gui
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
