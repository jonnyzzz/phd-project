using System;
using DSIS.Core.Builders;
using DSIS.Core.Mock;
using DSIS.Function.Mock;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod.Test
{
  [TestFixture]
  public class BoxAdaptiveMethodPerformanceTest
  {
    [Test]
    public void Test_01()
    {
      const double factor = 1;
      MockSystemSpace ss = new MockSystemSpace(2, new double[] {-1, -1}, new double[] {1, 1}, new long[] {100, 100});
      IIntegerCoordinateSystem<IntegerCoordinate> ics = IntegerCoordinateSystemFactory.Create(ss);
      MockSystemInfo<double> si = new MockSystemInfo<double>(delegate(double[] ins, double[] outs)
                                                               {
                                                                 for (int i = 0; i < outs.Length; i++)
                                                                   outs[i] = ins[i]*factor;
                                                               }, ss);

      BoxAdaptiveMethod m = new BoxAdaptiveMethod();
      m.Bind(new CellImageBuilderContext<IntegerCoordinate>(
               si, BoxAdaptiveMethodSettings.Default, ics, new MockCellConnectionBuilder<IntegerCoordinate>()
               ));

      for (int i = 30; i < 60; i++)
        for (int j = 40; j < 70; j++)
          m.BuildImage(ics.Create(i, j));

      long mem = GC.GetTotalMemory(true);

      Console.Out.WriteLine("mem = {0} Mb", mem/1024.0/1024.0);
    }
  }
}