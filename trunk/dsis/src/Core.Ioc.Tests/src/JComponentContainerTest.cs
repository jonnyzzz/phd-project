using DSIS.Core.Ioc.JC;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace DSIS.Core.Ioc.Tests
{
  [TestFixture]
  public class JComponentContainerTest : ComponentContainerTestBase
  {
    protected override IComponentContainer CreateContainer<TI, TC, TO>()
    {
      return new JComponentContainer<TO>();
    }

    [Test]
    public void Test_00_RegisteredComponent2()
    {
      DoTest<TI, TO0>();
      var oo = new T1O();
      myContainer.RegisterComponent(oo);

      var c1 = myContainer.GetComponent<T1I>();
      var c2 = myContainer.GetComponent<T1I>();
      var c3 = myContainer.GetComponent<T1O>();

      Assert.That(c1, Is.InstanceOfType(typeof(T1O)));
      Assert.That(c2, Is.InstanceOfType(typeof(T1O)));
      Assert.That(c3, Is.InstanceOfType(typeof(T1O)));
      Assert.That(c1, Is.SameAs(c2));
      Assert.That(c3, Is.SameAs(c2));
    }

  }
}