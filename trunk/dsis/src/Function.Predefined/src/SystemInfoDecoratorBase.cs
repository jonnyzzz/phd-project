using DSIS.Function.Predefined;
using DSIS.Spring.Config;

[assembly: SpringConfigXml("resources.spring.xml", Type = typeof(SystemInfoDecoratorBase))]

namespace DSIS.Function.Predefined
{
  public class SystemInfoDecoratorBase
  {    
  }
}