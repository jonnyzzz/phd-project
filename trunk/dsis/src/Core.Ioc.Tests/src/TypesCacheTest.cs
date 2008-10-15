using System;
using System.Collections.Generic;
using DSIS.Core.Ioc.JC;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace DSIS.Core.Ioc.Tests
{
  [TestFixture]
  public class TypesCacheTest
  {
    private IImplLoopup myImpl;

    [SetUp]
    public void SetUp()
    {
      myImpl = new ImplLookupImpl(new BaseTypeLookupImpl(new TypesFilerImpl()));
    }

    [TearDown]
    public void TearDown()
    {
      myImpl = null;
    }

    [Test]
    public void Test_01()
    {
      myImpl.RegisterImplementation(typeof(A));
      var types = new List<Type>(myImpl.GetImplementations(typeof(A)));

      Assert.That(types.Count, Is.EqualTo(1));
      Assert.That(types[0], Is.EqualTo(typeof (A)));
    }
    
    [Test]
    public void Test_02()
    {
      myImpl.RegisterImplementation(typeof(A));
      myImpl.RegisterImplementation(typeof(B));
      var types = new List<Type>(myImpl.GetImplementations(typeof(B)));

      Assert.That(types.Count, Is.EqualTo(1));
      Assert.That(types[0], Is.EqualTo(typeof (B)));

      types = new List<Type>(myImpl.GetImplementations(typeof(A)));

      Assert.That(types.Count, Is.EqualTo(2));
      Assert.That(types.Contains(typeof(B)), Is.True);
      Assert.That(types.Contains(typeof(A)), Is.True);
    }  
    
    [Test]
    public void Test_03()
    {
      myImpl.RegisterImplementation(typeof(A));
      myImpl.RegisterImplementation(typeof(B));
      myImpl.RegisterImplementation(typeof(C));

      var types = new List<Type>(myImpl.GetImplementations(typeof(B)));

      Assert.That(types.Count, Is.EqualTo(2));
      Assert.That(types.Contains(typeof (B)), Is.True);
      Assert.That(types.Contains(typeof (C)), Is.True);

      types = new List<Type>(myImpl.GetImplementations(typeof(A)));

      Assert.That(types.Count, Is.EqualTo(3));
      Assert.That(types.Contains(typeof(C)), Is.True);
      Assert.That(types.Contains(typeof(B)), Is.True);
      Assert.That(types.Contains(typeof(A)), Is.True);

      types = new List<Type>(myImpl.GetImplementations(typeof(IA)));

      Assert.That(types.Count, Is.EqualTo(1));
      Assert.That(types.Contains(typeof(C)), Is.True);

      types = new List<Type>(myImpl.GetImplementations(typeof(IB)));

      Assert.That(types.Count, Is.EqualTo(2));
      Assert.That(types.Contains(typeof(C)), Is.True);
      Assert.That(types.Contains(typeof(B)), Is.True);

    }

    public class A {}

    public class B : A, IB { }

    public class C : B, IA,IB {}

    public interface IA {}
    public interface IB {}
  }
}