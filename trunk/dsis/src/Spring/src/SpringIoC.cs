using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DSIS.Spring.Assemblies;
using DSIS.Spring.Config;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;
using IServiceProvider=DSIS.Spring.Service.IServiceProvider;

namespace DSIS.Spring
{
  [UsedBySpring]
  public class SpringIoC : IApplicationContextAware, IInitializingObject, IDisposable
  {
    private readonly IServiceProvider myServiceProvider;
    private IApplicationContext myChildContext;

    public IApplicationContext ApplicationContext { get; set; }

    public SpringIoC(IServiceProvider serviceProvider)
    {
      myServiceProvider = serviceProvider;
    }

    public void AfterPropertiesSet()
    {
      var load = new List<Assembly>
                   {
                     typeof (SpringIoCSetup).Assembly,
                     Assembly.GetCallingAssembly(),
                     Assembly.GetExecutingAssembly()
                   };
      load.AddRange(AppDomain.CurrentDomain.GetAssemblies());

      var includeManager = myServiceProvider.GetService<IAssemblyIncludeManager>();
      includeManager.RegisterAssembly(load);

      //NOTE: The idea here is to split intializing context from Application context.
      myChildContext = new XmlApplicationContext(ApplicationContext,
                                                 myServiceProvider.GetService<SpringConfigRegistry>().
                                                   GetSpringConfigPaths().ToArray());
    }

    public void Dispose()
    {
      if (myChildContext != null)
      {
        myChildContext.Dispose();
        myChildContext = null;
      }
    }


    public int AsMain<Q>(string[] args, params Assembly[] extra)
      where Q : IApplicationEntryPoint
    {
      var names = myChildContext.GetObjectNamesForType(typeof (Q));
      if (names.Length != 1)
      {
        throw new ArgumentException(typeof (Q).FullName + " class should be defined only once");
      }

      return ((Q) myChildContext.GetObject(names[0])).Main(args);
    }
  }
}