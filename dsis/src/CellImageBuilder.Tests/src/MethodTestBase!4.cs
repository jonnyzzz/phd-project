using System;
using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.Core.Mock;
using DSIS.Function.Mock;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.Shared
{
  [Obsolete("Use TestMethodBase`0")]
  public abstract class MethodTestBase<T,Q, TM, TP>
    where TM : ICellImageBuilder<Q>, new()
    where TP : ICellImageBuilderSettings
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    private static List<Q> DoTest(T sys, Q test, ComputeFunction<double> compute, TP p)
    {
      var func = new MockSystemInfo<double>(compute, sys.SystemSpace);
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(sys.SystemSpace);

      var man = new MockCollectingCellConnectionBuilder<Q>();

      var ctx =
        new CellImageBuilderContext<Q>(
          func,
          p,
          ics,
          man
          );

      var method = new TM();
      method.Bind(ctx);

      method.BuildImage(test);

      return man.Result;
    }

    protected static void DoTwoDimTest(T ics, Q test, ComputeFunction<double> f, TP settins, string gold)
    {
      var data = DoTest(ics, test, f, settins);
      TwoDimCoordinateAssert.Assert(ics, data, gold);
    }

    protected static void DoTestOneDimensionAndAssert(
      double l, double r, long g, double coord, TP eps,
      ComputeOneFunction<double> func, double fl, double fr)
    {
      var ss = new MockSystemSpace(1, l, r, g);
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T,Q>(ss);

      var list = DoTest(
                         ics,
                         ics.FromPoint(
                                              new[] {coord}),
                         delegate(double[] ins, double[] outs) { outs[0] = func(ins[0]); }, eps);
      var result = list.ConvertAll(input => input.GetCoordinate(0));
      result.Sort();

      Q ifl = ics.FromPoint(new[] {fl});
      Q ifr = ics.FromPoint(new[] {fr});

      Assert.IsNotNull(ifl);
      Assert.IsNotNull(ifr);

      Assert.IsTrue(result.Count > 0, "No result!");

      Assert.AreEqual(ifl.GetCoordinate(0), result[0], "Left side");
      Assert.AreEqual(ifr.GetCoordinate(0), result[result.Count - 1], "Right side");
    }
  }
}