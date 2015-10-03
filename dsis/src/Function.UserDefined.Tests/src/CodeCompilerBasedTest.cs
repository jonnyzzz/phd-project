using DSIS.CodeCompiler;

namespace DSIS.Function.UserDefined.Tests
{
  public class CodeCompilerBasedTest
  {
    protected ICodeCompiler Compiler { get { return new CodeCompilerImpl(new CodeCompilerFilenameGenerator()); } }
  }
}