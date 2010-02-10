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

    public AssemblyIncludeManager()
    {
      AppDomain.CurrentDomain.AssemblyLoad += (o, x) => RegisterAssemblies(new[] {x.LoadedAssembly});
    }

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

    public void RegisterAssemblies(IEnumerable<Assembly> assemblies)
    {
      ClosureAssemblies(assemblies);
    }

    private void ClosureAssemblies(IEnumerable<Assembly> extra)
    {
      var visit = new Hashset<Assembly>();
      
      visit.AddRange(extra);
      while (visit.Count > 0)
      {        
        Assembly assembly = visit.GetFirst();
        visit.Remove(assembly);

        LOG.DebugFormat("Scan assembly: {0}", assembly.FullName);

        if (ContainsAssembly(assembly))
          continue;

        AddAssembly(assembly);
        
        var refAssemblies = new List<AssemblyName>(assembly.GetReferencedAssemblies());

        foreach (IncludeAssemblyAttribute includeAssembly in assembly.GetCustomAttributes(typeof(IncludeAssemblyAttribute), true))
        {
          refAssemblies.Add(new AssemblyName(includeAssembly.Assembly));
        }

        foreach (var name in refAssemblies)
        {          
          LOG.DebugFormat("Scan ref: {0}", name);
          if (name.FullName.StartsWith("DSIS"))
          {
            try
            {
              var reference = Assembly.Load(name);
              if (reference != null && !ContainsAssembly(reference))
              {
                visit.Add(reference);
              }
            }
            catch (Exception e)
            {
              LOG.Error(e.Message, e);
            }
          } 
        }
      }
    }
  }
}