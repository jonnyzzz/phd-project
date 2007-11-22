using System;
using System.Reflection;
using NUnit.Framework;

namespace DSIS.CodeCompiler
{
  public interface ITest01
  {
    void Foo();
  }

  [TestFixture]
  public class CodeCompilerImplTest
  {
    [Test]
    public void Test_01()
    {
      CodeCompilerImpl compiter = new CodeCompilerImpl();
      Assembly assembly = compiter.CompileCSharpCode(@"public class Claszz : DSIS.CodeCompiler.ITest01 { public void Foo() { } }", typeof(ITest01));

      ITest01 o = (ITest01) Activator.CreateInstance(assembly.GetType("Claszz"));
      o.Foo();      
    }
  }
}
