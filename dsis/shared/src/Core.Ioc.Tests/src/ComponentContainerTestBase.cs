using System;
using System.Threading;
using EugenePetrenko.Shared.Core.Ioc.Api;
using NUnit.Framework;

namespace EugenePetrenko.Shared.Core.Ioc.Tests
{
  public abstract class ComponentContainerTestBase
  {
    protected IComponentContainer myContainer;

    [TearDown]
    public void TearDown()
    {
      if (myContainer != null)
      {
        myContainer.Dispose();
        myContainer = null;
      }
    }

    private void AssertContainsObject<T>()
    {
      AssertContainsObject<T>(myContainer);
    }

    private static void AssertContainsObject<T>(IComponentService container)
    {
      Assert.That(container.GetComponent<T>(), Is.InstanceOf(typeof(T)));
    }

    protected void DoTest<TO>()
      where TO : ComponentImplementationAttributeBase 
    {
      myContainer = CreateContainer<TO>();
      myContainer.ScanAssemblies(new[]{GetType().Assembly});
      myContainer.Start();
    }

    protected abstract IComponentContainer CreateContainer<TO>()
      where TO : ComponentImplementationAttributeBase;

    public class TC1 : ComponentCollectionAttributeBase {};

    public class TC2 : ComponentCollectionAttributeBase {};

    public class TO0 : ComponentImplementationAttributeBase {};

    public class TO1 : ComponentImplementationAttributeBase {};

    public class TO2 : ComponentImplementationAttributeBase {};

    public class TO3 : ComponentImplementationAttributeBase {};

    public class TO4 : ComponentImplementationAttributeBase {};

    public class TO5 : ComponentImplementationAttributeBase {};

    public class TO6 : ComponentImplementationAttributeBase {};

    public class TO7 : ComponentImplementationAttributeBase {};

    public class TO8 : ComponentImplementationAttributeBase {};

    public class TO9 : ComponentImplementationAttributeBase {};
    public class TOB : ComponentImplementationAttributeBase {};
    public class TOI : TOB {};

    [TC2]
    public interface T1I {}

    [TO1, TO2, TO4, TO8]
    public class T1O : T1I {}

    [TO2, TO8]
    public class T1O2 : T1I {}

    [TO3]
    public class T3O {}

    [TO4, TO6]
    public class  DependsOnT1I
    {
      public DependsOnT1I(T1I o)
      {
        Assert.That(o, Is.Not.Null);
      }
    }

    [TO7]
    public class DependsOnCC
    {
      public DependsOnCC(ISubContainerFactory o)
      {
        Assert.That(o, Is.Not.Null);
      }
    }

    public class CannotCreate
    {
      private CannotCreate()
      {
      }
    }

    [TO5]
    public class FakeSetter
    {
      public CannotCreate Setter{ get; set;}
    }

    [TO9(Startable = true)]
    public class StartTime
    {
      public readonly DateTime Start = DateTime.Now;
    }

    [TO9(Startable = true)]
    public class StartTime2 : IStartableComponent
    {
      public void Start()
      {
        StartTime = DateTime.Now;
      }
      public DateTime StartTime = DateTime.MaxValue;
    }

    [TOB]
    public class T1OB {}
    [TOI]
    public class T1OI {}

    [Test]
    public void Test_00_RegisteredComponent()
    {
      DoTest<TO0>();
      var oo = new T1O();
      myContainer.RegisterComponent(oo);

      var c1 = myContainer.GetComponent<T1I>();
      var c2 = myContainer.GetComponent<T1I>();

      Assert.That(c1, Is.InstanceOf(typeof(T1O)));
      Assert.That(c2, Is.InstanceOf(typeof(T1O)));
      Assert.That(c1, Is.SameAs(c2));
    }

    [Test]
    public void Test_01_OneComponent_OneImplementation()
    {
      DoTest<TO1>();
      var c1 = myContainer.GetComponent<T1I>();
      var c2 = myContainer.GetComponent<T1I>();

      Assert.That(c1, Is.InstanceOf(typeof(T1O)));
      Assert.That(c2, Is.InstanceOf(typeof(T1O)));
      Assert.That(c1, Is.SameAs(c2));
    }

    [Test]
    public void Test_02_OneComponent_TwoImplementation()
    {
      try
      {
        DoTest<TO2>();
        AssertContainsObject<T1I>();
        Assert.Fail("Should not reach here");
      } catch (ComponentContainerException)
      {
      }
    }

    [Test]
    public void Test_03_OneComponent_TwoImplementation()
    {
      DoTest<TO3>();
      AssertContainsObject<T3O>();
    }

    [Test]
    public void Test_04_TwoComponent_Autowire()
    {
      DoTest<TO4>();
      AssertContainsObject<DependsOnT1I>();
      AssertContainsObject<T1I>();
    }

    [Test]
    public void Test_05_NonSetter()
    {
      DoTest<TO5>();
      AssertContainsObject<FakeSetter>();
    }

    [Test]
    public void Test_06_Subcotainer()
    {
      DoTest<TO1>();
      var c = myContainer.SubContainer<TO6>();
      var cc = c.Start();
      AssertContainsObject<DependsOnT1I>(cc);
    }

    [Test]
    public void Test_07_ExplicitInstance()
    {
      DoTest<TO6>();
      myContainer.RegisterComponent(new T1O());
      AssertContainsObject<DependsOnT1I>();
    }

    [Test]
    public void Test_08_ComponentContainer()
    {
      DoTest<TO7>();
      AssertContainsObject<DependsOnCC>();
    }

    [Test]
    public void Test_10_ComponentStartable()
    {
      DoTest<TO9>();
      Thread.Sleep(100);
      var now = DateTime.Now;

      var s = myContainer.GetComponent<StartTime>();
      var s2 = myContainer.GetComponent<StartTime2>();

      Assert.That(s.Start, Is.LessThan(now));
      Assert.That(s2.StartTime, Is.LessThan(now));
    }

    [Test]
    public void Test_xx_AttributeInheritance()
    {
      DoTest<TOB>();

      AssertContainsObject<T1OB>();
      AssertContainsObject<T1OI>();
    }
  }
}