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
      var compiter = new CodeCompilerImpl(new CodeCompilerFilenameGenerator());
      Assembly assembly = compiter.CompileCSharpCode(@"public class Claszz : DSIS.CodeCompiler.ITest01 { public void Foo() { } }", typeof(ITest01));

      var o = (ITest01) Activator.CreateInstance(assembly.GetType("Claszz"));
      o.Foo();      
    }
  }
}
