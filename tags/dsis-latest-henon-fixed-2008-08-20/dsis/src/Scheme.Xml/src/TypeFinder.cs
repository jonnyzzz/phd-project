using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Utils;

namespace DSIS.Scheme.Xml
{
  public class TypeFinder : IDisposable
  {
    private readonly List<Assembly> myAssemblies = new List<Assembly>();

    public TypeFinder()
    {
      myAssemblies.AddRange(AppDomain.CurrentDomain.GetAssemblies());
      AppDomain.CurrentDomain.AssemblyLoad += OnAssemblyLoadEvent;
    }

    public void Dispose()
    {
      AppDomain.CurrentDomain.AssemblyLoad -= OnAssemblyLoadEvent;
    }

    private void OnAssemblyLoadEvent(object x, AssemblyLoadEventArgs a)
    { myAssemblies.Add(a.LoadedAssembly); }

    public void LoadAssembliesFromXml(IncludeAssemblies ass)
    {
      if (ass != null)
      {
        foreach (var s in ass.Assembly ?? EmptyArray<string>.Instance)
        { 
          myAssemblies.Add(Assembly.Load(s));
        }
      }
    }

    public Type Find(string clazz)
    {
      clazz = clazz.Trim();
      foreach (var assembly in myAssemblies)
      {
        var type = assembly.GetType(clazz);
        if (type != null)
          return type;
      }
      throw new Exception("Class not found");
    }
  }
}