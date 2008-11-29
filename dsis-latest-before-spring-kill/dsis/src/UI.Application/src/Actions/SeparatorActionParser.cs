using System;
using System.Xml;
using DSIS.Core.Ioc;
using DSIS.Spring.Attributes;

namespace DSIS.UI.Application.Actions
{
  [SpringBean, ComponentImplementation]
  public class SeparatorActionParser : ActionDescriptorParserBase
  {
    protected override string ElementName { 
      get { return "Separator"; }
    }

    protected override IActionDescriptor CreateElement(XmlElement element, string id, string parentId, string ancor)
    {
      return new SeparatorDescriptor("Separator:" + Guid.NewGuid(), parentId, ancor);
    }
  }
}