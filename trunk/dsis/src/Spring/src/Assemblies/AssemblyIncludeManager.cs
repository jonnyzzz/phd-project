using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Spring.Util;
using DSIS.Utils;
using log4net;

namespace DSIS.Spring.Assemblies
{
  [UsedBySpring]
  public class AssemblyIncludeManager : AbstractRegistry<IAssemblyLoadListener>, IAssemblyIncludeManager
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof(AssemblyIncludeManager));
    
    private readonly Hashset<Assembly> myAssemblies = new Hashset<Assembly>();

    public void RegisterAssemblyLoaded(IAssemblyLoadListener listener)
    {
      FireLoadedAssemblies(listener);
      Register(listener);
    }

    private void FireLoadedAssemblies(IAssemblyLoadListener listener)
    {
      foreach (var assembly in myAssemblies)
      {
        listener.AssemblyLoaded(assembly);
      }
    }

    private bool ContainsAssembly(Assembly assembly)
    {
      return myAssemblies.Contains(assembly);
    }

    private void AddAssembly(Assembly assembly)
    {
      if (myAssemblies.Contains(assembly))
        return;

      if (!assembly.GetName().FullName.StartsWith("DSIS"))
        return;

      myAssemblies.Add(assembly);
      ForEach(x => x.AssemblyLoaded(assembly));
    }

    public void RegisterAssembly(IEnumerable<Assembly> assemblies)
    {
      ClosureAssemblies(assemblies);
    }

    private void ClosureAssemblies(IEnumerable<Assembly> extra)
    {
      var visit = new Hashset<Assembly>();
      var visited = new Hashset<Assembly>();
      var visitedNames = new Hashset<AssemblyName>();
      
      visit.AddRange(extra);

      while (visit.Count > 0)
      {        
        Assembly assembly = visit.GetFirst();
        visit.Remove(assembly);

        if (visited.Contains(assembly))
          continue;

        visited.Add(assembly);
        
        var refAssemblies = new List<AssemblyName>(assembly.GetReferencedAssemblies());

        foreach (IncludeAssemblyAttribute includeAssembly in assembly.GetCustomAttributes(typeof(IncludeAssemblyAttribute), true))
        {
          refAssemblies.Add(new AssemblyName(includeAssembly.Assembly));
        }

        foreach (AssemblyName name in refAssemblies)
        {          
          if (visitedNames.Contains(name))
            continue;
          visitedNames.Add(name);

          if (name.FullName.StartsWith("DSIS"))
          {
            try
            {
              Assembly reference = Assembly.Load(name);
              if (reference != null && !ContainsAssembly(reference))
                visit.Add(reference);
            }

            catch (Exception e)
            {
              LOG.Error(e.Message, e);
            }
          } 
        }
        AddAssembly(assembly);
      }
    }
  }
}