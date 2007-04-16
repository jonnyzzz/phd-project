using DSIS.IntegerCoordinates.Tests;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.IntegerCoordinates.Generic
{
  public class IntegerCoordinatesBaseTest<T,Q> 
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    protected static void DoEqTest(params long[] l)
    {
      MockSystemSpace sp = new MockSystemSpace(l.Length, 0, 1, 981000);
      T ss = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(sp);

      Q ic = ss.Create(l);
      Q ic2 = ss.Create(l);
      Q ic3 = ss.Create((long[]) l.Clone());

      Hashset<Q> hs = new Hashset<Q>();
      hs.Add(ic);

      Assert.IsTrue(hs.Contains(ic));
      Assert.IsTrue(hs.Contains(ic2));
      Assert.IsTrue(hs.Contains(ic3));

      hs.Clear();
      hs.Add(ic3);

      Assert.IsTrue(hs.Contains(ic));
      Assert.IsTrue(hs.Contains(ic2));
      Assert.IsTrue(hs.Contains(ic3));

      hs.Clear();
      hs.Add(ic2);

      Assert.IsTrue(hs.Contains(ic));
      Assert.IsTrue(hs.Contains(ic2));
      Assert.IsTrue(hs.Contains(ic3));
    }
  }
}