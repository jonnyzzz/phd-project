using DSIS.CellImageBuilder.Shared;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;
using DSIS.IntegerCoordinates.Impl;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.AdaptiveMethod
{
  [TestFixture]
  public class AdaptiveMethodTest : AdaptiveMethodTestBase<IntegerCoordinateSystem, IntegerCoordinate>
  {
    
  }

  [TestFixture]
  public class AdaptiveMethodTest2d : AdaptiveMethodTestBase<IntegerCoordinateSystem2d, IntegerCoordinate2d>
  {
    
  }

  public class AdaptiveMethodTestBase<T, Q> : MethodTestBase<T, Q, AdaptiveMethod<T, Q>, AdaptiveMethodSettings>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    private static readonly AdaptiveMethodSettings SETTINGS = new AdaptiveMethodSettings();

    [Test]
    public void Test_02()
    {
      MockSystemSpace ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);


      DoTwoDimTest(ics, ics.Create(5, 5),
                   delegate(double[] ins, double[] outs)
                   {
                     outs[0] = ins[0];
                     outs[1] = ins[1];
                   }, SETTINGS,
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
      MockSystemSpace ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);


      DoTwoDimTest(ics, ics.Create(5, 5),
                   delegate(double[] ins, double[] outs)
                   {
                     outs[0] = 5;
                     outs[1] = 5;
                   }, SETTINGS,
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
      MockSystemSpace ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);


      DoTwoDimTest(ics, ics.Create(2, 2),
                   delegate(double[] ins, double[] outs)
                   {
                     outs[0] = 2 * ins[0];
                     outs[1] = 2 * ins[1];
                   }, SETTINGS,
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
      MockSystemSpace ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);


      DoTwoDimTest(ics, ics.Create(1, 1),
                   delegate(double[] ins, double[] outs)
                   {
                     outs[0] = 0.1 * ins[0];
                     outs[1] = 7 * ins[1];
                   }, SETTINGS,
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
      MockSystemSpace ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);


      DoTwoDimTest(ics, ics.Create(1, 1),
                   delegate(double[] ins, double[] outs)
                   {
                     outs[0] = 3 + 0.1 * ins[0];
                     outs[1] = 7 * ins[1] - 2;
                   }, SETTINGS,
                   @"-------------------
..........
..........
....xxxxxx
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
      MockSystemSpace ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(ss);


      DoTwoDimTest(ics, ics.Create(1, 1),
                   delegate(double[] ins, double[] outs)
                   {
                     outs[0] = 3.45 + 0.001 * ins[0];
                     outs[1] = 0.001 * ins[1] + 2.66;
                   }, SETTINGS,
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