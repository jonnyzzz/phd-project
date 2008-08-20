/*
 * Created by: 
 * Created: 28 ÿםגאנÿ 2007 ד.
 */

using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.Core.Mock;
using DSIS.Function.Mock;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.Shared
{
  public abstract class MethodTestBase<T,Q, TM, TP>
    where TM : ICellImageBuilder<Q>, new()
    where TP : ICellImageBuilderSettings
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    public static List<Q> DoTest(
      T sys,
      Q test,
      ComputeFunction<double> compute,
      TP p)
    {
      MockSystemInfo<double> func = new MockSystemInfo<double>(compute, sys.SystemSpace);
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(sys.SystemSpace);

      MockCollectingCellConnectionBuilder<Q> man =
        new MockCollectingCellConnectionBuilder<Q>();

      CellImageBuilderContext<Q> ctx =
        new CellImageBuilderContext<Q>(
          func,
          p,
          ics,
          man
          );

      TM method = new TM();
      method.Bind(ctx);

      method.BuildImage(test);

      return man.Result;
    }

    public static void DoTwoDimTest(
      T ics,
      Q test,
      ComputeFunction<double> f, TP settins, string gold)
    {
      List<Q> data = DoTest(ics, test, f, settins);
      TwoDimCoordinateAssert.Assert(ics, data, gold);
    }

    public static List<Q> DoTestOneDimension(
      T ics,
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
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T,Q>(ss);

      List<Q> list = DoTestOneDimension(ics, coord, func, eps);
      List<long> result =
        list.ConvertAll<long>(
          delegate(Q input) { return input.GetCoordinate(0); });
      result.Sort();

      Q ifl = ics.FromPoint(new double[] {fl});
      Q ifr = ics.FromPoint(new double[] {fr});

      Assert.IsNotNull(ifl);
      Assert.IsNotNull(ifr);

      Assert.IsTrue(result.Count > 0, "No result!");

      Assert.AreEqual(ifl.GetCoordinate(0), result[0], "Left side");
      Assert.AreEqual(ifr.GetCoordinate(0), result[result.Count - 1], "Right side");
    }
  }
}