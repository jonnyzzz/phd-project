using System.IO;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Function.Predefined.Henon;
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


      new HenonFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>(myHomePath, myWorkPath, 7).ComputeAllMethods();
    }


    public class HenonFullBuilder<T,Q> : FullImageBuilder<T,Q> 
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate<Q> 
    {
      public HenonFullBuilder(string homePath, string rootPath, int steps) : base(homePath, rootPath, steps)
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