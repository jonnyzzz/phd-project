using System;
using System.CodeDom.Compiler;
using System.Text;  
using DSIS.Utils;

namespace DSIS.CodeCompiler
{
  public class CodeCompilerException : Exception
  {
    public readonly CompilerResults Results;

    public CodeCompilerException(CompilerResults results, string code) : base(CreateMessage(results, code))
    {
      Results = results;
    }

    private static string CreateMessage(CompilerResults results, string code)
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendFormat("Compilation failed with code ").Append(results.NativeCompilerReturnValue);      
      sb.AppendLine();
      Hashset<int> errorLines = new Hashset<int>();
      foreach (CompilerError error in results.Errors)
      {
        sb.AppendLine(error.ToString());
        errorLines.Add(error.Line);
      }
      sb.AppendLine();
      sb.AppendLine("Code:");
      EnumerateLines(code, sb, errorLines);
      sb.AppendLine();      
      return sb.ToString();
    }

    private static void EnumerateLines(string code, StringBuilder sb, Hashset<int> errorLines)
    {
      const int INDENT = 7;
      int lineNumber = 1;
      foreach (string line in code.Split('\n'))
      {
        string lineNumS = lineNumber.ToString();

        if (errorLines.Contains(lineNumber))
        {
          sb.Append("E ");
        } else
        {
          sb.Append("  ");
        }

        sb.Append(' ', Math.Max(0, INDENT - lineNumS.Length));
        sb.Append(lineNumS);
        sb.Append(": ");
        sb.AppendLine(line);

        lineNumber++;
      }      
    }
  }
}