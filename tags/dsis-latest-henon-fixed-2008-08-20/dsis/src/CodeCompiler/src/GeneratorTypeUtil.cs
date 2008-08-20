using System;
using System.Collections.Generic;

namespace DSIS.CodeCompiler
{
  public static class GeneratorTypeUtil
  {
    public static string GenerateFQTypeName<T>()
    {
      Type t = typeof (T);
      return GenerateFQTypeName(t);
    }

    public static string GenerateFQTypeName(Type t)
    {
      if (t.IsGenericType)
      {
        string name = GenerateTypeName(t.GetGenericTypeDefinition());
        return GenerateGenericArguments(name, t.GetGenericArguments());
      }
      return t.FullName;
    }

    public static string GenerateFQTypeInstance(Type t, params Type[] args)
    {
      if (t.IsGenericType)
      {
        string name = GenerateTypeName(t.GetGenericTypeDefinition());
        return GenerateGenericArguments(name, args);        
      } else
      {
        return GenerateFQTypeName(t);
      }
    }

    private static string GenerateGenericArguments(string name, IEnumerable<Type> arguments)
    {
      name+= "<";
      bool isFirst = true;        
      foreach (Type type in arguments)
      {
        if (!isFirst) name += ", ";
        isFirst = false;
        name += GenerateFQTypeName(type);
      }
      return name + "> ";
    }

    private static string GenerateTypeName(Type t)
    {
      string name = t.Name;
      int index = name.IndexOf('`');
      if (index > 0) 
        name = name.Substring(0, index);

      return t.Namespace + "." + name;
    }
  }
}