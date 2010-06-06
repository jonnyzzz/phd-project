using System.Collections.Generic;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;
using EugenePetrenko.Shared.Core.Ioc.JC;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace DSIS.UI.Application.Test
{
  [TestFixture]
  public class FunctionFactoryTest
  {
    [Test]
    public void Test_Detects()
    {
      using(var c = new JComponentContainer<ComponentImplementationAttribute>())
      {
        c.ScanAssemblies(typeof(IkedaFactory).Assembly.En());

        var l = new List<ISystemInfoFactory>(c.GetComponents<ISystemInfoFactory>());
        Assert.That(l.Count, Is.GreaterThan(0));
      }
    }
    
    [Test]
    public void Test_DetectsIkedaFactory()
    {
      using(var c = new JComponentContainer<ComponentImplementationAttribute>())
      {
        c.ScanAssemblies(typeof(IkedaFactory).Assembly.En());

        var l = new List<IkedaFactory>(c.GetComponents<IkedaFactory>());
        Assert.That(l.Count, Is.GreaterThan(0));
      }
    }
  }
}