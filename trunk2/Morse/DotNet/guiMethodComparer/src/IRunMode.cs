using System.Xml;

namespace Eugene.Petrenko.Gui2.MethodComparer
{
	public interface IRunMode
	{
		XmlDocument[] Items { get; }
	}
}