
namespace EugenePetrenko.Gui2.Kernell2.ActionFactory.ActionInfos
{
	/// <summary>
	/// Summary description for ActionBuilder.
	/// </summary>
	public interface ActionBuilder
	{
		void BeginLayer();
		void Node(ActionStateRef asr);
		void EndLayer();		
	}
}
