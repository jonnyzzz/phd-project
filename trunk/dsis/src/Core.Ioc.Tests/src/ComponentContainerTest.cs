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
      myContainer =  new ComponentContainer<TI, TO>();
      myContainer.ScanAssemblies(new[]{GetType().Assembly});
    }

    public class TI : ComponentInterfaceAttribute {};
    public class TO1 : ComponentImplemetationAttributeBase {};
    public class TO2 : ComponentImplemetationAttributeBase {};
    public class TO3 : ComponentImplemetationAttributeBase {};
    public class TO4 : ComponentImplemetationAttributeBase {};
    public class TO5 : ComponentImplemetationAttributeBase {};
    public class TO6 : ComponentImplemetationAttributeBase {};
    
    [TI]
    public interface T1I {}
    [TO1, TO2, TO4]
    public class T1O : T1I {}
    [TO2]
    public class T1O2 : T1I {}
    [TI, TO3]
    public class T3O {}
    [TI,TO4, TO6]
    public class DependsOnT1I
    {
      public DependsOnT1I(T1I o)
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
      var c = myContainer.SubContainer<TI, TO6>();
      AssertContainsObject<DependsOnT1I>(c);
    }
  }
}