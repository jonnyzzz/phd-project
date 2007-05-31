using System;
using System.IO;
using System.Threading;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
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
      myWorkPath = Path.GetFullPath(Path.Combine(myHomePath, @"results"));

      for (int i = 0;; i++)
      {
        new DelayedFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>
          (2.27, myHomePath, myWorkPath, 6 + i).ComputeAllMethods();

        new DelayedFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>
          (2.21, myHomePath, myWorkPath, 6 + i).ComputeAllMethods();

        new HenonFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>
          (myHomePath, myWorkPath, 9 + i).ComputeAllMethods();

        new IkedaFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>
          (myHomePath, myWorkPath, 6 + i).ComputeAllMethods();

        Console.Out.WriteLine("Loop Complete. ");
        Console.Out.WriteLine("Loop Complete. ");
        Console.Out.WriteLine("Loop Complete. ");
        Console.Out.WriteLine("Loop Complete. ");
        Console.Out.WriteLine("Loop Complete. ");
        Console.Out.WriteLine("Loop Complete. ");
        Console.Out.WriteLine("Loop Complete. ");
        Console.Out.WriteLine("Loop Complete. ");
        Console.Out.WriteLine("Loop Complete. ");
        Console.Out.WriteLine("Loop Complete. ");

        Thread.Sleep(5000);
      }
    }


    public class HenonFullBuilder<T, Q> : FullImageBuilder<T, Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate<Q>
    {
      public HenonFullBuilder(string homePath, string rootPath, int steps) :
        base(homePath, rootPath, steps, "Henon")
      {
      }

      protected override ISystemSpace CreateSystemSpace()
      {
        return new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {10, 10});
      }

      protected override ISystemInfo CreateSystemFunction(ISystemSpace space)
      {
        return new HenonFunctionSystemInfoDecorator(space, 1.4);
      }
    }

    public class IkedaFullBuilder<T, Q> : FullImageBuilder<T, Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate<Q>
    {
      public IkedaFullBuilder(string homePath, string rootPath, int steps) :
        base(homePath, rootPath, steps, "Ikeda")
      {
      }

      protected override ISystemSpace CreateSystemSpace()
      {
        return new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {10, 10});
      }

      protected override ISystemInfo CreateSystemFunction(ISystemSpace space)
      {
        return new IkedaFunctionSystemInfoDecorator(space);
      }
    }

    public class DelayedFullBuilder<T, Q> : FullImageBuilder<T, Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate<Q>
    {
      private readonly double myA;

      public DelayedFullBuilder(double a, string homePath, string rootPath, int steps) :
        base(homePath, rootPath, steps, "Delayed " + a)
      {
        myA = a;
      }

      protected override ISystemSpace CreateSystemSpace()
      {
        return new DefaultSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {2, 2});
      }

      protected override ISystemInfo CreateSystemFunction(ISystemSpace space)
      {
        return new DelayedFunctionSystemInfo(space, myA);
      }
    }


    private static ISystemInfo GetFunction(ISystemSpace sp)
    {
//      return new JuliaFuctionSystemInfoDecorator(sp);
//      return new IkedaFunctionSystemInfoDecorator(sp);
      return new HenonFunctionSystemInfoDecorator(sp, 1.4);
//      return new DelayedFunctionSystemInfo(sp, 2.27);
      //return new FoodChainSystemInfo(sp);
    }

    private static DefaultSystemSpace GetSystemSpace()
    {
      return new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {10, 10});
//      return new DefaultSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {2, 2});
      //return new DefaultSystemSpace(3, new double[] {0.001, 0.001, 0.001}, new double[] {10, 10, 10}, new long[] {2, 2, 2});
    }
  }
}