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
    private static readonly Dictionary<int, IBoxIterator<T>> myCaches 
      = new Dictionary<int, IBoxIterator<T>>();

    public static IBoxIterator<T> GenerateIterator(int dim)
    {
      IBoxIterator<T> result;
      lock (myCaches)
      {
        if (myCaches.TryGetValue(dim, out result))
          return result;
      }

      ICodeCompiler compiler = CodeCompiler.CodeCompiler.CreateCompiler();
      string clazz = "BoxIteratorGenerated";
      Assembly ass = compiler.CompileCSharpCode(GenerateIEnumerableFromT(clazz, dim),
                                                typeof (T), typeof (IBoxIterator<>), typeof (IEnumerable<>));

      result = (IBoxIterator<T>) Activator.CreateInstance(ass.GetType(clazz));
      lock (myCaches)
      {
        if (!myCaches.ContainsKey(dim))
          myCaches[dim] = result;
      }
      return result;
    }

    private static string GenerateIEnumerableFromT(string clazz, int dim)
    {
      string tClazz = GeneratorTypeUtil.GenerateFQTypeName<T>();
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
          ", clazz, tClazz, GenerateEnumeration(dim, tClazz));

      return code;
    }

    private static string GenerateEnumeration(int dim, string type)
    {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < dim; i++)
      {
        sb.AppendFormat("{1} left{0} = left[{0}];", i, type);
        sb.AppendLine();
        sb.AppendFormat("{1} right{0} = right[{0}];", i, type);
        sb.AppendLine();
        sb.AppendFormat("outs[{0}] = left{0};", i);
        sb.AppendLine();
      }      
      sb.AppendLine();
      sb.Append(@"yield return outs;");
      foreach (Pair<int, bool> pair in new ShennonFenoCodec(dim))
      {
        sb.AppendFormat("outs[{0}] = {1}{0};", pair.First, pair.Second ? "right" : "left");
        sb.AppendLine();
        sb.AppendLine("yield return outs;");
      }
      return sb.ToString();
    }

  }
}
