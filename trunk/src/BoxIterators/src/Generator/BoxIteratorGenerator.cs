using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using DSIS.CodeCompiler;
using DSIS.Core.Util;

namespace DSIS.BoxIterators.Generator
{
  public static class BoxIteratorGenerator<T>
  {
    private static Dictionary<int, IBoxIterator<T>> myCaches = new Dictionary<int, IBoxIterator<T>>();

    public static IBoxIterator<T> GenerateIterator(int dim)
    {
      IBoxIterator<T> result;
      if (!myCaches.TryGetValue(dim, out result))
      {
        ICodeCompiler compiler = CodeCompiler.CodeCompiler.CreateCompiler();
        string clazz = "BoxIteratorGenerated";
        Assembly ass = compiler.CompileCSharpCode(GenerateIEnumerableFromT(clazz, dim), 
          typeof (T), typeof (IBoxIterator<>), typeof (IEnumerable<>));

        result = (IBoxIterator<T>) Activator.CreateInstance(ass.GetType(clazz));
        myCaches[dim] = result;
      }

      return result;
    }

    private static string GenerateIEnumerableFromT(string clazz, int dim)
    {
      string code =
        string.Format(
          @"
         using System;
         using System.Collections;
         using System.Collections.Generic;
         using DSIS.BoxIterators;

         public class {0} : IBoxIterator<{1}> {{
              public IEnumerable<{1}[]> EnumerateBox({1}[] left, {1}[] right, {1}[] outs) {{
                 {2}
              }}
         }}
          ", clazz, typeof(T).FullName, GenerateEnumeration(dim));

      return code;
    }

    private static string GenerateEnumeration(int dim)
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendFormat(@"Array.Copy(left, outs, {0});", dim);
      sb.AppendLine();
      sb.Append(@"yield return outs;");
      foreach (Pair<int, bool> pair in new ShennonFenoCodec(dim))
      {
        sb.AppendFormat("outs[{0}] = {1}[{0}];", pair.First, pair.Second ? "right" : "left");
        sb.AppendLine();
        sb.AppendLine("yield return outs;");
      }
      return sb.ToString();
    }

  }
}
