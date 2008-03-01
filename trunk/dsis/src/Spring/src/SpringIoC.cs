using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Spring;
using DSIS.Utils;
using log4net;
using Spring.Context;
using Spring.Context.Support;

[assembly: SpringConfigXml("resources.spring.xml", typeof(SpringIoC))]
namespace DSIS.Spring
{
  public class SpringIoC
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (SpringIoC));

    private static SpringIoC ourInstance;

    public static SpringIoC Instance
    {
      get { return ourInstance; }
    }

    private readonly IApplicationContext myContext;

    internal protected SpringIoC(params Assembly[] extra)
    {
      Hashset<Assembly> assemblies = new Hashset<Assembly>();
      Hashset<Assembly> visit = new Hashset<Assembly>();

      visit.Add(GetType().Assembly);
      visit.Add(Assembly.GetCallingAssembly());
      visit.Add(Assembly.GetEntryAssembly());
      visit.Add(Assembly.GetExecutingAssembly());
      visit.AddRange(AppDomain.CurrentDomain.GetAssemblies());
      visit.AddRange(extra);

      while (visit.Count > 0)
      {
        Assembly assembly = CollectionUtil.GetFirst(visit);
        visit.Remove(assembly);

        foreach (AssemblyName name in assembly.GetReferencedAssemblies())
        {
          Assembly reference = Assembly.Load(name);
          if (reference != null && !assemblies.Contains(reference))
          {
            visit.Add(reference);
          }
        }
        assemblies.Add(assembly);
      }

      if (LOG.IsDebugEnabled)
      {
        foreach (Assembly assembly in assemblies)
        {
          LOG.DebugFormat("Spring assembly: {0}", assembly.FullName);
        }
      }

      List<string> paths = new List<string>();
      foreach (Assembly assembly in assemblies)
      {
        string assemblyPath = assembly.GetName().Name;
        foreach (SpringConfigXmlAttribute attr in assembly.GetCustomAttributes(typeof(SpringConfigXmlAttribute), true))
        {
          string portion = string.Format("assembly://{0}/{1}/{2}", assemblyPath, attr.Namespace, attr.Location);
          LOG.InfoFormat("Config: {0}", portion);
          paths.Add(portion);
        }
      }

      myContext = new XmlApplicationContext(paths.ToArray());
    }

    public object this[string name]
    {
      get { return myContext[name]; }      
    }

    protected internal static void SetInsance(SpringIoC instance)
    {
      ourInstance = instance;
    }
  }
}
