using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.CodeCompiler;
using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.Function.Predefined;
using DSIS.Utils;
using log4net;
using ICodeCompiler=DSIS.CodeCompiler.ICodeCompiler;

namespace DSIS.Function.UserDefined
{
  [ComponentImplementation]
  public class UserDefinedFunctionFactoryImpl : IUserDefinedFunctionFactory
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (UserDefinedFunctionFactoryImpl));

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

    public Pair<string,ICollection<CodeError>> CheckCode(UserFunctionParameters ps)
    {
      try
      {
        Create(ps);
      }
      catch (UserDefinedFactoryException e)
      {
        LOG.Error(e);
        return Pair.Create(e.Message, e.Errors);
      }
      catch (CodeCompilerException e)
      {
        LOG.Error(e);
        var list = new List<CodeError>();
        foreach (var error in e.Errors)
        {
          list.Add(new CodeError(error.Column, error.Line, error.ErrorText));
        }

        return Pair.Create(e.GetErrorsAndCode(CodeGen.UserCodeRangeFilter(e.Code)), (ICollection<CodeError>)list);
      }
      catch (Exception e)
      {
        LOG.Error(e);
        return Pair.Create<string, ICollection<CodeError>>(e.Message, EmptyArray<CodeError>.Instance);
      }
      return Pair.Create<string, ICollection<CodeError>>(null, EmptyArray<CodeError>.Instance);
    }
  }
}