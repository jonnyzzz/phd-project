using System;
using DSIS.Core.System;
using DSIS.Function.Predefined;
using NUnit.Framework;

namespace DSIS.Function.UserDefined.Tests
{
  [TestFixture]
  public class UserDefinedCodeGeneratorTest : CodeCompilerBasedTest
  {
    [Test]
    public void TestGenerateMathRedirect()
    {
      var gen = new UserDefinedCodeGenerator();
      var arg = gen.GenerateMathRedefinitions();

      string code = "public class Foo { \r\n" + arg + "\r\n } ";
      Compiler.CompileCSharpCode(code, typeof (Math));
    }

    [Test]
    public void TestGenerateFullClass_1()
    {
      var gen = new UserDefinedCodeGenerator();
      var pz = new UserFunctionParameters
                 {
                   Code = "f1 = x1;",
                   Dimension = 1,
                   SystemType = SystemType.Discrete
                 };

      var code = gen.GenerateCode(pz);

      Compiler.CompileCSharpCode(code, typeof(Function<>), typeof(FunctionIO<>), typeof(DoubleSystemInfoBase), typeof(GeneratedImplementationArrtubute));
    }

    [Test]
    public void TestGenerateFullClass_2()
    {
      var gen = new UserDefinedCodeGenerator();
      var pz = new UserFunctionParameters
                 {
                   Code = "f1 = x1; f2=x2;",
                   Dimension = 2,
                   SystemType = SystemType.Discrete
                 };

      var code = gen.GenerateCode(pz);

      Compiler.CompileCSharpCode(code, typeof(Function<>), typeof(FunctionIO<>), typeof(DoubleSystemInfoBase), typeof(GeneratedImplementationArrtubute));
    }
  }
}