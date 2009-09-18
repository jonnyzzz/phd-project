using System;
using EugenePetrenko.Shared.Utils;
using NUnit.Framework;

namespace EugenePetrenko.Shared.Core.Ioc.Tests
{
  [TestFixture]
  public class TypeDenerifierTest
  {
    [Test]
    public void Test_String()
    {
      GF f = new GF();
      TypeGenerifier.CallbackType(typeof(string), f);
      Assert.That(f.myT, Is.EqualTo(typeof(string)));
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

    private static void doTest(Type type)
    {
      GF f = new GF();
      TypeGenerifier.CallbackType(type, f);
      Assert.That(f.myT, Is.EqualTo(type));
    }

    private class GF : TypeGenerifier.Callback
    {
      public Type myT;
      public void Callback<T>()
      {
        myT = typeof (T);
      }
    }
  }
}