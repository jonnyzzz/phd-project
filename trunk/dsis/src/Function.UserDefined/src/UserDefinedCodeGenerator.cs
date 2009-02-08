using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Antlr.StringTemplate;
using DSIS.CodeCompiler;
using DSIS.Core.Ioc;
using DSIS.Utils;

namespace DSIS.Function.UserDefined
{
  [ComponentImplementation]
  public class UserDefinedCodeGenerator : IUserDefinedCodeGenerator
  {
    private static readonly HashSet<string> IMPORTS = new HashSet<string>(new CaseInsensitiveEqualityComparer())
                                                        {
                                                          "sqrt",
                                                          "acos",
                                                          "asin",
                                                          "atan",
                                                          "atan2",
                                                          "ceiling",
                                                          "floor",
                                                          "cos",
                                                          "cosh",
                                                          "sin",
                                                          "tan",
                                                          "sinh",
                                                          "tanh",
                                                          "round",
                                                          "pow",
                                                          "log",
                                                          "log10",
                                                          "exp",
                                                          "abs",
                                                          "sign",
                                                          "min",
                                                          "max",
                                                          "round",
                                                          "truncate"
                                                        };

    public string GenerateMathRedefinitions()
    {
      var sb = new StringBuilder();
      sb.AppendLine();
      sb.AppendLine("#region Generated Math calls");
      
      foreach (var methodInfo in typeof(Math).GetMethods(BindingFlags.Static|BindingFlags.Public).Where(x=>IMPORTS.Contains(x.Name)))
      {
        string name = methodInfo.Name;
        
        sb.AppendFormat("private {0} {1}(", methodInfo.ReturnType, name);
        sb.JoinString(methodInfo.GetParameters(), (x, i) => x.AppendFormat("{0} {1}", GeneratorTypeUtil.ParameterType(i), i.Name), ", ");
        sb.AppendFormat(") {{ return {1}.{0}(", name, GeneratorTypeUtil.GenerateFQTypeName(typeof(Math)));
        sb.JoinString(methodInfo.GetParameters(), (x, i) => x.Append(i.Name ), ", ");
        sb.AppendLine("); }");
      }
      sb.AppendLine("#endregion").AppendLine();
      return sb.ToString();      
    }

    private class NP
    {
      public int N { get; private set; }
      public int P { get { return N - 1; } }

      public NP(int n)
      {
        N = n;
      }
    }

    public string GenerateCode(UserFunctionParameters paramz)
    {
      var dim = paramz.Dimension;

      if (dim <= 0)
        throw new UserDefinedFactoryException("Dimension should be positive");

      var dims = new List<NP>();
      for (int i = 0; i < dim; i++)
      {
        dims.Add(new NP(i+1));
      }


      var g = new StringTemplateGroup(
        "foo", 
        new EmbeddedResourceTemplateLoader(
          GetType().Assembly,
          "DSIS.Function.UserDefined.template")
          );

      var template = g.GetInstanceOf("GeneratedFunction");
      template.SetAttribute("Dimension", dim);
      template.SetAttribute("DimensionIt", dims);
      template.SetAttribute("userCode", paramz.Code);
      template.SetAttribute("predefines", GenerateMathRedefinitions());

      return template.ToString();
    }
  }
}