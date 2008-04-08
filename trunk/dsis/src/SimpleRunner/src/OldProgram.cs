using System;
using System.Collections.Generic;
using System.IO;
using DSIS.CellImageBuilder.AdaptiveMethod;
using DSIS.CellImageBuilder.BoxAdaptiveMethod;
using DSIS.CellImageBuilder.BoxMethod;
using DSIS.CellImageBuilder.PointMethod;
using DSIS.Core.Builders;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Core.Util;
using DSIS.Function.Predefined.Delayed;
using DSIS.Function.Predefined.Duffing;
using DSIS.Function.Predefined.FoodChain;
using DSIS.Function.Predefined.Henon;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Function.Predefined.Julia;
using DSIS.Function.Predefined.Logistics;
using DSIS.Function.Predefined.Lorentz;
using DSIS.Function.Predefined.Rossel;
using DSIS.Function.Predefined.VanDerPol;
using DSIS.Function.Solvers.RungeKutt;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  class OldProgram {
    private static string myWorkPath;
    private static string myHomePath;

    private static void Main2()
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
//      Do(new VanDerPolFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>(myWorkPath, 5), myXSLTs);
//      Do(new LorentzFullBuilder<IntegerCoordinateSystem, IntegerCoordinate>(myWorkPath, 5), myXSLTs);
//      new LorentzRunner(myWorkPath, 3, myXSLTs).Run();
//      new RosselRunner(myWorkPath, 4, myXSLTs).Run();

//      new LogisticFullBuilder(myWorkPath, 10, myXSLTs).Run();

//      int i = 0;
      ///generate code.
      Do(new HenonFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>(myWorkPath, 5), myXSLTs);
//      Do(new IkedaFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>(myWorkPath, 6), myXSLTs);
//      Do(new JuliaFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>(myWorkPath, 1), myXSLTs);
//      
//      Do(new HenonFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>(myWorkPath, 13), myXSLTs);
//      Do(new IkedaFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>(myWorkPath, 10), myXSLTs);
//      Do(new JuliaFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>(myWorkPath, 12), myXSLTs);
//      Do(new DelayedFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>(2.21, myWorkPath, 13 + i), myXSLTs);
//      Do(new DelayedFullBuilder<IntegerCoordinateSystem2d, IntegerCoordinate2d>(2.27, myWorkPath, 13 + i), myXSLTs);
//
//      Do(new FoodChain)
//      for (int i = 1; i <= 10; i++)
//        new FoodChainRunner(myWorkPath, i, myXSLTs).Run();
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
      where Q : IIntegerCoordinate
    {
      action.ComputeAllMethods(NullProgressInfo.INSTANCE);
      action.ApplyXSL(xslt);
    }


    public class LogisticFullBuilder : GeneratedAbstactImageBuilderRunner
    {
      private readonly string myPath;
      private readonly int mySteps;
      private readonly List<string> myXslt;

      public LogisticFullBuilder(string path, int steps, List<string> xslt)
      {
        myPath = path;
        mySteps = steps;
        myXslt = xslt;
      }

      public override AbstractImageBuilder<T, Q> CreateBuilder<T, Q>()
      {
        return new LogisticFullBuilder<T, Q>(myPath, mySteps);
      }

      protected override void ComputationFinished<T, Q>(AbstractImageBuilder<T, Q> builder)
      {
        base.ComputationFinished(builder);
        FullImageBuilderWithLog<T, Q> bld = (FullImageBuilderWithLog<T, Q>)builder;
        bld.ApplyXSL(myXslt);
      }

      public void Run()
      {
        Run(1);
      }
    }

    public class LogisticFullBuilder<T, Q> : FullImageBuilderWithLog<T, Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
    {
      public LogisticFullBuilder(string homePath, int steps)
        :
          base(homePath, steps, -1)
      {
      }
      
      protected override ISystemInfo CreateSystemInfo()
      {
        DefaultSystemSpace space =
          new DefaultSystemSpace(1, new double[] { 0 }, new double[] { 1 }, new long[] { 10 });
        return new LogisticSystemInfo(4);
      }

      protected override long[] Subdivide
      {
        get { return new long[] { 2 }; }
      }
    }  


    public class DuffingFullBuilder<T, Q> : FullImageBuilderWithLog<T, Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
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
              new BoxMethod<Q>(), BoxMethodSettings.Default), 
          };
      }

      protected override ISystemInfo CreateSystemInfo()
      {
        DefaultSystemSpace space =
          new DefaultSystemSpace(2, new double[] { -10, -10 }, new double[] { 10, 10 }, new long[] { 10, 10 });
        return new RungeKuttSolver(new DuffingSystemInfo(-1, 0.27, 0.48), 5, 1);
      }

      protected override long[] Subdivide
      {
        get { return new long[] {2, 2}; }
      }
    }  
    
    
    public class LorentzFullBuilder<T, Q> : FullImageBuilderWithLog<T, Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
    {
      public LorentzFullBuilder(string homePath, int steps)
        :
          base(homePath, steps, -1)
      {
      }

      protected override ICollection<Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>> GetMethods()
      {
        return new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>[]
          {
            new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>(
              new BoxMethod<Q>(), BoxMethodSettings.Default), 
          };
      }

      protected override ISystemInfo CreateSystemInfo()
      {
        DefaultSystemSpace space =
          new DefaultSystemSpace(3, new double[] { -100, -100, -100 }, new double[] { 100, 100, 100}, new long[] { 10, 10, 10 });
        return new RungeKuttSolver(new LorentzSystemInfo(space, 8.0/3.0, 28, 10), 15, 0.1);
      }

      protected override long[] Subdivide
      {
        get { return new long[] {2, 2, 2}; }
      }
    }

    public class LorentzRunner : GeneratedAbstactImageBuilderRunner
    {
      private readonly string myPath;
      private readonly int mySteps;
      private readonly List<string> myXslt;

      public LorentzRunner(string path, int steps, List<string> xslt)
      {
        myPath = path;
        mySteps = steps;
        myXslt = xslt;
      }

      public override AbstractImageBuilder<T, Q> CreateBuilder<T, Q>()
      {
        return new LorentzFullBuilder<T, Q>(myPath, mySteps);
      }

      protected override void ComputationFinished<T, Q>(AbstractImageBuilder<T, Q> builder)
      {
        base.ComputationFinished(builder);
        FullImageBuilderWithLog<T, Q> bld = (FullImageBuilderWithLog<T, Q>) builder;
        bld.ApplyXSL(myXslt);
      }

      public void Run()
      {
        Run(3);
      }
    }
    
    public class RosslerFullBuilder<T, Q> : FullImageBuilderWithLog<T, Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
    {
      public RosslerFullBuilder(string homePath, int steps)
        :
          base(homePath, steps, -1)
      {
      }

      protected override ICollection<Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>> GetMethods()
      {
        return new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>[]
          {
            new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>(
              new BoxMethod<Q>(), BoxMethodSettings.Default), 
//              new PointMethod<T,Q>(), new PointMethodSettings(new int[] {3, 3, 3}, 0.2))
          };
      }

      protected override ISystemInfo CreateSystemInfo()
      {
        DefaultSystemSpace space =
          new DefaultSystemSpace(3, new double[] { -100, -100, -100 }, new double[] { 100, 100, 100}, new long[] { 10, 10, 10 });
//        return new RungeKuttSolver(new RosslerSystemInfo(space, 0.2, 0.2, 5.7), 5, 0.1);
        return new RungeKuttSolver(new RosslerSystemInfo(space, 0.1, 0.1, 14), 1, 0.01);
      }

      protected override long[] Subdivide
      {
        get { return new long[] {2, 2, 2}; }
      }
    }

    public class RosselRunner : GeneratedAbstactImageBuilderRunner
    {
      private readonly string myPath;
      private readonly int mySteps;
      private readonly List<string> myXslt;

      public RosselRunner(string path, int steps, List<string> xslt)
      {
        myPath = path;
        mySteps = steps;
        myXslt = xslt;
      }

      public override AbstractImageBuilder<T, Q> CreateBuilder<T, Q>()
      {
        return new RosslerFullBuilder<T, Q>(myPath, mySteps);
      }

      protected override void ComputationFinished<T, Q>(AbstractImageBuilder<T, Q> builder)
      {
        base.ComputationFinished(builder);
        FullImageBuilderWithLog<T, Q> bld = (FullImageBuilderWithLog<T, Q>) builder;
        bld.ApplyXSL(myXslt);
      }

      public void Run()
      {
        Run(3);
      }
    }
     

    
    public class VanDerPolFullBuilder<T, Q> : FullImageBuilderWithLog<T, Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
    {
      public VanDerPolFullBuilder(string homePath, int steps)
        :
          base(homePath, steps, -1)
      {
      }

      protected override ICollection<Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>> GetMethods()
      {
        return new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>[]
          {
            new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>(
              new BoxMethod<Q>(), BoxMethodSettings.Default), 
          };
      }

      protected override ISystemInfo CreateSystemInfo()
      {
        DefaultSystemSpace space =
          new DefaultSystemSpace(2, new double[] { -5, -5 }, new double[] { 5, 5}, new long[] { 10, 10 });
        return new RungeKuttSolver(new VanDerPolSystemInfo(1.5), 15, 1);
      }

      protected override long[] Subdivide
      {
        get { return new long[] {2, 2}; }
      }
    }


    public class HenonFullBuilder<T, Q> : FullImageBuilderWithLog<T, Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
    {
      public HenonFullBuilder(string homePath, int steps) :
        base(homePath, steps, -1)
      {
      }


      protected override ISystemInfo CreateSystemInfo()
      {
        DefaultSystemSpace space =
          new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {10, 10});
        return new HenonFunctionSystemInfoDecorator(1.4);
      }

      protected override long[] Subdivide
      {
        get { return new long[] {2, 2}; }
      }
    }

    public class IkedaFullBuilder<T, Q> : FullImageBuilderWithLog<T, Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
    {
      public IkedaFullBuilder(string homePath, int steps) :
        base(homePath, steps, -1)
      {
      }

      protected override ISystemInfo CreateSystemInfo()
      {
        DefaultSystemSpace space =
          new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {10, 10});
        return new IkedaFunctionSystemInfoDecorator();
      }

      protected override long[] Subdivide
      {
        get { return new long[] {2, 2}; }
      }
    }

    public class DelayedFullBuilder<T, Q> : FullImageBuilderWithLog<T, Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
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
        return new DelayedFunctionSystemInfo(myA);
      }      
    }
    
    public class JuliaFullBuilder<T, Q> : FullImageBuilderWithLog<T, Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
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
        return new JuliaFuctionSystemInfoDecorator();
      }      
    } 
    
    public class FoodChainFullBuilder<T, Q> : FullImageBuilderWithLog<T, Q>
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
    {
      public FoodChainFullBuilder(string homePath, int steps)
        :
          base(homePath, steps, -1)
      {
      }


      protected override ICollection<Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>> GetMethods()
      {
        return new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>[]
          {
            new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>(
              new AdaptiveMethod<Q>(), new AdaptiveMethodSettings(1, 30, 0.1)),
            new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>(
              new PointMethod<Q>(), new PointMethodSettings(new int[] {3, 3, 3 })),
            new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>(
              new PointMethod<Q>(), new PointMethodSettings(new int[] {3, 3, 3}, 0.1)),
            new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>(
              new BoxMethod<Q>(), BoxMethodSettings.Default),
            new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>(
              new BoxAdaptiveMethod<Q>(), new BoxAdaptiveMethodSettings(30, 0.1)),
          };
      }

      protected override long[] Subdivide
      {
        get { return new long[] {2, 2, 2}; }
      }

      protected override ISystemInfo CreateSystemInfo()
      {
        ISystemSpace sp = new DefaultSystemSpace(3, new double[] {0.01, 0.01, 0.01}, new double[] {50, 50, 50}, new long[] {1, 1, 1 });
        return new FoodChainSystemInfo();
      }      
    }

    public class FoodChainRunner : GeneratedAbstactImageBuilderRunner
    {
      private readonly string myPath;
      private readonly int mySteps;
      private readonly List<string> myXslt;

      public FoodChainRunner(string path, int steps, List<string> xslt)
      {
        myPath = path;
        mySteps = steps;
        myXslt = xslt;
      }

      public override AbstractImageBuilder<T, Q> CreateBuilder<T, Q>()
      {
        return new FoodChainFullBuilder<T, Q>(myPath, mySteps);
      }

      protected override void ComputationFinished<T, Q>(AbstractImageBuilder<T, Q> builder)
      {
        base.ComputationFinished(builder);
        FullImageBuilderWithLog<T, Q> bld = (FullImageBuilderWithLog<T, Q>)builder;
        bld.ApplyXSL(myXslt);
      }

      public void Run()
      {
        Run(3);
      }
    }

  }
}