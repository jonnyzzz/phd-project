using DSIS.Scheme.Objects;
using DSIS.Spring;

[assembly: SpringConfigXml("resources.spring.xml", Type = typeof(NamespaceHolder))]

namespace DSIS.Scheme.Objects
{
  internal class NamespaceHolder
  {    
  }
}