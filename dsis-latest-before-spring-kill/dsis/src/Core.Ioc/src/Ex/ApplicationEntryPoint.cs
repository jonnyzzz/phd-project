using System.Reflection;
using DSIS.Core.Ioc.JC;
using DSIS.Utils;

namespace DSIS.Core.Ioc.Ex
{
  [Used]
  public class ApplicationEntryPoint : ApplicationEntryPoint<IApplication>
  {
  } 
  
  public class ApplicationEntryPoint<T> where T : IApplication
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
        
        var app = rootContainer.GetComponent<T>();
        return app.Main();
      }
    }
  }
}
