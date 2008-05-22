using DSIS.Spring.Config;
using DSIS.UI.Application;
using DSIS.UI.Application.Actions;

[assembly: ActionDescriptorXmlAttributre("resources.MainMenu.xml", Type = typeof(NamespaceHolder))]
[assembly: SpringConfigXml("resources.Spring.xml", Type = typeof(NamespaceHolder))]

namespace DSIS.UI.Application
{
  internal static class NamespaceHolder
  {     
  }
}