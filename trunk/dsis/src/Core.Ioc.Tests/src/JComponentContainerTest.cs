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
    
    [Test]
    public void Test_PropertyAutowire()
    {
      DoTest<TI, Tx2>();

      var c1 = myContainer.GetComponent<JCI3>();
      Assert.That(c1, Is.InstanceOfType(typeof (JCI3)));
      Assert.That(c1.Obj, Is.InstanceOfType(typeof(JI3)));
    }
    
    [Test]
    public void Test_PropertyAutowire2()
    {
      DoTest<TI, Tx3>();

      var c1 = myContainer.GetComponent<JCI4>();
      Assert.That(c1, Is.InstanceOfType(typeof (JCI4)));
      
      Assert.That(c1.Obj.First(), Is.InstanceOfType(typeof(JI4)));
      Assert.That(c1.Obj2.First(), Is.InstanceOfType(typeof(JI4)));
      Assert.That(c1.Obj3.First(), Is.InstanceOfType(typeof(JI4)));
      Assert.That(c1.Obj4, Is.InstanceOfType(typeof(JI4)));
      
      Assert.That(c1.Obj.Count(), Is.EqualTo(1));
      Assert.That(c1.Obj2.Count(), Is.EqualTo(1));
      Assert.That(c1.Obj3.Count(), Is.EqualTo(1));
    }

    [Test]
    public void Test_PropertyAutowire_Private()
    {
      DoTest<TI, Tx4>();

      var c1 = myContainer.GetComponent<JCI5>();
      Assert.That(c1, Is.InstanceOfType(typeof(JCI5)));
      Assert.That(c1.Open, Is.InstanceOfType(typeof(JI5)));
    }

    [Test]
    public void Test_PropertyAutowire_Private2()
    {
      DoTest<TI, Tx5>();

      var c1 = myContainer.GetComponent<JCB6>();
      Assert.That(c1, Is.InstanceOfType(typeof(JCB6)));
      Assert.That(c1.Getter, Is.InstanceOfType(typeof(JI6)));
    }

    [Test]
    public void Test_TypeInstantiator()
    {
      DoTest<TI, Tx6>();

      var c1 = myContainer.GetComponent<JI7Host>();
      Assert.That(c1, Is.InstanceOfType(typeof(JI7Host)));
      Assert.That(c1.Foo, Is.InstanceOfType(typeof(JI7x)));
      Assert.That(c1.Foo.Bar, Is.EqualTo("ZZZZ"));
      Assert.That(c1.Foo.Prop, Is.InstanceOfType(typeof(JI7)));
    }

    [Test]
    public void Test_RegisterComponent()
    {
      DoTest<TI, Tx7>();

      myContainer.RegisterComponent("ZZZZ");
      var c = myContainer.GetComponent<string>();
      Assert.That(c, Is.EqualTo("ZZZZ"));
    }

    public class Tx0 : ComponentImplementationAttributeBase{}
    public class Tx1 : ComponentImplementationAttributeBase{}
    public class Tx2 : ComponentImplementationAttributeBase{}
    public class Tx3 : ComponentImplementationAttributeBase{}
    public class Tx4 : ComponentImplementationAttributeBase{}
    public class Tx5 : ComponentImplementationAttributeBase{}
    public class Tx6 : ComponentImplementationAttributeBase{}
    public class Tx7 : ComponentImplementationAttributeBase{}

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
    [Tx2]
    public class JI3 {}

    [Tx2]
    public class JCI3
    {
      [Autowire]
      public JI3 Obj { get; set; }
    } 
    [Tx3]
    public class JI4 {}

    [Tx3]
    public class JCI4
    {
      [Autowire]
      public IEnumerable<JI4> Obj { get; set; }
      [Autowire]
      public ICollection<JI4> Obj2 { get; set; }
      [Autowire]
      public JI4[] Obj3 { get; set; }
      [Autowire]
      public JI4 Obj4 { get; set; }
    }

    [Tx4]
    public class JI5 { }

    [Tx4]
    public class JCI5 : JCI5B {}
    public class JCI5B
    {
      public JI5 Open { get { return Obj; } }
      [Autowire]
      private JI5 Obj { get; set; }
    } 

    [Tx5]
    public class JI6 {}
    public class JCB6Base { [Autowire]protected JI6 Setter { get; private set; } public JI6 Getter { get { return Setter; } } }
    [Tx5]
    public class JCB6 : JCB6Base { }

    [Tx6]
    public class JI7 {}
    [TypeInstanciable]public class JI7x { [Autowire] public JI7 Prop{ get; set;} public string Bar { get; private set;}

      public JI7x(string bar)
      {
        Bar = bar;
      }
    }
    [Tx6]
    public class JI7Host { 
      public JI7x Foo { get; private set;}

      public JI7Host(ITypeInstantiator i) {
        Foo = i.Instanciate<JI7x>("ZZZZ");
    }}
  }
}