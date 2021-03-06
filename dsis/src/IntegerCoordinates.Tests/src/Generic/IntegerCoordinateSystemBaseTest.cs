using System.Collections.Generic;
using DSIS.Core.Coordinates;
using NUnit.Framework;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates.Tests.Generic
{  
  public abstract class IntegerCoordinateSystemBaseTest<T, Q> 
    where T :IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    protected MockSystemSpace mySpace = null;
    protected T myCS = default(T);

    [SetUp]
    public void SetUp()
    {
      mySpace = new MockSystemSpace(2, 0, 1, 5);
      myCS = CoordinateSystem();
    }

    protected virtual T CoordinateSystem()
    {
      return IntegerCoordinateSystemFactory.CreateCoordinateSystem<T,Q>(mySpace);
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
      var cnt = new List<Q>(myCS.InitialSubdivision);
      Assert.AreEqual(25, cnt.Count);
    }

    [Test]
    public void Test_04()
    {
      var c = new List<Q>(myCS.InitialSubdivision);

      if (myCS.Dimension != 2)
        Assert.Ignore("Dimension != 2");

      var bs = new bool[myCS.Subdivision[0]][];
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
      if (myCS.Dimension != 2)
        Assert.Ignore("Dimension != 2");


      Q c = myCS.FromPoint(new double[] {0, 0});
      Assert.IsNotNull(c);
      Assert.IsFalse(myCS.IsNull(c));
      Assert.AreEqual(0, c.GetCoordinate(0), "coord 0");
      Assert.AreEqual(0, c.GetCoordinate(1), "coord 1");
    }

    [Test]
    public void Test_06()
    {
      if (myCS.Dimension != 2)
        Assert.Ignore("Dimension != 2");


      Q c = myCS.FromPoint(new double[] {0.1, 0.1});
      Assert.IsNotNull(c);
      Assert.IsFalse(myCS.IsNull(c));
      Assert.AreEqual(0, c.GetCoordinate(0), "coord 0");
      Assert.AreEqual(0, c.GetCoordinate(1), "coord 1");
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

    [Test]
    public void Test_NonNull()
    {
      Assert.That(myCS.IsNull(myCS.FromPoint(0.5.Fill(2))), Is.False);
    }
  }
}