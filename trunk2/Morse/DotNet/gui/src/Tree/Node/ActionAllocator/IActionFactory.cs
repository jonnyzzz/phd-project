using System;
using gui.Tree.Node.Action;
using MorseKernelATL;

namespace gui.src.Tree.Node.ActionAllocator
{
	/// <summary>
	/// Summary description for IActionFactory.
	/// </summary>
	public interface IActionFactory
	{
        bool Corresponds(IKernelNode node );
        ComputationNodeAction CreateAction(IKernelNode node);
	}
}
