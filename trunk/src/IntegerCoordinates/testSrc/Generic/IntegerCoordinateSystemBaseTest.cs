using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.IntegerCoordinates.Generic
{
  public class IntegerCoordinateSystemBaseTest<T, Q> 
    where T :IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    protected MockSystemSpace mySpace = null;
    protected T myCS = default(T);

    [SetUp]
    public void SetUp()
    {
      mySpace = new MockSystemSpace(2, 0, 1, 5);
      myCS = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T,Q>(mySpace);
    }


    [TearDown]
    public void TeamDown()
    {
      mySpace = null;
      myCS = default(T);
    }

    [Test]
    public void Test_01()
    {
      foreach (double d in myCS.CellSize)
      {
        Assert.AreEqual(0.2, d, 1e-8);
      }
    }

    [Test]
    public void Test_02()
    {
      foreach (double d in myCS.CellSizeHalf)
      {
        Assert.AreEqual(0.1, d, 1e-8);
      }
    }

    [Test]
    public void Test_03()
    {
      List<Q> cnt = new List<Q>(myCS.InitialSubdivision);
      Assert.AreEqual(25, cnt.Count);
    }

    [Test]
    public void Test_04()
    {
      List<Q> c = new List<Q>(myCS.InitialSubdivision);

      Assert.AreEqual(2, myCS.SystemSpace.Dimension);

      bool[][] bs = new bool[myCS.Subdivision[0]][];
      for (int i = 0; i < myCS.Subdivision[0]; i++)
      {
        bs[i] = new bool[myCS.Subdivision[1]];
      }

      c.ForEach(delegate(Q ic)
                  {
                    long coordinate1 = ic.GetCoordinate(0);
                    long coordinate2 = ic.GetCoordinate(1);
                    bs[coordinate1][coordinate2] = true;
                  });

      foreach (bool[] b in bs)
      {
        foreach (bool b1 in b)
        {
          Assert.IsTrue(b1);
        }
      }
    }

    [Test]
    public void Test_05()
    {
      Q c = myCS.FromPoint(new double[] {0, 0});
      Assert.IsNotNull(c);
      Assert.AreEqual(0, c.GetCoordinate(0));
      Assert.AreEqual(0, c.GetCoordinate(1));
    }

    [Test]
    public void Test_06()
    {
      Q c = myCS.FromPoint(new double[] {0.1, 0.1});
      Assert.IsNotNull(c);
      Assert.AreEqual(0, c.GetCoordinate(0));
      Assert.AreEqual(0, c.GetCoordinate(1));
    }

    [Test]
    public void Test_07()
    {
      Assert.AreEqual(0, myCS.ToInternal(0, 0));
    }

    [Test]
    public void Test_08()
    {
      Assert.AreEqual(0, myCS.ToInternal(myCS.CellSizeHalf[0], 0));
    }

    [Test]
    public void Test_09()
    {
      Assert.AreEqual(0, myCS.ToInternal(0.001, 0));
    }

    [Test]
    public void Test_Subdivision()
    {
      long[] div = { 7, 8 };
      ICellCoordinateSystemConverter<Q, Q> sb = myCS.Subdivide(div);

      Assert.AreEqual(sb.ToSystem.Subdivision[0], myCS.Subdivision[0] * div[0]);
      Assert.AreEqual(sb.ToSystem.Subdivision[1], myCS.Subdivision[1] * div[1]);
    }

  }
}