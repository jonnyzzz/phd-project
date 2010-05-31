using System;
using DSIS.Core.Ioc;
using DSIS.Core.Ioc.Ex;
using DSIS.Core.System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace DSIS.Function.UserDefined.Tests
{
  [TestFixture]
  public class UserDefinedFunctionFactoryTest : CodeCompilerBasedTest
  {
    public IUserDefinedFunctionFactory Factory
    {
      get
      {
        IUserDefinedFunctionFactory f = null;
        App.Create = F => { f = F; };
        ApplicationEntryPoint<App>.DoMain(new string[0]);
        return f;
      }
    }

    [ComponentImplementation]
    private class App : IApplication
    {
      [Autowire]
      private IUserDefinedFunctionFactory F { get; set; }

      public static Action<IUserDefinedFunctionFactory> Create;

      public int Main()
      {
        if (Create != null)
        {
          Create(F);
        }
        return 0;
      }
    }

    [Test]
    public void Test_01()
    {
      var ps = new UserFunctionParameters
                 {
                   Dimension = 1,
                   Code = "f1 = x1;",
                   FunctionName = "ZZZ",
                   SystemType = SystemType.Continious
                 };
      var result = Factory.Create(ps);
      
      Assert.That(result, Is.Not.Null);
      Assert.That(result.Dimension, Is.EqualTo(ps.Dimension));
      Assert.That(result.PresentableName, Is.EqualTo(ps.FunctionName));
      Assert.That(result.Type, Is.EqualTo(ps.SystemType));
    }

    [Test]
    public void Test_02()
    {
      var ps = new UserFunctionParameters
                 {
                   Dimension = 2,
                   Code = "f1 = x1; f2=x2;",
                   FunctionName = "ZZ222Z",
                   SystemType = SystemType.Discrete
                 };
      var result = Factory.Create(ps);
      
      Assert.That(result, Is.Not.Null);
      Assert.That(result.Dimension, Is.EqualTo(ps.Dimension));
      Assert.That(result.PresentableName, Is.EqualTo(ps.FunctionName));
      Assert.That(result.Type, Is.EqualTo(ps.SystemType));
    }

    [Test]
    public void Test_CodeError()
    {
      var ps = new UserFunctionParameters
      {
        Dimension = 2,
        Code = "f1 = x1 Error f2=x2;",
        FunctionName = "ZZ222Z",
        SystemType = SystemType.Discrete
      };
      try
      {
        Factory.Create(ps);
        Assert.Fail("Exception should be thrown");
      } catch
      {
        
      }

      var err = Factory.CheckCode(ps);
      Assert.IsTrue(err.Second.Count > 0 || err.First != null);
    }
  }
}