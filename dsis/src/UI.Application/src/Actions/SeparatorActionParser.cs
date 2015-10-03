using System.Xml;
using DSIS.Spring.Attributes;

namespace DSIS.UI.Application.Actions
{
  [SpringBean]
  public class SeparatorActionParser : ActionDescriptorParserBase
  {
    protected override string ElementName { 
      get { return "Separator"; }
    }
    protected override IActionDescriptor CreateElement(XmlElement element, string id, string parentId, string ancor)
    {
      return new SeparatorDescriptor(id, parentId, ancor);
    }
  }
}