using System;
using System.Xml;

namespace DSIS.UI.Application.Actions
{
  public abstract class ActionDescriptorParserBase : IActionDescriptorParser
  {
    protected abstract string ElementName { get; }

    public IActionDescriptor Parse(XmlElement action, IActionDescriptor parentAction)
    {
      if (action.Name != ElementName)
        return null;

      var actionId = action.GetAttribute("Id");
      var parentId = action.GetAttribute("Parent");
      if (String.IsNullOrEmpty(parentId) && parentAction != null)
        parentId = parentAction.ActionId;

      var ancor = action.GetAttribute("Ancor");

      return CreateElement(action, actionId, parentId, ancor);
    }

    protected abstract IActionDescriptor CreateElement(XmlElement element, string id, string parentId, string ancor);
  }
}