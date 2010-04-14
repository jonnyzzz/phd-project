using System;
using System.Collections.Generic;

namespace DSIS.Utils
{
  /// <summary>
  /// Implement this interface with IEqualityComparer&lt;&gt; to 
  /// have an ability to use inlined comparer for code generator
  /// </summary>
  public interface IGeneratorEqualityComparer
  {
    string GeneratePrivateMethods();
    string AreEqual(string v1, string v2);
    string Hashcode(string v);
  }
}