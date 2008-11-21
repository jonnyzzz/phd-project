using System.Collections.Generic;
using System.Linq;
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

    [Test]
    public void Test_Enumerable()
    {
      DoTest<TI, Tx0>();

      var c1 = myContainer.GetComponent<JCI>();
      Assert.That(c1, Is.InstanceOfType(typeof (JCI)));
      Assert.That(c1.myJj.Count(), Is.EqualTo(1));
    }
    
    [Test]
    public void Test_Collection()
    {
      DoTest<TI, Tx1>();

      var c1 = myContainer.GetComponent<JCI2>();
      Assert.That(c1, Is.InstanceOfType(typeof (JCI2)));
      Assert.That(c1.myJj.Count(), Is.EqualTo(  1));
    }

    public class Tx0 : ComponentImplementationAttributeBase{}
    public class Tx1 : ComponentImplementationAttributeBase{}

    [Tx0]
    public class JI{}

    [Tx0]
    public class JCI
    {
      public readonly IEnumerable<JI> myJj;

      public JCI(IEnumerable<JI> jj)
      {
        myJj = jj;
      }
    }
    [Tx1]
    public class JI2 { }

    [Tx1]
    public class JCI2
    {
      public readonly ICollection<JI2> myJj;

      public JCI2(ICollection<JI2 > jj)
      {
        myJj = jj;
      }
    }
  }
}