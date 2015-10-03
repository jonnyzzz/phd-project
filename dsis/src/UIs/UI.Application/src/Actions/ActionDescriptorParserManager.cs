using System.Xml;
using DSIS.Spring.Service;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.Application.Actions
{
  [ComponentImplementation]
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