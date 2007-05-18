using System;
using System.Collections.Generic;
using DSIS.Core.Util;
using NUnit.Framework;

namespace DSIS.Utils.Test
{
  [TestFixture]
  public class EqualityComparerFactoryTest
  {
    private static void DoTest<T,Q>() where T : IEqualityComparer<Q>
    {
      IEqualityComparer<Q> cmd = EqualityComparerFactory<Q>.GetComparer();

      try
      {
        Assert.IsTrue(cmd.GetType() == typeof (T));
      } catch
      {
        Console.Out.WriteLine("Unexpected type {0}, but expected {1} for type {2}", cmd.GetType(), typeof(T), typeof(Q));
        throw;
      }
    }

    [Test]
    public void Test_01()
    {
      DoTest<DoubleEqualityComparer, double>();            
    }

    [Test]
    public void Test_02()
    {
      DoTest<LongEqualityComparer, long>();            
    }

    [Test]
    public void Test_03()
    {
      DoTest<ArrayEqualityComparer<int>, int[]>();            
    }

    [Test]
    public void Test_04()
    {
      DoTest<IntEqualityComparer, int>();            
    }
  }
}
