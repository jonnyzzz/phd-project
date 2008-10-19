using System.Reflection;
using DSIS.Core.Ioc.JC;

namespace DSIS.Core.Ioc.Ex
{
  public static class ApplicationEntryPoint
  {
    public static int DoMain(string[] args)
    {
      //ComponentInterfaceAttribute, ComponentCollectionAttribute, 
      using (var rootContainer = new JComponentContainer<ComponentImplementationAttribute>())
      { 
        rootContainer.ScanAssemblies(new[] { Assembly.GetCallingAssembly(), Assembly.GetEntryAssembly(), Assembly.GetExecutingAssembly()});

        new ScanCurrentFolder(rootContainer);
        new AppDomainSubscription(rootContainer);

        rootContainer.RegisterComponent(new CommandLineImpl(args));

        rootContainer.Start();
        
        var app = rootContainer.GetComponent<IApplication>();
        return app.Main();
      }
    }
  }
}
