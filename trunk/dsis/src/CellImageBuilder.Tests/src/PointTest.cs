using DSIS.CellImageBuilder.BoxAdaptiveMethod;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.Tests
{
  [TestFixture]
  public class PointTest
  {
    [Test]
    public void Test_01()
    {
      Point p1 = Point.Create(new int[] {0});

      Assert.AreEqual(0, p1.Power);
      Assert.AreEqual(1, p1.Points.Length);
      Assert.AreEqual(0, p1.Points[0]);
    }

    [Test]
    public void Test_02()
    {
      Point p1 = Point.Create(new int[] {1});

      Assert.AreEqual(0, p1.Power);
      Assert.AreEqual(1, p1.Points.Length);
      Assert.AreEqual(1, p1.Points[0]);
    }

    [Test]
    public void Test_03()
    {
      Point p1 = Point.Create(new int[] {0});
      Point p2 = Point.Create(new int[] {1});

      Point m = Point.Middle(p1, p2, new Divide[] {Divide.First});

      Assert.AreEqual(p1, m);
    }

    [Test]
    public void Test_04()
    {
      Point p1 = Point.Create(new int[] {0});
      Point p2 = Point.Create(new int[] {1});

      Point m = Point.Middle(p1, p2, new Divide[] {Divide.Second});

      Assert.AreEqual(p2, m);
    }

    [Test]
    public void Test_05()
    {
      Point p1 = Point.Create(new int[] {0});
      Point p2 = Point.Create(new int[] {1});

      Point m = Point.Middle(p1, p2, new Divide[] {Divide.Middle});

      Assert.AreEqual(1, m.Points[0]);
      Assert.AreEqual(1, m.Power);
    }

    [Test]
    public void Test_06()
    {
      Point p1 = Point.Create(new int[] {0});
      Point p2 = Point.Create(new int[] {1});

      Point m = Point.Middle(p1, p2, new Divide[] {Divide.Middle});
      Point m1 = Point.Middle(p1, m, new Divide[] {Divide.Middle});

      Assert.AreEqual(2, m1.Power);
      Assert.AreEqual(1, m1.Points[0]);
    }

    [Test]
    public void Test_07()
    {
      Point p1 = Point.Create(new int[] {0});
      Point p2 = Point.Create(new int[] {1});

      Point m = Point.Middle(p1, p2, new Divide[] {Divide.Middle});
      Point m1 = Point.Middle(p2, m, new Divide[] {Divide.Middle});

      Assert.AreEqual(2, m1.Power, "Power of 2");
      Assert.AreEqual(3, m1.Points[0]);
    }

    [Test]
    public void Test_08()
    {
      Point p1 = Point.Create(new int[] {0, 0});
      Point p2 = Point.Create(new int[] {1, 1});

      Point m = Point.Middle(p1, p2, new Divide[] {Divide.Middle, Divide.Middle});

      Assert.AreEqual(1, m.Power);
      Assert.AreEqual(1, m.Points[0]);
      Assert.AreEqual(1, m.Points[1]);
    }

    [Test]
    public void Test_09()
    {
      Point p1 = Point.Create(new int[] {0, 0});
      Point p2 = Point.Create(new int[] {1, 1});

      Point m = Point.Middle(p1, p2, new Divide[] {Divide.First, Divide.Middle});

      Assert.AreEqual(1, m.Power);
      Assert.AreEqual(0, m.Points[0]);
      Assert.AreEqual(1, m.Points[1]);
    }

    [Test]
    public void Test_10()
    {
      Point p1 = Point.Create(new int[] {0, 0});
      Point p2 = Point.Create(new int[] {1, 1});

      Point m = Point.Middle(p1, p2, new Divide[] {Divide.Second, Divide.Middle});

      Assert.AreEqual(1, m.Power);
      Assert.AreEqual(2, m.Points[0]);
      Assert.AreEqual(1, m.Points[1]);
    }

    [Test]
    public void Test_11()
    {
      Point p1 = Point.Create(new int[] {0, 0});
      Point p2 = Point.Create(new int[] {1, 1});

      Point m = Point.Middle(p1, p2, new Divide[] {Divide.Middle, Divide.Middle});
      Point m1 = Point.Middle(p1, m, new Divide[] {Divide.Middle, Divide.Middle});

      Assert.AreEqual(2, m1.Power);
      Assert.AreEqual(1, m1.Points[0]);
      Assert.AreEqual(1, m1.Points[1]);
    }

    [Test]
    public void Test_12()
    {
      Point p1 = Point.Create(new int[] {0, 0});
      Point p2 = Point.Create(new int[] {1, 1});

      Point m = Point.Middle(p1, p2, new Divide[] {Divide.Middle, Divide.Middle});
      Point m1 = Point.Middle(p2, m, new Divide[] {Divide.Middle, Divide.Middle});

      Assert.AreEqual(2, m1.Power);
      Assert.AreEqual(3, m1.Points[0]);
      Assert.AreEqual(3, m1.Points[1]);
    }

    [Test]
    public void Test_13()
    {
      Point p1 = Point.Create(new int[] {0, 0});
      Point p2 = Point.Create(new int[] {1, 1});

      Point m = Point.Middle(p1, p2, new Divide[] {Divide.Middle, Divide.Middle});
      Point m1 = Point.Middle(p2, m, new Divide[] {Divide.First, Divide.Middle});

      Assert.AreEqual(2, m1.Power);
      Assert.AreEqual(4, m1.Points[0]);
      Assert.AreEqual(3, m1.Points[1]);
    }

    [Test]
    public void Test_14()
    {
      Point p1 = Point.Create(new int[] {0, 0});
      Point p2 = Point.Create(new int[] {1, 1});

      Point m = Point.Middle(p1, p2, new Divide[] {Divide.Middle, Divide.Middle});

      double[] t = new double[2];
      double[] t1 = new double[] {1, 1};
      double[] t2 = new double[] {2, 2};

      m.Evaluate(t1, t2, t);

      Assert.AreEqual(1.5, t[0]);
      Assert.AreEqual(1.5, t[1]);
    }

    [Test]
    public void Test_15()
    {
      Point p1 = Point.Create(new int[] {0, 0});
      Point p2 = Point.Create(new int[] {1, 1});

      Point m = Point.Middle(p1, p2, new Divide[] {Divide.Middle, Divide.Middle});
      m = Point.Middle(p1, m, new Divide[] {Divide.Middle, Divide.Middle});

      double[] t = new double[2];
      double[] t1 = new double[] {1, 1};
      double[] t2 = new double[] {2, 2};

      m.Evaluate(t1, t2, t);

      Assert.AreEqual(1.25, t[0]);
      Assert.AreEqual(1.25, t[1]);
    }
  }
}