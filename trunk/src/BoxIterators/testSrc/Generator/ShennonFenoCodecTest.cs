using System.Collections.Generic;
using DSIS.Core.Util;
using NUnit.Framework;

namespace DSIS.BoxIterators.Generator
{
  [TestFixture]
  public class ShennonFenoCodecTest
  {
    [Test]
    public void Test_01()
    {
      List<Pair<int, bool>> pairs = new List<Pair<int, bool>>(new ShennonFenoCodec(1));

      Assert.AreEqual(1, pairs.Count);
      Assert.AreEqual(new Pair<int, bool>(0, true), pairs[0] );
    }
    
    [Test]
    public void Test_02()
    {
      List<Pair<int, bool>> pairs = new List<Pair<int, bool>>(new ShennonFenoCodec(2));

      Assert.AreEqual(3, pairs.Count);
      Assert.AreEqual(new Pair<int, bool>(0, true), pairs[0] );
      Assert.AreEqual(new Pair<int, bool>(1, true), pairs[1] );
      Assert.AreEqual(new Pair<int, bool>(0, false), pairs[2] );
    }
    
    [Test]
    public void Test_03()
    {
      List<Pair<int, bool>> pairs = new List<Pair<int, bool>>(new ShennonFenoCodec(3));

      Assert.AreEqual(7, pairs.Count);
      Assert.AreEqual(new Pair<int, bool>(0, true),  pairs[0] );
      Assert.AreEqual(new Pair<int, bool>(1, true),  pairs[1] );
      Assert.AreEqual(new Pair<int, bool>(0, false), pairs[2] );
      Assert.AreEqual(new Pair<int, bool>(2, true),  pairs[3] );
      Assert.AreEqual(new Pair<int, bool>(0, true),  pairs[4] );
      Assert.AreEqual(new Pair<int, bool>(1, false), pairs[5] );
      Assert.AreEqual(new Pair<int, bool>(0, false), pairs[6] );
    }
  }
}
