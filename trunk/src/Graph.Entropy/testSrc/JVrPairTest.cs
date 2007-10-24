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
    }    
  }
}