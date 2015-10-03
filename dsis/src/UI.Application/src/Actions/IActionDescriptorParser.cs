using System.Xml;
using DSIS.Core.Ioc;

namespace DSIS.UI.Application.Actions
{
  [ComponentCollection]
  public interface IActionDescriptorParser
  {
    IActionDescriptor Parse(XmlElement action, IActionDescriptor parent);
  }
}