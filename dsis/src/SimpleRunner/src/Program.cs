using System.Globalization;
using System.Threading;
using DSIS.SimpleRunner.Entropy;
using DSIS.SimpleRunner.ImageEntropy;
using EugenePetrenko.Core.Ioc.EntryPoint;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.SimpleRunner
{
  [ComponentImplementation]
  public class Program : IApplication
  {
    [Autowire]
    private ImageEntropyBuilder myEntropyBuilder { get; set; }

    [Autowire]
    private Osipenko2015Build myOsipenko2015 { get; set; }

    public int Main()
    {
//      new ThesisJVREntropyBuild().Action();
      //      new ThesisCurveBuild().Action();
      //      new ThesisEntropyBuild().Action();
    //        new ThesisSIBuild().Action();
            //new SIBuild().Action();
//            new JVRDetMorseBuild().Action();
            //new JVRBuild().Action();

      //myEntropyBuilder.Action();

      myOsipenko2015.Action();

      return 0;
    }

    public static void Main(string[] args)
    {
      Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
      Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");

      ApplicationEntryPoint<Program>.DoMain(args);
    }
  }
}