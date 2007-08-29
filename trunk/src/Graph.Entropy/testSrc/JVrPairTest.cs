using System.Collections.Generic;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Graph.Entropy
{
  [TestFixture]
  public class JVrPairTest
  {
    [Test]
    public void Test_01()
    {
      JVRPair<IntegerCoordinate> p1 = new JVRPair<IntegerCoordinate>(
        new IntegerCoordinate(1),
        new IntegerCoordinate(2)
        );

      IEqualityComparer<IntegerCoordinate> c = EqualityComparerFactory<IntegerCoordinate>.GetComparer();

      IntegerCoordinate i1 = new IntegerCoordinate(1);
      IntegerCoordinate i2 = new IntegerCoordinate(2);

      Assert.IsTrue(c.Equals(p1.From, i1));
      Assert.IsTrue(c.Equals(p1.To, i2));

      JVRPair<IntegerCoordinate> p2 = p1.Inverse();

      Assert.IsTrue(c.Equals(p2.From, i2));
      Assert.IsTrue(c.Equals(p2.To, i1));

      Assert.AreEqual(p1.Hash, p2.BackHash);
      Assert.AreEqual(p2.BackHash, p2.Hash);
      
      Assert.AreEqual(p1.Hash, p2.Inverse().Hash);
      Assert.AreEqual(p2.BackHash, p2.Inverse().BackHash);
    }    
  }
}