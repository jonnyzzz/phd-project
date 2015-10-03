using System.Collections.Generic;
using System.Reflection;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;
using EugenePetrenko.Shared.Core.Ioc.JC;
using NUnit.Framework;

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
        c.ScanAssemblies(CollectionUtil.Enum(typeof(IkedaFactory).Assembly));

        var l = new List<ISystemInfoFactory>(c.GetComponents<ISystemInfoFactory>());
        Assert.That(l.Count, Is.GreaterThan(0));
      }
    }
    
    [Test]
    public void Test_DetectsIkedaFactory()
    {
      using(var c = new JComponentContainer<ComponentImplementationAttribute>())
      {
        c.ScanAssemblies(CollectionUtil.Enum(typeof(IkedaFactory).Assembly));

        var l = new List<IkedaFactory>(c.GetComponents<IkedaFactory>());
        Assert.That(l.Count, Is.GreaterThan(0));
      }
    }
  }
}