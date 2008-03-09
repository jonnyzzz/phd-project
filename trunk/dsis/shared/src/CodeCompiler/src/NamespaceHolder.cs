using DSIS.CodeCompiler;
using DSIS.Spring;

[assembly: SpringConfigXml("resources.spring.xml", Type=typeof(NamespaceHolder))]

namespace DSIS.CodeCompiler
{
  internal class NamespaceHolder
  {
    
  }
}