using System;
using System.Collections.Generic;
using System.Reflection;

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
      return t.FullName.Replace("+", ".");
    }

    public static string GenerateFQTypeInstance(Type t, params Type[] args)
    {
      if (t.IsGenericType)
      {
        string name = GenerateTypeName(t.GetGenericTypeDefinition());
        return GenerateGenericArguments(name, args);        
      }
      return GenerateFQTypeName(t);
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

    public static string ParameterType(ParameterInfo info)
    {
      //TODO: Check me
      var name = GenerateFQTypeName(info.ParameterType);

      if (info.IsIn && info.IsOut)
      {
        return "ref " + name;
      }

      if (info.IsOut)
      {
        return "out " + name;
      }

      return name;
    }

    public static string EnumValue(object t)
    {
      var type = t.GetType();
      return GenerateFQTypeName(type) + "." + Enum.GetName(type, t);
    }

    public static string SafeString(string s)
    {
      if (s == null)
      {
        return "\"<NA>\"";
      }
      return "@\"" + s.Replace("\"", "\"\"") + "\"";
    }
  }
}