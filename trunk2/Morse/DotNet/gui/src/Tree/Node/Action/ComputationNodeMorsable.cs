using System;
using gui.Tree.Node;
using gui.Tree.Node.Factory;
using gui.Tree.Node.Menu;
using MorseKernelATL;

namespace gui.Tree.Node.Action
{
	/// <summary>
	/// Summary description for ComputationNodeMorsable.
	/// </summary>
	public class ComputationNodeMorsable : ComputationNodeAction
	{
		IMorsable morseNode;
		public ComputationNodeMorsable(IMorsable morseNode)
		{
			this.morseNode = morseNode;
		}

		public override ComputationNodeMenuItem[] getMenuItems()
		{
			return new ComputationNodeMenuItem[] {
			    ComputationNodeMenuFactory.MorseAction( new ComputationNodeMenuFactory.Morse(morse))
			};
		}

		private void morse()
		{
			morseNode.Morse();
		}
	}
}
