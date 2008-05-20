using DSIS.IntegerCoordinates;
using DSIS.Spring;

[assembly:SpringConfigXml("resources.spring.xml", Type=typeof(NamespaceHolder))]
namespace DSIS.IntegerCoordinates
{
  internal class NamespaceHolder
  {    
  }
}