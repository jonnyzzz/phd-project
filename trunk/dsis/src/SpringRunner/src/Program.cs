using DSIS.Spring;
using log4net;

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