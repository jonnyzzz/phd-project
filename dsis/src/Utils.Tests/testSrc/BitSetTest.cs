using System;
using NUnit.Framework;

namespace DSIS.Utils.Tests
{
  [TestFixture]
  public class BitSetTest
  {
    private BitSet set;

    [SetUp]
    public void SetUp()
    {
      set = new BitSet();
    }

    [Test]
    public void TestRead()
    {
      for(int i = 0; i < 100; i++)
      {
        Assert.IsFalse(set.IsSet(i));
      }
      for(int i = 0; i < 100; i++)
      {
        Assert.IsFalse(set.IsSet(i));
      }
    }

    [Test]
    public void TestSeq()
    {
      DoSimpleSetTest(1000, i=>i%2 == 0);
      DoSimpleSetTest(1000, i=>i%3 == 0);
      DoSimpleSetTest(1000, i=>i%4 == 0);
      DoSimpleSetTest(1000, i=>i%5 == 0);
      DoSimpleSetTest(1000, i=>i%6 == 0);
      DoSimpleSetTest(1000, i=>i%7 == 0);
    }

    [Test]
    public void TestSetEachBit()
    {
      for (int i = 0; i < 32; i++)
      {
        int p = i;
        DoSimpleSetTest(1000, x => x % 32 == p);
      }
    }

    [Test]
    public void TestSetUpperBits()
    {
      for (int i = 0; i < 32; i++)
      {
        int p = i;
        DoSimpleSetTest(1000, x => x % 32 >= p);
      }
    }

    [Test]
    public void TestSetLowerBits()
    {
      for (int i = 0; i < 32; i++)
      {
        int p = i;
        DoSimpleSetTest(1000, x => x % 32 <= p);
      }
    }

    private void DoSimpleSetTest(int max, Predicate<int> isset)
    {
      for (int i = 0; i < max; i ++)
        set.Set(i, isset(i));
      for (int i = 0; i < max; i ++)
        Assert.AreEqual(isset(i), set.IsSet(i));
    }

    [Test]
    public void TestSetAll()
    {
      for(int i = 0; i < 100; i++)
      {
        set.Set(i, true);
        for(int j = 0; j <=i; j++)
        {
          Assert.IsTrue(set.IsSet(j));
        }
        for(int j = i+1; j < 100; j++)
        {
          Assert.IsFalse(set.IsSet(j));
        }
      }

      for(int i = 0; i < 100; i++)
      {
        set.Set(i, false);
        for(int j = 0; j <=i; j++)
        {
          Assert.IsFalse(set.IsSet(j));
        }
        for(int j = i+1; j < 100; j++)
        {
          Assert.IsTrue(set.IsSet(j));
        }
      }
    }
    
  }
}