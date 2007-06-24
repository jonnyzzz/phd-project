using System;
using System.Collections.Generic;
using System.IO;
using DSIS.CellImageBuilder;
using DSIS.CellImageBuilder.BoxMethod;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.Processor;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Core.Util;
using DSIS.Function.Predefined.Delayed;
using DSIS.Function.Predefined.Duffing;
using DSIS.Function.Predefined.Henon;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Function.Predefined.Julia;
using DSIS.Function.Predefined.VanDerPol;
using DSIS.Function.Solvers.RungeKutt;
using DSIS.Function.Solvers.SimpleSolver;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;
using DSIS.Utils;

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
                                DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss"));

      if (Directory.Exists(myWorkPath))
        Directory.Delete(myWorkPath);

      Directory.CreateDirectory(myWorkPath);

      List<string> myXSLTs = new List<string>();

      foreach (string name in typeof (Program).Assembly.GetManifestResourceNames())
      {
        if (name.Contains(".xslt."))
        {
          string fileName = name.Substring(name.IndexOf(".xslt.") + ".xslt.".Length);
          string xsltFile = Path.Combine(myWorkPath, fileName);
          myXSLTs.Add(xsltFile);
          using (Stream str = File.Create(xsltFile))
          {
            using (Stream input = typeof (Program).Assembly.GetManifestResourceStream(name))
            {
              byte[] buff = new byte[65536];
              int read;
              while ((read = input.Read(buff, 0, buff.Length)) > 0)
                str.Write(buff, 0, read);
            }
          }
        }
      }

      Console.Out.WriteLine("Work directory: {0}", myWorkPath);      
//      Do(new DuffingFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>(myWorkPath, 8), myXSLTs);
      Do(new VanDerPolFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>(myWorkPath, 5), myXSLTs);

//      int i = 0;
//      Do(new HenonFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>(myWorkPath, 13 + i), myXSLTs);
//      Do(new IkedaFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>(myWorkPath, 10 + i), myXSLTs);
//      Do(new JuliaFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>(myWorkPath, 12 + i), myXSLTs);
//      Do(new DelayedFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>(2.21, myWorkPath, 13 + i), myXSLTs);
//      Do(new DelayedFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>(2.27, myWorkPath, 13 + i), myXSLTs);
//
//      for (double a = 2; a >= 1.5; a -= 0.1)
//      {
//        Do(new DelayedFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>
//             (a, myWorkPath, 10), myXSLTs);
//      }
//
//      Do(new DelayedFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>
//           (2.21, myWorkPath, 6 + i), myXSLTs);
//
//      Do(new HenonFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>
//           (myWorkPath, 9 + i), myXSLTs);
//
//      Do(new IkedaFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>
//           (myWorkPath, 6 + i), myXSLTs);

      Console.Out.WriteLine("Loop Complete. ");
    }

    public static void Do<T, Q>(FullImageBuilderWithLog<T, Q> action, List<string> xslt)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate<Q>
    {
      action.ComputeAllMethods(NullProgressInfo.INSTANCE);
      action.ApplyXSL(xslt);
    }


    public class DuffingFullBuilder<T, Q> : FullImageBuilderWithLog<T, Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate<Q>
    {
      public DuffingFullBuilder(string homePath, int steps)
        :
        base(homePath, steps, -1)
      {
      }

      protected override ICollection<Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>> GetMethods()
      {
        return new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>[]
          {
            new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>(
            new BoxMethod<T,Q>(), BoxMethodSettings.Default), 
          };
      }

      protected override ISystemInfo CreateSystemInfo()
      {
        DefaultSystemSpace space =
          new DefaultSystemSpace(2, new double[] { -10, -10 }, new double[] { 10, 10 }, new long[] { 10, 10 });
        return new RungeKuttSolver(new DuffingSystemInfo(space, -1, 0.27, 0.48), 5, 1);
      }

      protected override long[] Subdivide
      {
        get { return new long[] { 2, 2 }; }
      }
    }

    
    public class VanDerPolFullBuilder<T, Q> : FullImageBuilderWithLog<T, Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate<Q>
    {
      public VanDerPolFullBuilder(string homePath, int steps)
        :
        base(homePath, steps, -1)
      {
      }


      protected override ICellProcessor<Q, Q> CreateCellConstructionProcess()
      {
        return new ThreadedSymbolicImageConstructionProcess<Q, Q>();
      }

      protected override ICollection<Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>> GetMethods()
      {
        return new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>[]
          {
            new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>(
            new BoxMethod<T,Q>(), BoxMethodSettings.Default), 
          };
      }

      protected override ISystemInfo CreateSystemInfo()
      {
        DefaultSystemSpace space =
          new DefaultSystemSpace(2, new double[] { -5, -5 }, new double[] { 5, 5}, new long[] { 10, 10 });
        return new RungeKuttSolver(new VanDerPolSystemInfo(space, 1.5), 15, 1);
      }

      protected override long[] Subdivide
      {
        get { return new long[] { 2, 2 }; }
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
        DefaultSystemSpace space =
          new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {10, 10});
        return new HenonFunctionSystemInfoDecorator(space, 1.4);
      }

      protected override long[] Subdivide
      {
        get { return new long[] {2, 2}; }
      }
    }

    public class IkedaFullBuilder<T, Q> : FullImageBuilderWithLog<T, Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate<Q>
    {
      public IkedaFullBuilder(string homePath, int steps) :
        base(homePath, steps, -1)
      {
      }

      protected override ISystemInfo CreateSystemInfo()
      {
        DefaultSystemSpace space =
          new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {10, 10});
        return new IkedaFunctionSystemInfoDecorator(space);
      }

      protected override long[] Subdivide
      {
        get { return new long[] {2, 2}; }
      }
    }

    public class DelayedFullBuilder<T, Q> : FullImageBuilderWithLog<T, Q>
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
    
    public class JuliaFullBuilder<T, Q> : FullImageBuilderWithLog<T, Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate<Q>
    {
      public JuliaFullBuilder(string homePath, int steps) :
        base(homePath, steps, -1)
      {
      }

      protected override long[] Subdivide
      {
        get { return new long[] {2, 2}; }
      }

      protected override ISystemInfo CreateSystemInfo()
      {
        ISystemSpace sp = new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {2, 2});
        return new JuliaFuctionSystemInfoDecorator(sp);
      }      
    }
  }
}