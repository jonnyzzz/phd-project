using System;
using System.IO;
using System.Threading;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Core.Util;
using DSIS.Function.Predefined.Delayed;
using DSIS.Function.Predefined.Henon;
using DSIS.Function.Predefined.Ikeda;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;

namespace DSIS.SimpleRunner
{
  public class Program
  {
    private static string myWorkPath;
    private static string myHomePath;

    private static void Main()
    {
      string prePath = Path.GetDirectoryName(typeof (Program).Assembly.CodeBase);
      if (prePath.StartsWith("file:\\"))
        prePath = prePath.Substring("file:\\".Length);

      myHomePath = Path.GetFullPath(Path.Combine(prePath, @"..\..\..\..\"));
      myWorkPath = Path.Combine(Path.GetFullPath(Path.Combine(myHomePath, @"results")), 
        DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss"));

      if (Directory.Exists(myWorkPath))
        Directory.Delete(myWorkPath);

      Directory.CreateDirectory(myWorkPath);

      Console.Out.WriteLine("Work directory: {0}", myWorkPath);

      for (int i = -3; i < 1000; i++)
      {
        new DelayedFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>
          (2.27, myWorkPath, 6 + i).ComputeAllMethods(NullProgressInfo.INSTANCE);

        new DelayedFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>
          (2.21, myWorkPath, 6 + i).ComputeAllMethods(NullProgressInfo.INSTANCE);

        new HenonFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>
          (myWorkPath, 9 + i).ComputeAllMethods(NullProgressInfo.INSTANCE);

        new IkedaFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>
          (myWorkPath, 6 + i).ComputeAllMethods(NullProgressInfo.INSTANCE);

        Console.Out.WriteLine("Loop Complete. ");

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        break;
        Thread.Sleep(5000);
      }
    }


    public class HenonFullBuilder<T, Q> : FullImageBuilderWithLog<T, Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate<Q>
    {
      public HenonFullBuilder(string homePath, int steps) :
        base(homePath, steps, -1)
      {
      }


      protected override ISystemInfo CreateSystemInfo()
      {
        DefaultSystemSpace space = new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {10, 10});
        return new HenonFunctionSystemInfoDecorator(space, 1.4);
      }

      protected override long[] Subdivide
      {
        get { return new long[]{2,2}; }
      }
    }


    public class IkedaFullBuilder<T, Q> : FullImageBuilderWithLog<T, Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate<Q>
    {
      public IkedaFullBuilder(string homePath, int steps):
        base(homePath, steps, -1)
      {
      }

      protected override ISystemInfo CreateSystemInfo()
      {
        DefaultSystemSpace space = new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {10, 10});
        return new IkedaFunctionSystemInfoDecorator(space);
      }

      protected override long[] Subdivide
      {
        get { return new long[]{2,2}; }
      }
    }

    public class DelayedFullBuilder<T, Q> : FullImageBuilderWithLog<T,Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate<Q>
    {
      private readonly double myA;

      public DelayedFullBuilder(double a, string homePath, int steps) :
        base(homePath, steps, -1)
      {
        myA = a;
      }

      protected override long[] Subdivide
      {
        get { return new long[] {2, 2}; }
      }

      protected override ISystemInfo CreateSystemInfo()
      {
        ISystemSpace sp = new DefaultSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {2, 2});
        return new DelayedFunctionSystemInfo(sp, myA);
      }
    }
  }
}