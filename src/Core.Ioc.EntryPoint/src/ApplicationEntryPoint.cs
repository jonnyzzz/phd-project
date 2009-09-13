using System.Reflection;
using EugenePetrenko.Shared.Core.Ioc;
using EugenePetrenko.Shared.Core.Ioc.Api;
using EugenePetrenko.Shared.Core.Ioc.JC;

namespace EugenePetrenko.Core.Ioc.EntryPoint
{
  public static class ApplicationEntryPoint<T> where T : IApplication
  {
    public static int DoMain(string[] args)
    {     
      using (var rootContainer = new JComponentContainer<ComponentImplementationAttribute>())
      {
        var assemblies = new[]
                           {
                             Assembly.GetCallingAssembly(), 
                             Assembly.GetEntryAssembly(), 
                             Assembly.GetExecutingAssembly()
                           };
        rootContainer.ScanAssemblies(assemblies);

        new ScanCurrentFolder(rootContainer);
        new AppDomainSubscription(rootContainer);

        rootContainer.RegisterComponent(new CommandLineImpl(args));

        rootContainer.Start();

        var app = rootContainer.GetComponent<T>();
        return app.Main();
      }
    }
  }
}