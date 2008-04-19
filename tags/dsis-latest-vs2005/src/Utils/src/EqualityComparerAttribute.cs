using System;

namespace DSIS.Utils
{
  [AttributeUsage(AttributeTargets.Class |  AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface, AllowMultiple = false)]
  public class EqualityComparerAttribute : Attribute
  {
    public readonly Type Comparer;

    public EqualityComparerAttribute(Type comparer)
    {
      Comparer = comparer;
    }
  }
}