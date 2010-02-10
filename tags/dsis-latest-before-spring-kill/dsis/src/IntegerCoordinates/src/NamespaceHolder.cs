using DSIS.IntegerCoordinates;
using DSIS.Spring.Assemblies;
using DSIS.Spring.Config;

[assembly:SpringConfigXml("resources.spring.xml", Type=typeof(NamespaceHolder))]
[assembly:IncludeAssembly("DSIS.CodeCompiler")]
namespace DSIS.IntegerCoordinates
{
  internal static class NamespaceHolder
  {    
  }
}