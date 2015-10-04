using System;
using EugenePetrenko.Shared.Utils;
using NUnit.Framework;

namespace EugenePetrenko.Shared.Core.Ioc.Tests
{
  [TestFixture]
  public class TypeGenerifierTest
  {
    [Test]
    public void Test_String()
    {
      doTest(typeof (string));
    }

    [Test]
    public void Test_bool()
    {
      doTest(typeof(bool));
    }

    [Test]
    public void Test_object()
    {
      doTest(typeof(object));
    }

    [Test]
    public void Test_CallbackT_object_string()
    {
      doTest<object, string>("zzz");
    }

    [Test]
    public void Test_CallbackT_string_int()
    {
      doTest<string, int>(42);
    }
    
    [Test]
    public void Test_Fun_string_int_bool()
    {
      doTest<string, int, bool>(42, false);
    }

    [Test]
    public void Test_Fun_bool_TypeGT_string()
    {
      doTest<bool, TypeGenerifierTest, string>(this, "rrr");
    }

    private static void doTest(Type type)
    {
      var f = new GF();
      TypeGenerifier.CallbackType(type, f);
      Assert.That(f.myT, Is.EqualTo(type));
    }

    public static void doTest<T, Q>(Q q)
    {
      var f = new GF<Q>();
      TypeGenerifier.CallbackType(typeof (T), f, q);
      Assert.That(f.myT, Is.EqualTo(typeof (T)));      
      Assert.That(f.myQ, Is.EqualTo(q));      
    }

    public static void doTest<T, Q, R>(Q q, R r)
    {
      var f = new GF<Q,R> {myR = r};
      var e = TypeGenerifier.CallbackFun(typeof (T), f, q);
      Assert.That(f.myT, Is.EqualTo(typeof (T)));      
      Assert.That(f.myQ, Is.EqualTo(q));      
      Assert.That(e, Is.EqualTo(r));      
    }

    private class GF : TypeGenerifier.Callback
    {
      public Type myT;
      public void Callback<T>()
      {
        myT = typeof (T);
      }
    }

    private class GF<Q> : TypeGenerifier.Callback<Q>
    {
      public Type myT;
      public Q myQ;

      public void Callback<T>(Q q)
      {
        myT = typeof (T);
        myQ = q;
      }
    }

    private class GF<Q,R> : TypeGenerifier.Fun<Q,R>
    {
      public Type myT;
      public Q myQ;
      public R myR;

      public R Callback<T>(Q q)
      {
        myT = typeof (T);
        myQ = q;
        return myR;
      }
    }
  }
}