using System;

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
        string name = GenerateTypeName(t.GetGenericTypeDefinition()) + "<";
        bool isFirst = true;
        foreach (Type type in t.GetGenericArguments())
        {
          if (!isFirst) name += ", ";
          isFirst = false;
          name += GenerateFQTypeName(type);
        }
        return name + "> ";        
      }
      return t.FullName;
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