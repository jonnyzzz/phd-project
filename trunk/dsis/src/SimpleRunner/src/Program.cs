using System.Globalization;
using System.Threading;
using EugenePetrenko.Core.Ioc.EntryPoint;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.SimpleRunner
{
  [ComponentImplementation]
  public class Program : IApplication
  {
    public int Main()
    {
//      new ThesisJVREntropyBuild().Action();
      //      new ThesisCurveBuild().Action();
      //      new ThesisEntropyBuild().Action();
            new ThesisSIBuild().Action();
//            new SIBuild().Action();
//            new JVRDetMorseBuild().Action();
      //      new JVRBuild().Action();

      return 0;
    }

    public static void Main(string[] args)
    {
      ApplicationEntryPoint<Program>.DoMain(args);

      Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
      Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
    }
  }
}