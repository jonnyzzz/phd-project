namespace DSIS.CodeCompiler
{
  public static class CodeCompiler
  {
    private static readonly ICodeCompiler ourInstance = new CodeCompilerImpl();

    public static ICodeCompiler CreateCompiler()
    {
      return ourInstance;
    }
  }
}
