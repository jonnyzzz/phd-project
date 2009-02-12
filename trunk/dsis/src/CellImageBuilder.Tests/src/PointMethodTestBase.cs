using DSIS.CellImageBuilder.PointMethod;
using DSIS.CellImageBuilder.Shared;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.Tests
{
  public abstract class PointMethodTestBase<T, Q> :
    MethodTestBase<T, Q, PointMethod<Q>, PointMethodSettings>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    private PointMethodSettings stategy { get { return new PointMethodSettings { Points = 2, UseOverlapping = false, Overlap = 0 }; } }
    private PointMethodSettings stategy2 { get { return new PointMethodSettings { Points = 2, UseOverlapping = true, Overlap = 0.3 }; } }

      [Test]
    public void Test_01()
    {
      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);

      DoTwoDimTest(ics, ics.Create(5, 5),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = ins[0];
                       outs[1] = ins[1] / 7;
                     }, new PointMethodSettings{Points=2},
                   @"-------------------
..........
..........
..........
..........
..........
x.........
x.........
..........
..........
..........
-------------------
");
    }


    [Test]
    public void Test_02()
    {
      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);

      DoTwoDimTest(ics, ics.Create(5, 5),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = ins[0];
                       outs[1] = ins[1];
                     }, stategy,
                   @"-------------------
..........
..........
..........
..........
..........
.....xx...
.....xx...
..........
..........
..........
-------------------
");
    }

    [Test]
    public void Test_03()
    {
      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);


      DoTwoDimTest(ics, ics.Create(5, 5),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = 5;
                       outs[1] = 5;
                     }, stategy,
                   @"-------------------
..........
..........
..........
..........
..........
.....x....
..........
..........
..........
..........
-------------------
");
    }

    [Test]
    public void Test_04()
    {
      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);


      DoTwoDimTest(ics, ics.Create(2, 2),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = 2 * ins[0];
                       outs[1] = 2 * ins[1];
                     }, stategy,
                   @"-------------------
..........
..........
..........
..........
....x.x...
..........
....x.x...
..........
..........
..........
-------------------
");
    }

    [Test]
    public void Test_05()
    {
      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);


      DoTwoDimTest(ics, ics.Create(1, 1),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = 0.1 * ins[0];
                       outs[1] = 7 * ins[1];
                     }, stategy,
                   @"-------------------
.......x..
..........
..........
..........
..........
..........
..........
..........
..........
..........
-------------------
");
    }

    [Test]
    public void Test_06()
    {
      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);


      DoTwoDimTest(ics, ics.Create(1, 1),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = 3 + 0.1 * ins[0];
                       outs[1] = 7 * ins[1] - 2;
                     }, stategy,
                   @"-------------------
..........
..........
..........
.....x....
..........
..........
..........
..........
..........
..........
-------------------
");
    }

    [Test]
    public void Test_07()
    {
      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);


      DoTwoDimTest(ics, ics.Create(1, 1),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = 3.45 + 0.001 * ins[0];
                       outs[1] = 0.001 * ins[1] + 2.66;
                     }, stategy,
                   @"-------------------
..........
..........
..........
..x.......
..........
..........
..........
..........
..........
..........
-------------------
");
    }
    [Test]
    public void Test_08()
    {
      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);

      DoTwoDimTest(ics, ics.Create(5, 5),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = ins[0];
                       outs[1] = ins[1];
                     }, stategy2,
                   @"-------------------
..........
..........
..........
..........
..........
.....xx...
.....xx...
..........
..........
..........
-------------------
");
    }

    [Test]
    public void Test_09()
    {
      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);


      DoTwoDimTest(ics, ics.Create(5, 5),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = 5;
                       outs[1] = 5;
                     }, stategy2,
                   @"-------------------
..........
..........
..........
..........
..........
.....x....
..........
..........
..........
..........
-------------------
");
    }

    [Test]
    public void Test_10()
    {
      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);


      DoTwoDimTest(ics, ics.Create(2, 2),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = 2 * ins[0];
                       outs[1] = 2 * ins[1];
                     }, stategy2,
                   @"-------------------
..........
..........
..........
..........
....x.x...
..........
....x.x...
..........
..........
..........
-------------------
");
    }

    [Test]
    public void Test_11()
    {
      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);


      DoTwoDimTest(ics, ics.Create(1, 1),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = 0.1 * ins[0];
                       outs[1] = 7 * ins[1];
                     }, stategy2,
                   @"-------------------
.......x..
..........
..........
..........
..........
..........
..........
..........
..........
..........
-------------------
");
    }

    [Test]
    public void Test_12()
    {
      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);


      DoTwoDimTest(ics, ics.Create(1, 1),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = 3 + 0.1 * ins[0];
                       outs[1] = 7 * ins[1] - 2;
                     }, stategy2,
                   @"-------------------
..........
..........
..........
.....x....
..........
..........
..........
..........
..........
..........
-------------------
");
    }

    [Test]
    public void Test_13()
    {
      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);


      DoTwoDimTest(ics, ics.Create(1, 1),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = 3.45 + 0.001 * ins[0];
                       outs[1] = 0.001 * ins[1] + 2.66;
                     }, stategy2,
                   @"-------------------
..........
..........
..........
..x.......
..........
..........
..........
..........
..........
..........
-------------------
");
    }
    
    [Test]
    public void Test_14()
    {
      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);

      DoTwoDimTest(ics, ics.Create(2, 2),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = ins[0];
                       outs[1] = ins[1] * 3;
                     }, new PointMethodSettings{Points=2},
                   @"-------------------
..........
..........
......x..x
......x..x
..........
..........
..........
..........
..........
..........
-------------------
");
    }

    [Test]
    public void Test_15()
    {
      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);

      DoTwoDimTest(ics, ics.Create(2, 2),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = ins[0];
                       outs[1] = ins[1] * 3;
                     }, new PointMethodSettings{Points=3, UseOverlapping = true, Overlap = 0.3},
                   @"-------------------
..........
..........
......x..x
......x..x
..........
..........
..........
..........
..........
..........
-------------------
");
    }
  }
}