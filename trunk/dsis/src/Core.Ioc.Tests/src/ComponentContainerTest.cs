using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace DSIS.Core.Ioc.Tests
{
  [TestFixture]
  public class ComponentContainerTest
  {
    private IComponentContainer myContainer;

    [TearDown]
    public void TearDown()
    {
      if (myContainer != null)
      {
        myContainer.Dispose();
        myContainer = null;
      }
    }

    public void AssertContainsObject<T>()
    {
      AssertContainsObject<T>(myContainer);
    }

    public void AssertContainsObject<T>(IComponentContainer container)
    {
      Assert.That(container.GetComponent<T>(), Is.InstanceOfType(typeof(T)));
    }

    protected void DoTest<TI,TO>()
      where TI : ComponentInterfaceAttributeBase
      where TO : ComponentImplemetationAttributeBase 
    {
      DoTest<TI,TC1,TO>();
    }

    protected void DoTest<TI,TC,TO>()
      where TI : ComponentInterfaceAttributeBase
      where TO : ComponentImplemetationAttributeBase 
      where TC : ComponentCollectionAttributeBase
    {
      myContainer =  new ComponentContainer<TI, TC, TO>();
      myContainer.ScanAssemblies(new[]{GetType().Assembly});
    }

    public class TI : ComponentInterfaceAttribute {};
    public class TI2 : ComponentInterfaceAttribute {};
    public class TC1 : ComponentCollectionAttributeBase {};
    public class TC2 : ComponentCollectionAttributeBase {};
    public class TO1 : ComponentImplemetationAttributeBase {};
    public class TO2 : ComponentImplemetationAttributeBase {};
    public class TO3 : ComponentImplemetationAttributeBase {};
    public class TO4 : ComponentImplemetationAttributeBase {};
    public class TO5 : ComponentImplemetationAttributeBase {};
    public class TO6 : ComponentImplemetationAttributeBase {};
    public class TO7 : ComponentImplemetationAttributeBase {};
    public class TO8 : ComponentImplemetationAttributeBase {};
    public class TO9 : ComponentImplemetationAttributeBase {};
    
    [TI,TC2]
    public interface T1I {}
    [TO1, TO2, TO4, TO8]
    public class T1O : T1I {}
    [TO2, TO8]
    public class T1O2 : T1I {}
    [TI, TO3]
    public class T3O {}
    [TI,TO4, TO6]
    public class  DependsOnT1I
    {
      public DependsOnT1I(T1I o)
      {
        Assert.That(o, Is.Not.Null);
      }
    }
    [TI, TO7]
    public class DependsOnCC
    {
      public DependsOnCC(IComponentContainer o)
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
    [TI, TO5]
    public class FakeSetter
    {
      public CannotCreate Setter{ get; set;}
    }
    [TI, TO9(Startable = true)]
    public class StartTime
    {
      public readonly DateTime Start = DateTime.Now;
    }
    [TI, TO9(Startable = true)]
    public class StartTime2 : IStartableComponent
    {
      public void Start()
      {
        StartTime = DateTime.Now;
      }
      public DateTime StartTime = DateTime.MaxValue;
    }

    [Test]
    public void Test_01_OneComponent_OneImplementation()
    {
      DoTest<TI,TO1>();
      Assert.That(myContainer.GetComponent<T1I>(), Is.InstanceOfType(typeof(T1O)));
    }

    [Test, ExpectedException(typeof(ComponentContainerException))]
    public void Test_02_OneComponent_TwoImplementation()
    {
      DoTest<TI,TO2>();
      AssertContainsObject<T1I>();
    }
    
    [Test]
    public void Test_03_OneComponent_TwoImplementation()
    {
      DoTest<TI,TO3>();
      AssertContainsObject<T3O>();
    }

    [Test]
    public void Test_04_TwoComponent_Autowire()
    {
      DoTest<TI,TO4>();
      AssertContainsObject<DependsOnT1I>();
      AssertContainsObject<T1I>();
    }

    [Test]
    public void Test_05_NonSetter()
    {
      DoTest<TI,TO5>();
      AssertContainsObject<FakeSetter>();
    }

    [Test]
    public void Test_06_Subcotainer()
    {
      DoTest<TI,TO1>();
      var c = myContainer.SubContainer<TI, TC1, TO6>();
      AssertContainsObject<DependsOnT1I>(c);
    }

    [Test]
    public void Test_07_ExplicitInstance()
    {
      DoTest<TI,TO6>();
      myContainer.RegisterComponent(new T1O());
      AssertContainsObject<DependsOnT1I>();
    }

    [Test]
    public void Test_08_ComponentContainer()
    {
      DoTest<TI,TO7>();
      AssertContainsObject<DependsOnCC>();
    }

    [Test]
    public void Test_09_ComponentServices()
    {
      DoTest<TI2, TC2, TO8>();
      AssertContainsObject<IComponentContainerServices>();
      var s = myContainer.GetComponent<IComponentContainerServices>();
      var ss = new List<T1I>(s.GetServices<T1I>());
      Assert.That(ss.Count, Is.EqualTo(2));
    }

    [Test]
    public void Test_10_ComponentStartable()
    {
      DoTest<TI, TO9>();
      Thread.Sleep(100);
      var now = DateTime.Now;

      var s = myContainer.GetComponent<StartTime>();
      var s2 = myContainer.GetComponent<StartTime2>();

      Assert.That(s.Start, Is.LessThan(now));
      Assert.That(s2.StartTime, Is.LessThan(now));
    }
  }
}