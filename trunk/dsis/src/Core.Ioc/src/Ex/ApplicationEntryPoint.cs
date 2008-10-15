using System.Reflection;

namespace DSIS.Core.Ioc.Ex
{
  public static class ApplicationEntryPoint
  {
    public static int DoMain(string[] args)
    {
      using (var rootContainer = new ComponentContainer<ComponentInterfaceAttribute, ComponentCollectionAttribute, ComponentImplementationAttribute>())
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
