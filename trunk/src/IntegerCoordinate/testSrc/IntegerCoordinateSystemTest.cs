using System.Collections.Generic;
using NUnit.Framework;

namespace DSIS.IntegerCoordinates.Tests
{
  [TestFixture]
  public class IntegerCoordinateSystemTest
  {
    private MockSystemSpace mySpace = null;
    private IntegerCoordinateSystem myCS = null;
        
    [SetUp]
    public void SetUp()
    {
      mySpace = new MockSystemSpace(2, 0, 1, 5);
      myCS = new IntegerCoordinateSystem(mySpace);
    }

    [TearDown]
    public void TeamDown()
    {
      mySpace = null;
      myCS = null;
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
      List<IntegerCoordinate> cnt = new List<IntegerCoordinate>(myCS.InitialSubdivision);
      Assert.AreEqual(25, cnt.Count);
    }

    [Test]
    public void Test_04()
    {
      List<IntegerCoordinate> c = new List<IntegerCoordinate>(myCS.InitialSubdivision);

      Assert.IsTrue(myCS.Dimension == 2);
      
      bool[][] bs = new bool[myCS.Subdivision[0]][];
      for (int i=0; i<myCS.Subdivision[0]; i++)
      {
        bs[i] = new bool[myCS.Subdivision[1]];
      }

      c.ForEach(delegate(IntegerCoordinate ic)
                  {
                    long coordinate1 = ic.Coordinate[0];
                    long coordinate2 = ic.Coordinate[1];
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
      IntegerCoordinate c = myCS.FromPoint(new double[]{0,0});
      Assert.AreEqual(0, c.Coordinate[0]);
      Assert.AreEqual(0, c.Coordinate[1]);
    }

    [Test]
    public void Test_06()
    {
      IntegerCoordinate c = myCS.FromPoint(new double[] { 0.1, 0.1 });
      Assert.AreEqual(0, c.Coordinate[0]);
      Assert.AreEqual(0, c.Coordinate[1]);      
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

  }
}