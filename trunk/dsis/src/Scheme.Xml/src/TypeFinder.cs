using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Utils;

namespace DSIS.Scheme.Xml
{
  public class TypeFinder : IDisposable
  {
    private readonly List<Assembly> myAssemblies = new List<Assembly>();

    public void Dispose()
    {
    }

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
      foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().Join((IEnumerable<Assembly>)myAssemblies))
      {
        var type = assembly.GetType(clazz);
        if (type != null)
          return type;
      }
      throw new Exception("Class not found: " + clazz);
    }
  }
}