using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DSIS.Spring.Assemblies;
using DSIS.Spring.Config;
using log4net;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;
using IServiceProvider=DSIS.Spring.Service.IServiceProvider;

namespace DSIS.Spring
{
  [UsedBySpring]
  public class SpringIoC : IApplicationContextAware, IInitializingObject, IDisposable
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (SpringIoC));

    private readonly IServiceProvider myServiceProvider;
    private IApplicationContext myChildContext;

    public IApplicationContext ApplicationContext { get; set; }

    public SpringIoC(IServiceProvider serviceProvider)
    {
      myServiceProvider = serviceProvider;
    }

    public void AfterPropertiesSet()
    {
    }

    public void Start() 
    {
      var load = new List<Assembly>
                   {
                     typeof (SpringIoCSetup).Assembly,
                     Assembly.GetCallingAssembly(),
                     Assembly.GetExecutingAssembly()
                   };
      load.AddRange(AppDomain.CurrentDomain.GetAssemblies());

      if (LOG.IsInfoEnabled)
      {
        using (NDC.Push("Assemblies: "))
        {
          List<string> lll = load.ConvertAll(x => x.FullName);
          lll.Sort((x,y) => x.ToLower().CompareTo(y.ToLower()));
          foreach (var assembly in lll)
          {
            LOG.InfoFormat("{0}", assembly);
          }
        }
      }

      var includeManager = myServiceProvider.GetService<IAssemblyIncludeManager>();
      includeManager.RegisterAssemblies(load);

      //NOTE: The idea here is to split intializing context from Application context.
      var configurationLocations = myServiceProvider
        .GetService<SpringConfigRegistry>()
        .GetSpringConfigPaths()
        .ToArray();

      if (LOG.IsInfoEnabled)
      {
        using (NDC.Push("Config: "))
        {
          foreach (var cfg in configurationLocations)
          {
            LOG.InfoFormat("{0}", cfg);
          }
        }
      }

      var context = new XmlApplicationContext(ApplicationContext, configurationLocations);
      myChildContext = context;
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
      return myServiceProvider.GetService<Q>().Main(args);
    }
  }
}