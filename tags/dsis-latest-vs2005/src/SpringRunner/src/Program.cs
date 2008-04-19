using DSIS.Spring;
using DSIS.SpringRunner;
using log4net;

[assembly: SpringConfigXml("resources.spring.xml", Type = typeof(Program))]
[assembly: SpringIncludeAssembly("DSIS.Scheme2")]
[assembly: SpringIncludeAssembly("DSIS.Scheme.Objects")]

namespace DSIS.SpringRunner
{  
  public class Program
  {
    static void Main(string[] args)
    {
      Log4NetConfigurator.SetUp();
    
      SpringIoCSetup.SetUp();

      LogManager.GetLogger(typeof(Program)).Info("Started!");
    }
  }
}