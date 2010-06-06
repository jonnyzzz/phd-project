using System.Xml;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.Application.Actions
{
  [ComponentImplementation]
  public class ActionDescriptorParser : ActionDescriptorParserBase
  {
    protected override string ElementName { get {return "Action";} }

    protected override IActionDescriptor CreateElement(XmlElement element, string id, string parentId, string ancor)
    {
      var title = element.GetAttribute("Title");
      var description = Util.Safe(element.SelectSingleNode("description/text()"), string.Empty, x => x.Value);

      return new ActionDescriptor(id, parentId, ancor, description, title);

    }
  }
}