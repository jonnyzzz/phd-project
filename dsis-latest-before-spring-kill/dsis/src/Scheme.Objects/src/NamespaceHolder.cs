using DSIS.Scheme.Objects;
using DSIS.Spring.Assemblies;
using DSIS.Spring.Config;

[assembly: SpringConfigXml("resources.spring.xml", Type = typeof(NamespaceHolder))]
[assembly: IncludeAssembly("DSIS.CellImageBuilder.BoxMethod")]
[assembly: IncludeAssembly("DSIS.CellImageBuilder.PointMethod")]
[assembly: IncludeAssembly("DSIS.IntegerCoordinates")]

namespace DSIS.Scheme.Objects
{
  internal static class NamespaceHolder
  {    
  }
} 