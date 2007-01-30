using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod.Test
{
  [TestFixture]
  public class BoxAdaptiveMethodTest : MethodTestBase<BoxAdaptiveMethod, BoxAdaptiveMethodSettings>
  {
    [Test]
    public void Test_01()
    {
      BoxAdaptiveMethodSettings stategy = new BoxAdaptiveMethodSettings(
        100, BoxAdaptiveMethodStategy.Simple, 0.1);
      DoTestOneDimensionAndAssert(0, 10, 10,
                                  5, stategy,
                                  delegate(double ins) { return ins; }, 4, 6);
    }

    [Test]
    public void Test_02()
    {
      BoxAdaptiveMethodSettings stategy = new BoxAdaptiveMethodSettings(
              100, BoxAdaptiveMethodStategy.Simple, 0.1);

      MockSystemSpace ss = new MockSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {10, 10});
      IntegerCoordinateSystem ics = new IntegerCoordinateSystem(ss);


      DoTwoDimTest(ics, new IntegerCoordinate(5,5), 
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
      BoxAdaptiveMethodSettings stategy = new BoxAdaptiveMethodSettings(
              100, BoxAdaptiveMethodStategy.Simple, 0.1);

      MockSystemSpace ss = new MockSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {10, 10});
      IntegerCoordinateSystem ics = new IntegerCoordinateSystem(ss);


      DoTwoDimTest(ics, new IntegerCoordinate(5,5), 
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
      BoxAdaptiveMethodSettings stategy = new BoxAdaptiveMethodSettings(
              100, BoxAdaptiveMethodStategy.Simple, 0.1);

      MockSystemSpace ss = new MockSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {10, 10});
      IntegerCoordinateSystem ics = new IntegerCoordinateSystem(ss);


      DoTwoDimTest(ics, new IntegerCoordinate(2,2), 
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
      BoxAdaptiveMethodSettings stategy = new BoxAdaptiveMethodSettings(
              100, BoxAdaptiveMethodStategy.Simple, 0.1);

      MockSystemSpace ss = new MockSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {10, 10});
      IntegerCoordinateSystem ics = new IntegerCoordinateSystem(ss);


      DoTwoDimTest(ics, new IntegerCoordinate(1,1), 
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
      BoxAdaptiveMethodSettings stategy = new BoxAdaptiveMethodSettings(
              100, BoxAdaptiveMethodStategy.Simple, 0.1);

      MockSystemSpace ss = new MockSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {10, 10});
      IntegerCoordinateSystem ics = new IntegerCoordinateSystem(ss);


      DoTwoDimTest(ics, new IntegerCoordinate(1,1), 
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
      BoxAdaptiveMethodSettings stategy = new BoxAdaptiveMethodSettings(
              100, BoxAdaptiveMethodStategy.Simple, 0.1);

      MockSystemSpace ss = new MockSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {10, 10});
      IntegerCoordinateSystem ics = new IntegerCoordinateSystem(ss);


      DoTwoDimTest(ics, new IntegerCoordinate(1,1), 
        delegate(double[] ins, double[] outs)
          {
            outs[0] = 3.45+ 0.001*ins[0];
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
