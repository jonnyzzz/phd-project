/*
 * Created by: 
 * Created: 28 ÿםגאנÿ 2007 ד.
 */

using System.Collections.Generic;
using DSIS.CellImageBuilder.BexMethodTest;
using DSIS.Core.Coordinates;
using DSIS.Function.Mock;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Test;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod.Test
{
  [TestFixture]
  public class MethodTestBase<TM, TP> 
    where TM : ICellImageBuilder<IntegerCoordinate>, new()
    where TP : ICellImageBuilderSettings
  {
    public static List<IntegerCoordinate> DoTest(
      IntegerCoordinateSystem sys,
      IntegerCoordinate test,
      ComputeFunction<double> compute,
      TP p)
    {
      MockSystemInfo<double> func = new MockSystemInfo<double>(compute, sys.SystemSpace);
      IntegerCoordinateSystem cs = new IntegerCoordinateSystem(sys.SystemSpace);

      MockCellConnectionManager<IntegerCoordinate> man = 
        new MockCellConnectionManager<IntegerCoordinate>();

      CellImageBuilderContext<IntegerCoordinate> ctx =
        new CellImageBuilderContext<IntegerCoordinate>(
          func,
          p,
          cs,
          man
          );

      TM method = new TM();
      method.Bind(ctx);

      method.BuildImage(test);

      return man.Result;
    }

    public static void DoTwoDimTest(
      IntegerCoordinateSystem ics, 
      IntegerCoordinate test, 
      ComputeFunction<double> f, TP settins, string gold)
    {
      List<IntegerCoordinate> data = DoTest(ics, test, f, settins);
      TwoDimCoordinateAssert.Assert(ics, data, gold);
    }

    public static List<IntegerCoordinate> DoTestOneDimension(
      IntegerCoordinateSystem ics,
      double coord, ComputeOneFunction<double> func, TP eps)
    {
      return DoTest(
        ics,
        ics.FromPoint(
          new double[] {coord}),
        delegate(double[] ins, double[] outs) { outs[0] = func(ins[0]); }, eps);
    }

    public static void DoTestOneDimensionAndAssert(
      double l, double r, long g, double coord, TP eps,
      ComputeOneFunction<double> func, double fl, double fr)
    {
      MockSystemSpace ss = new MockSystemSpace(1, l, r, g);
      IntegerCoordinateSystem ics = new IntegerCoordinateSystem(ss);

      List<IntegerCoordinate> list = DoTestOneDimension(ics, coord, func, eps);
      List<long> result =
        list.ConvertAll<long>(
          delegate(IntegerCoordinate input)
            {
              return ((IIntegerCoordinateDebug) input).Coordinate[0];
            });
      result.Sort();

      IntegerCoordinate ifl = ics.FromPoint(new double[] {fl});
      IntegerCoordinate ifr = ics.FromPoint(new double[] {fr});

      Assert.IsNotNull(ifl);
      Assert.IsNotNull(ifr);

      long[] cifl = ((IIntegerCoordinateDebug)ifl).Coordinate;
      long[] cirt = ((IIntegerCoordinateDebug)ifr).Coordinate;

      Assert.IsTrue(cirt.Length > 0);
      Assert.IsTrue(cifl.Length > 0);

      Assert.IsTrue(result.Count > 0, "No result!");

      Assert.AreEqual(cifl[0], result[0], "Left side");      
      Assert.AreEqual(cirt[0], result[result.Count - 1], "Right side");
    }
  }
}