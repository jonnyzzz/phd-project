using System.Xml;
using DSIS.Spring.Attributes;
using DSIS.Spring.Service;

namespace DSIS.UI.Application.Actions
{
  [SpringBean]
  public class ActionDescriptorParserManager
  {
    private readonly IServiceProvider myProvider;

    public ActionDescriptorParserManager(IServiceProvider provider)
    {
      myProvider = provider;
    }

    public IActionDescriptor Parse(XmlElement element, IActionDescriptor parent)
    {
      foreach (var parser in myProvider.GetServices<IActionDescriptorParser>())
      {
        var v = parser.Parse(element, parent);
        if (v != null)
          return v;
      }
      return null;
    }
  }
}