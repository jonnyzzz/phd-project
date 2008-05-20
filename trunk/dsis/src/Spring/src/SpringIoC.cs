using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Spring;
using DSIS.Utils;
using log4net;
using Spring.Context;
using Spring.Context.Support;

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

    private readonly IApplicationContext myRootContext;
    private readonly IApplicationContext myContext;

    protected internal SpringIoC(params Assembly[] extra)
    {
      string rootResource = "assembly://" + GetType().Assembly.GetName().Name + "/" +
                            typeof (NamespaceHolder).Namespace + "/resources.spring.xml";
      myRootContext = new XmlApplicationContext(rootResource);

      var assemblies = new Hashset<Assembly>();
      var load = new List<Assembly>();

      load.AddRange(extra);
      load.Add(GetType().Assembly);
      load.Add(Assembly.GetCallingAssembly());
      load.Add(Assembly.GetExecutingAssembly());
      load.AddRange(AppDomain.CurrentDomain.GetAssemblies());
      
      ClosureAssemblies(load, assemblies);

      assemblies.Remove(GetType().Assembly);

      if (LOG.IsDebugEnabled)
      {
        foreach (Assembly assembly in assemblies)
        {
          LOG.DebugFormat("Spring assembly: {0}", assembly.FullName);
        }
      }

      var paths = new List<string>();
      foreach (Assembly assembly in assemblies)
      {
        string assemblyPath = assembly.GetName().Name;
        foreach (SpringConfigXmlAttribute attr in assembly.GetCustomAttributes(typeof (SpringConfigXmlAttribute), true))
        {
          string portion = string.Format("assembly://{0}/{1}/{2}", assemblyPath, attr.Namespace, attr.Location);
          LOG.InfoFormat("Config: {0}", portion);
          paths.Add(portion);
        }
      }

      myContext = new XmlApplicationContext(myRootContext, paths.ToArray());
    }

    private static void ClosureAssemblies(IEnumerable<Assembly> extra, Hashset<Assembly> assemblies)
    {
      var visit = new Hashset<Assembly>();
      var visited = new Hashset<Assembly>();
      var visitedNames = new Hashset<AssemblyName>();
      
      visit.AddRange(extra);

      while (visit.Count > 0)
      {        
        Assembly assembly = CollectionUtil.GetFirst(visit);
        visit.Remove(assembly);

        if (visited.Contains(assembly))
          continue;

        visited.Add(assembly);
        
        var refAssemblies = new List<AssemblyName>(assembly.GetReferencedAssemblies());

        foreach (SpringIncludeAssembly includeAssembly in assembly.GetCustomAttributes(typeof(SpringIncludeAssembly), true))
        {
          refAssemblies.Add(new AssemblyName(includeAssembly.Assembly));
        }

        foreach (AssemblyName name in refAssemblies)
        {          
          if (visitedNames.Contains(name))
            continue;
          visitedNames.Add(name);

          try
          {
            Assembly reference = Assembly.Load(name);
            if (reference != null && !assemblies.Contains(reference))
              visit.Add(reference);
          }
          catch (Exception e)
          {
             LOG.Error(e.Message, e);
          }
        }
        assemblies.Add(assembly);
      }
    }

    public T GetComponent<T>(string name)
    {
      return (T) myContext.GetObject(name, typeof (T));
    }

    public int Main(string[] args)
    {
      var names = myContext.GetObjectNamesForType(typeof(IApplicationEntryPoint));
      if (names.Length != 1)
      {
        throw new ArgumentException(typeof(IApplicationEntryPoint).FullName + " class should be defined only once");
      }

      return GetComponent<IApplicationEntryPoint>(names[0]).Main(args);
    }

    protected internal static void SetInsance(SpringIoC instance)
    {
      ourInstance = instance;
    }

    protected internal static void Dispose()
    {
      ourInstance.myRootContext.Dispose();
      ourInstance = null;
    }
  }
}