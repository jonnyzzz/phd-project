/*
 * Created by: 
 * Created: 28 ÿםגאנÿ 2007 ד.
 */


using System.Collections.Generic;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.Core.Mock;
using DSIS.Core.System;
using DSIS.Function.Mock;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.Tests
{
  public abstract class MethodTestBase
  {
    protected abstract IIntegerCoordinateFactory IntegerCoordinateFactory { get; }

    protected void DoTestMethod(ISystemSpace space,
                                long[] testCoordinate,
                                ComputeFunction<double> compute,
                                ICellImageBuilderIntegerCoordinatesSettings settings,
                                string gold)
    {
      var ics = IntegerCoordinateFactory.Create(space, space.InitialSubdivision);
      ics.DoGeneric(new ICSWith2D(testCoordinate, compute, settings, gold));
    }

    private class ICSWith2D : IIntegerCoordinateSystemWith
    {
      private readonly long[] myTestCoordinate;
      private readonly ComputeFunction<double> myCompute;
      private readonly ICellImageBuilderIntegerCoordinatesSettings mySettings;
      private readonly string myGold;

      public ICSWith2D(long[] testCoordinate,
                       ComputeFunction<double> compute,
                       ICellImageBuilderIntegerCoordinatesSettings settings,
                       string gold)
      {
        myTestCoordinate = testCoordinate;
        myCompute = compute;
        mySettings = settings;
        myGold = gold;
      }

      public void Do<T, Q>(T system) where T : IIntegerCoordinateSystem<Q> where Q : IIntegerCoordinate
      {
        var q = system.Create(myTestCoordinate);
        Assert.IsNotNull(q);
        Assert.IsFalse(system.IsNull(q));

        var data = DoTest(system, q, myCompute, mySettings);
        switch(system.Dimension)
        {
          case 1: 
            OneDimCoordinateAssert.Assert(system, data, myGold);
            break;
          case 2:
            TwoDimCoordinateAssert.Assert(system, data, myGold);
            break;
          default:
            Assert.Fail("Dimension should be 2 or 1");
            break;
        }
      }

      private static List<Q> DoTest<T, Q>(T sys,
                                          Q test,
                                          ComputeFunction<double> compute,
                                          ICellImageBuilderIntegerCoordinatesSettings p)
        where T : IIntegerCoordinateSystem<Q>
        where Q : IIntegerCoordinate
      {
        var func = new MockSystemInfo<double>(compute, sys.SystemSpace);

        var man = new MockCollectingCellConnectionBuilder<Q>();

        var ctx =
          new CellImageBuilderContext<Q>(
            func,
            p,
            sys,
            man
            );

        var method = p.Create<Q>();
        method.Bind(ctx);

        method.BuildImage(test);

        return man.Result;
      }
    }
  }
}