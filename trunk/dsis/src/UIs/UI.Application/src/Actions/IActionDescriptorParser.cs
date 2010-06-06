using System.Xml;

namespace DSIS.UI.Application.Actions
{
  public interface IActionDescriptorParser
  {
    IActionDescriptor Parse(XmlElement action, IActionDescriptor parent);
  }
}