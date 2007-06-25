using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;  

namespace DSIS.CodeCompiler
{
  public class CodeCompilerException : Exception
  {
    public readonly CompilerResults Results;

    public CodeCompilerException(CompilerResults results, string code, string[] assemblies) : base(CreateMessage(results, code, assemblies))
    {
      Results = results;
      }

    private static string CreateMessage(CompilerResults results, string code, string[] assemblies)
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendFormat("Compilation failed with code ").Append(results.NativeCompilerReturnValue);      
      sb.AppendLine();
      Dictionary<int, int> errorLines = new Dictionary<int, int>();
      foreach (CompilerError error in results.Errors)
      {
        sb.AppendLine(error.ToString());
        if (!errorLines.ContainsKey(error.Line))
          errorLines[error.Line] = error.Column;
      }
      sb.AppendLine();
      sb.AppendLine("Code:");
      EnumerateLines(code, sb, errorLines);
      sb.AppendLine();
      sb.AppendLine("Assemblies:");
      foreach (string line in assemblies)
      {
        sb.AppendFormat("assembly: {0}", line).AppendLine();
      }
      return sb.ToString();
    }

    private static void EnumerateLines(string code, StringBuilder sb, Dictionary<int, int> errorLines)
    {
      const int INDENT = 7;
      int lineNumber = 1;
      foreach (string line in code.Split('\n'))
      {
        string lineNumS = lineNumber.ToString();

        if (errorLines.ContainsKey(lineNumber))
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

        if (errorLines.ContainsKey(lineNumber))
        {
          sb.Append('-', INDENT + 4 + errorLines[lineNumber] - 1).Append("^").AppendLine( );
        } 

        lineNumber++;
      }      
    }
  }
}