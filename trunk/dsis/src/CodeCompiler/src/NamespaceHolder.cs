using DSIS.CodeCompiler;
using DSIS.Spring.Config;

[assembly: SpringConfigXml("resources.spring.xml", Type=typeof(NamespaceHolder))]

namespace DSIS.CodeCompiler
{
  internal class NamespaceHolder
  {
    
  }
}