using MorseKernelATL;

namespace gui.Tree.Node.ActionAllocator
{
	/// <summary>
	/// Summary description for IResultActionFactory.
	/// </summary>
	public interface IResultActionFactory
	{
		bool Corresponds(IComputationResult node);
		ResultAction CreateAction(IComputationResult node);
	}
}