using System;

namespace DSIS.CodeCompiler
{
  [Obsolete("Use IoC")]
  public static class CodeCompiler
  {
    private static readonly ICodeCompiler ourInstance = new CodeCompilerImpl(new CodeCompilerFilenameGenerator());

    public static ICodeCompiler CreateCompiler()
    {
      return ourInstance;
    }
  }
}
