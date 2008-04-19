using System;

namespace DSIS.CodeCompiler.EqualityFactory
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, AllowMultiple = false)]
  public class GeneratorEqualityComparerAttribute : Attribute
  {
    public readonly Type Comparer;

    public GeneratorEqualityComparerAttribute(Type comparer)
    {
      Comparer = comparer;
    }
  }
}