using DSIS.CellImageBuilder.Shared;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.BexMethodTest
{
  [TestFixture]
  public class BoxMethodTest : MethodTestBase<BoxMethod.BoxMethod, BoxMethodSettings>
  {
    [Test]
    public void Test_01()
    {
      DoTestOneDimensionAndAssert(0, 10, 10, 5, new BoxMethodSettings(0), delegate(double ins) { return ins; }, 5, 6);
    }

    [Test]
    public void Test_02()
    {
      BoxMethodSettings stategy = new BoxMethodSettings(0.1);

      MockSystemSpace ss = new MockSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {10, 10});
      IntegerCoordinateSystem ics = new IntegerCoordinateSystem(ss);


      DoTwoDimTest(ics, new IntegerCoordinate(5, 5),
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
....xxx...
....xxx...
....xxx...
..........
..........
..........
-------------------
");
    }

    [Test]
    public void Test_03()
    {
      BoxMethodSettings stategy = new BoxMethodSettings(0.1);

      MockSystemSpace ss = new MockSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {10, 10});
      IntegerCoordinateSystem ics = new IntegerCoordinateSystem(ss);


      DoTwoDimTest(ics, new IntegerCoordinate(5, 5),
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
....xx....
....xx....
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
      BoxMethodSettings stategy = new BoxMethodSettings(0.1);

      MockSystemSpace ss = new MockSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {10, 10});
      IntegerCoordinateSystem ics = new IntegerCoordinateSystem(ss);


      DoTwoDimTest(ics, new IntegerCoordinate(2, 2),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = 2*ins[0];
                       outs[1] = 2*ins[1];
                     }, stategy,
                   @"-------------------
..........
..........
..........
...xxxx...
...xxxx...
...xxxx...
...xxxx...
..........
..........
..........
-------------------
");
    }

    [Test]
    public void Test_05()
    {
      BoxMethodSettings stategy = new BoxMethodSettings(0.1);

      MockSystemSpace ss = new MockSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {10, 10});
      IntegerCoordinateSystem ics = new IntegerCoordinateSystem(ss);


      DoTwoDimTest(ics, new IntegerCoordinate(1, 1),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = 0.1*ins[0];
                       outs[1] = 7*ins[1];
                     }, stategy,
                   @"-------------------
......xxxx
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
      BoxMethodSettings stategy = new BoxMethodSettings(0.1);

      MockSystemSpace ss = new MockSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {10, 10});
      IntegerCoordinateSystem ics = new IntegerCoordinateSystem(ss);


      DoTwoDimTest(ics, new IntegerCoordinate(1, 1),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = 3 + 0.1*ins[0];
                       outs[1] = 7*ins[1] - 2;
                     }, stategy,
                   @"-------------------
..........
..........
..........
....xxxxxx
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
      BoxMethodSettings stategy = new BoxMethodSettings(0.1);

      MockSystemSpace ss = new MockSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {10, 10});
      IntegerCoordinateSystem ics = new IntegerCoordinateSystem(ss);


      DoTwoDimTest(ics, new IntegerCoordinate(1, 1),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = 3.45 + 0.001*ins[0];
                       outs[1] = 0.001*ins[1] + 2.66;
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
  }
}