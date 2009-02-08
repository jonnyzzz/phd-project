using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace DSIS.CodeCompiler
{
  public class CodeCompilerException : Exception
  {
    public readonly CompilerResults Results;
    public readonly string Code;
    private readonly IEnumerable<string> myAssemblies;

    public CodeCompilerException(CompilerResults results, string code, IEnumerable<string> assemblies)       
    {
      Results = results;
      Code = code;
      myAssemblies = assemblies;
    }

    public override string Message
    {
      get { return CreateMessage(); }
    }

    private string CreateMessage()
    {
      var sb = new StringBuilder();
      sb.AppendFormat("Compilation failed with code ").Append(Results.NativeCompilerReturnValue);      
      sb.AppendLine();
      foreach (CompilerError error in Results.Errors)
      {
        sb.AppendLine(error.ToString());
      }
      sb.AppendLine();
      sb.AppendLine("Code:");
      EnumerateLines(sb, x=>true);
      sb.AppendLine();
      sb.AppendLine("Assemblies:");
      foreach (string line in myAssemblies)
      {
        sb.AppendFormat("assembly: {0}", line).AppendLine();
      }
      return sb.ToString();
    }

    public string GetErrorsAndCode(Predicate<int> linesFilter)
    {
      var sb = new StringBuilder();
      EnumerateLines(sb, linesFilter);
      return sb.ToString();
    }

    public IEnumerable<CompilerError> Errors
    {
      get
      {
        foreach (CompilerError error in Results.Errors)
        {
          yield return error;
        }
      }
    }

    private void EnumerateLines(StringBuilder sb, Predicate<int> linesFilter)
    {
      var errorLines = new Dictionary<int, CompilerError>();
      foreach (CompilerError error in Errors)
      {
        if (!errorLines.ContainsKey(error.Line))
          errorLines[error.Line] = error;
      }

      const int INDENT = 7;
      int lineNumber = 1;
      foreach (string line in Code.Split('\n'))
      {
        if (linesFilter(lineNumber))
        {
          string lineNumS = lineNumber.ToString();

          if (errorLines.ContainsKey(lineNumber))
          {
            sb.Append("E ");
          }
          else
          {
            sb.Append("  ");
          }

          sb.Append(' ', Math.Max(0, INDENT - lineNumS.Length));
          sb.Append(lineNumS);
          sb.Append(": ");
          sb.AppendLine(line);

          if (errorLines.ContainsKey(lineNumber))
          {
            var error = errorLines[lineNumber];
            sb.Append('-', INDENT + 4 + error.Column - 1).Append("^").AppendLine();
            sb.Append(' ', INDENT + 4).Append(error.ErrorText).AppendLine();
          }
        }
        lineNumber++;
      }      
    }
  }
}