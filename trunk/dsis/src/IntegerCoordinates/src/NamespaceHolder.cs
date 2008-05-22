using DSIS.IntegerCoordinates;
using DSIS.Spring.Config;

[assembly:SpringConfigXml("resources.spring.xml", Type=typeof(NamespaceHolder))]
namespace DSIS.IntegerCoordinates
{
  internal class NamespaceHolder
  {    
  }
}