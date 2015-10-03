using System;
using DSIS.CodeCompiler.EqualityFactory;
using DSIS.Utils;

namespace DSIS.CodeCompiler.EqualityFactory
{
  public class GeneratedEqualityComparerFactory<T> : AttributeUtil<T>
  {
    private static IGeneratorEqualityComparer myComparer = null;

    public static IGeneratorEqualityComparer GetComparer()
    {
      if (myComparer != null)
        return myComparer;

      Type type = typeof(T);
      if (type == typeof(int))
      {
        myComparer = IntGeneratorEqualityComparer.INSTANCE;
      }
      else if (type == typeof(long))
      {
        myComparer = LongGeneratorEqualityComparer.INSTANCE;
      }
      else if (type == typeof(double) || type.IsEnum)
      {
        myComparer = DefaultEqEqualityComparer.INSTACE;
      }
      else
      {
        GeneratorEqualityComparerAttribute at = GetAttributeInstance<GeneratorEqualityComparerAttribute>();
        if (at != null)
        {
          Type comparer;
          if (at.Comparer.IsGenericTypeDefinition && typeof(T).IsGenericType)
          {
            comparer = at.Comparer.MakeGenericType(typeof(T).GetGenericArguments());
          }
          else
          {
            comparer = at.Comparer;
          }
          myComparer = (IGeneratorEqualityComparer) Activator.CreateInstance(comparer);
        }
        else
        {
          myComparer = new DefaultGeneratorEqualityComparer<T>();
        }        
      }

      return myComparer;
    }
  }

  public class IntGeneratorEqualityComparer : EqEqGeneratorEqualityComparer, IGeneratorEqualityComparer
  {
    public static readonly IGeneratorEqualityComparer INSTANCE = new IntGeneratorEqualityComparer();

    public string Hashcode(string v)
    {
      return v;
    }
  }

  public class LongGeneratorEqualityComparer : EqEqGeneratorEqualityComparer, IGeneratorEqualityComparer
  {
    public static readonly IGeneratorEqualityComparer INSTANCE = new LongGeneratorEqualityComparer();

    public string Hashcode(string v)
    {
      return string.Format("((int){0} | (int)({0} >> 32))", v);
    }
  }

  public class DefaultEqEqualityComparer : EqEqGeneratorEqualityComparer, IGeneratorEqualityComparer
  {
    public static readonly IGeneratorEqualityComparer INSTACE = new DefaultEqEqualityComparer();

    public string Hashcode(string v)
    {
      return string.Format("{0}.GetHashCode()", v);
    }
  }
}