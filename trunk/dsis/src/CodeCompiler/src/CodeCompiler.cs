using System;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.CodeCompiler
{
  [Obsolete("Use IoC")]
  [ComponentImplementation]
  public class CodeCompiler
  {
    private static ICodeCompiler ourInstance = new CodeCompilerImpl(new CodeCompilerFilenameGenerator());

    [Autowire]
    private ICodeCompiler CodeCompilerX
    {
      get { return ourInstance; }
      set { ourInstance = value;}
    }

    [Obsolete("Use IoC")]
    public static ICodeCompiler CreateCompiler()
    {
      return ourInstance ?? (ourInstance = new CodeCompilerImpl(new CodeCompilerFilenameGenerator()));
    }
  }
}
