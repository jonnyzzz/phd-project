using System.Collections.Generic;
using NUnit.Framework;

namespace DSIS.Utils.testSrc
{
  [TestFixture]
  public class InfiniteEnumerableTest
  {
    [Test]
    public void TestEmpty()
    {
      InfiniteEnumerable<int> i = new InfiniteEnumerable<int>(EmptyArray<int>.Instance);
      Assert.IsFalse(i.GetEnumerator().MoveNext());      
    }
    
    [Test]
    public void TestOne()
    {
      InfiniteEnumerable<int> i = new InfiniteEnumerable<int>(new int[]{1});
      AssertStartsWith(i, Repeat(100,1));
    }
    
    [Test]
    public void TestTwo()
    {
      int[] host = new int[]{1,2};
      InfiniteEnumerable<int> i = new InfiniteEnumerable<int>(host);
      AssertStartsWith(i, Repeat(100,host));
    }

    [Test]
    public void TestThree()
    {
      int[] host = new int[]{1,2,3};
      InfiniteEnumerable<int> i = new InfiniteEnumerable<int>(host);
      AssertStartsWith(i, Repeat(100,host));
    }
    
    [Test]
    public void TestTen()
    {
      int[] host = new int[]{1,2,3,4,5,6,7,8,9,0};
      InfiniteEnumerable<int> i = new InfiniteEnumerable<int>(host);
      AssertStartsWith(i, Repeat(100,host));
    }

    private static void AssertStartsWith<T>(IEnumerable<T> collection, IEnumerable<T> assers)
    {
      IEnumerator<T> e = collection.GetEnumerator();
      
      foreach (T t in assers)
      {
        Assert.IsTrue(e.MoveNext());
        Assert.AreEqual(t, e.Current);        
      }
    }

    private static IEnumerable<T> Repeat<T>(int times, params T[] data)
    {
      List<T> list = new List<T>();
      for(int i=0; i<times; i++)
      {
        list.AddRange(data);
      }
      return list;      
    }

  }
}