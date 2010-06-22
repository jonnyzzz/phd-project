using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Antlr.StringTemplate;
using DSIS.CodeCompiler;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;

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
        GenerateMethod(sb, methodInfo, methodInfo.Name);
        GenerateMethod(sb, methodInfo, methodInfo.Name.ToLower());
        GenerateMethod(sb, methodInfo, methodInfo.Name.ToUpper());
      }
      sb.AppendLine("#endregion").AppendLine();
      return sb.ToString();      
    }

    private static void GenerateMethod(StringBuilder sb, MethodInfo methodInfo, string name)
    {
      sb.AppendFormat("private static {0} {1}(", methodInfo.ReturnType, name);
      sb.JoinString(methodInfo.GetParameters(), (x, i) => x.AppendFormat("{0} {1}", GeneratorTypeUtil.ParameterType(i), i.Name), ", ");
      sb.AppendFormat(") {{ return {1}.{0}(", methodInfo.Name, GeneratorTypeUtil.GenerateFQTypeName(typeof(Math)));
      sb.JoinString(methodInfo.GetParameters(), (x, i) => x.Append(i.Name ), ", ");
      sb.AppendLine("); }");
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

    private static readonly string START_CODE_MARKER = "User code range START.5C18387E-F066-45D4-94CA-86B3C59D3B22";
    private static readonly string END_CODE_MARKER = "User code range END.5C18387E-F066-45D4-94CA-86B3C59D3B22";

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
      template.SetAttribute("SystemType", GeneratorTypeUtil.EnumValue(paramz.SystemType));
      template.SetAttribute("PresentableName", GeneratorTypeUtil.SafeString(paramz.FunctionName));
      template.SetAttribute("startCodeMarker", START_CODE_MARKER);
      template.SetAttribute("endCodeMarker", END_CODE_MARKER);
      
      return template.ToString();
    }

    public Predicate<int> UserCodeRangeFilter(string code)
    {
      var noLines = new List<Pair<int, string>>();
      int id = 1;
      foreach (var line in code.Split('\n'))
      {
        noLines.Add(Pair.Create(id++, line));
      }

      int startLine = noLines.Where(x => x.Second.Contains(START_CODE_MARKER)).Map(x => x.First).First();
      int endLine =   noLines.Where(x => x.Second.Contains(END_CODE_MARKER)).Map(x => x.First).First();

      return x => x > startLine && x < endLine;
    }
  }
}