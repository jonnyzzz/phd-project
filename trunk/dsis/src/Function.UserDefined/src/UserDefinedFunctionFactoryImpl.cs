using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.CodeCompiler;
using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.Function.Predefined;
using DSIS.Utils;

namespace DSIS.Function.UserDefined
{
  [ComponentImplementation]
  public class UserDefinedFunctionFactoryImpl : IUserDefinedFunctionFactory
  {
    [Autowire]
    public IUserDefinedCodeGenerator CodeGen { get; set; }

    [Autowire]
    public ICodeCompiler Compiler { get; set; }

    [Autowire]
    public ISubContainerFactory Container { get; set;}

    public string FactoryName
    {
      get { return "User-defined system functions"; }
    }

    public UserFunctionParameters CreateOptions()
    {
      return new UserFunctionParameters();
    }

    public ISystemInfo Create(UserFunctionParameters options)
    {
      var code = CodeGen.GenerateCode(options);
      Assembly result = Compiler.CompileCSharpCode(code, typeof(Function<>), typeof(FunctionIO<>), typeof(DoubleSystemInfoBase), typeof(GeneratedImplementationArrtubute), typeof(NoInheritContainerAttribute));

      var c = Container.SubContainerNoScan<GeneratedImplementationArrtubute>();
      c.ScanAssemblies(result.Enum());

      return c.GetComponent<ISystemInfoMarker>();
    }

    public ICollection<CodeError> CheckCode(UserFunctionParameters ps)
    {
      try
      {
        Create(ps);
      } catch(UserDefinedFactoryException e)
      {
        return e.Errors;
      } catch(Exception e)
      {
        return new[] {new CodeError(0, 0, e.Message)};
      }
      return EmptyArray<CodeError>.Instance;
    }
  }
}