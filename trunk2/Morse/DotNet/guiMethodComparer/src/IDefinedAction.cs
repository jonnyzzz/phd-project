using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace Eugene.Petrenko.Gui2.MethodComparer
{
	/// <summary>
	/// Summary description for IDefinedAction.
	/// </summary>
	public interface IDefinedAction
	{
        string Name { get; }
	    IAction Action {get; }
	    IParameters GetParameters(ResultSet forSet);
	}
}
