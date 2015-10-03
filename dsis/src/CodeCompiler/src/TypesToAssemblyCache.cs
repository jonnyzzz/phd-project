using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Utils;

namespace DSIS.CodeCompiler
{
  public class TypesToAssemblyCache
  {
    private readonly Dictionary<Type, string[]> myTypeToAssemblyCache = new Dictionary<Type, string[]>();

    protected void CollectAssemblies(Type type, Hashset<string> set, Hashset<Type> visited)
    {
      if (type == null || type.IsGenericParameter)
        return;

      if (visited.Contains(type))
        return;

      string[] result;
      if (myTypeToAssemblyCache.TryGetValue(type, out result))
      {
        set.AddRange(result);
      }
      else
      {
        visited.Add(type);
        Closure(type.Assembly, set);

        if (type.IsGenericType && !type.IsGenericTypeDefinition)
        {
          foreach (Type t in type.GetGenericArguments())
          {
            if (type.IsGenericTypeDefinition)
            {
              foreach (Type tt in type.GetGenericParameterConstraints())
              {
                CollectAssemblies(tt, set, visited);
              }
            }
            else
            {
              CollectAssemblies(t, set, visited);
            }
          }
        }

        foreach (Type t in type.GetInterfaces())
        {
          CollectAssemblies(t, set, visited);
        }

        CollectAssemblies(type.BaseType, set, visited);
      }
    }

    private static void Closure(Assembly assembly, Hashset<string> result)
    {
      if (assembly.GlobalAssemblyCache)
        return;

      string location = assembly.Location;
      if (string.IsNullOrEmpty(location))
        throw new ArgumentException("Unable to get assembly for assembly " + assembly.FullName);

      result.Add(location);
      foreach (AssemblyName name in assembly.GetReferencedAssemblies())
      {
        string refLocation = Assembly.Load(name).Location;
        result.Add(refLocation);

        if (string.IsNullOrEmpty(refLocation))
          throw new ArgumentException("Unable to get assembly for assembly " + name.FullName);
      }
    }

    protected string[] AssembliesForType(Type t)
    {
      string[] result;
      if (myTypeToAssemblyCache.TryGetValue(t, out result))
        return result;

      Hashset<string> resultSet = new Hashset<string>();
      CollectAssemblies(t, resultSet, new Hashset<Type>());

      result = resultSet.ToArray();

      myTypeToAssemblyCache[t] = result;

      return result;
    }

    public string[] CollectAssemblies(params Type[] types)
    {
      lock(myTypeToAssemblyCache)
      {
        Hashset<string> set = new Hashset<string>();
        foreach (Type type in types)
        {
          set.AddRange(AssembliesForType(type));
        }
        return set.ToArray();
      }
    }


  }
}