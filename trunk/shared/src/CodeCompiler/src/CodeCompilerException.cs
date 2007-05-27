using System;
using System.CodeDom.Compiler;
using System.Text;

namespace DSIS.CodeCompiler
{
  public class CodeCompilerException : Exception
  {
    public readonly CompilerResults Results;

    public CodeCompilerException(CompilerResults results) : base(CreateMessage(results))
    {
      Results = results;
    }

    public static string CreateMessage(CompilerResults results)
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendFormat("Compilation failed with code {0}", results.NativeCompilerReturnValue);
      sb.AppendLine();
      foreach (object error in results.Errors)
      {
        sb.AppendLine(error.ToString());
      }
      return sb.ToString();
    }
  }
}