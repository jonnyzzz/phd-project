using DSIS.Scheme.Objects;
using DSIS.Spring;

[assembly: SpringConfigXml("resources.spring.xml", Type = typeof(NamespaceHolder))]
[assembly: SpringIncludeAssembly("DSIS.CellImageBuilder.BoxMethod")]
[assembly: SpringIncludeAssembly("DSIS.CellImageBuilder.PointMethod")]

namespace DSIS.Scheme.Objects
{
  internal class NamespaceHolder
  {    
  }
}