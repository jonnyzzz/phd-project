using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.CodeCompiler.EqualityFactory
{
  public class DefaultGeneratorEqualityComparer<T> : IGeneratorEqualityComparer {
    public string GeneratePrivateMethods()
    {
      return string.Format("private static readonly {0} GEN_CMP = {1}.GetComparer();",
                           GeneratorTypeUtil.GenerateFQTypeName<IEqualityComparer<T>>(),
                           GeneratorTypeUtil.GenerateFQTypeName<EqualityComparerFactory<T>>());
    }

    public string AreEqual(string v1, string v2)
    {
      return string.Format("(GEN_CMP.Equals({0}, {1}))", v1, v2);
    }

    public string Hashcode(string v)
    {
      return string.Format("(GEN_CMP.GetHashCode({0}))", v);
    }
  }
}