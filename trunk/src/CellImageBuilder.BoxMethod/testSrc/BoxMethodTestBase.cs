using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Function.Mock;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.BexMethodTest
{
  [TestFixture]
  public class BoxMethodTestBase
  {
    private List<IntegerCoordinate> DoTest(
      IntegerCoordinateSystem sys,
      IntegerCoordinate test,
      ComputeFunction<double> compute,
      double eps)
    {
      MockSystemInfo<double> func = new MockSystemInfo<double>(compute, sys.SystemSpace);
      IntegerCoordinateSystem cs = new IntegerCoordinateSystem(sys.SystemSpace);

      MockCellConnectionManager<IntegerCoordinate> man = new MockCellConnectionManager<IntegerCoordinate>();

      CellImageBuilderContext<IntegerCoordinate> ctx =
        new CellImageBuilderContext<IntegerCoordinate>(
          func,
          new BoxMethodParameters(eps),
          cs,
          man
          );

      BoxMethod method = new BoxMethod();
      method.Bind(ctx);

      method.BuildImage(test);

      return man.Result;
    }

    private List<IntegerCoordinate> DoTestOneDimension(
      IntegerCoordinateSystem ics,
      double coord, ComputeOneFunction<double> func, double eps)
    {
      return DoTest(
        ics, 
        ics.FromPoint(
        new double[] {coord}), 
        delegate(double[] ins, double[] outs)
          {
            outs[0] = func(ins[0]);
          }, eps);      
    }

    private void DoTestOneDimensionAndAssert(
      double l, double r, long g, double coord, double eps, 
      ComputeOneFunction<double> func, double fl, double fr)
    {
      MockSystemSpace ss = new MockSystemSpace(1, l, r, g);
      IntegerCoordinateSystem ics = new IntegerCoordinateSystem(ss);

      List<IntegerCoordinate> list = DoTestOneDimension(ics, coord, func, eps);
      List<long> result = list.ConvertAll<long>(delegate(IntegerCoordinate input) { return ((IIntegerCoordinateDebug) input).Coordinate[0]; });
      result.Sort();

      Assert.AreEqual(((IIntegerCoordinateDebug) ics.FromPoint(new double[] {fl})).Coordinate[0], result[0], "Left side");
      Assert.AreEqual(((IIntegerCoordinateDebug) ics.FromPoint(new double[] {fr})).Coordinate[0], result[result.Count-1], "Right side");
    }

    [Test]
    public void Test_01()
    {
      DoTestOneDimensionAndAssert(0, 10, 10, 5, 0, delegate(double ins) { return ins; }, 5, 5);      
    }
  }
}