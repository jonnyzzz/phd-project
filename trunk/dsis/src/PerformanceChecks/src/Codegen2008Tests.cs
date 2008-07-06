using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;
using DSIS.Utils;

namespace DSIS.PerformanceChecks
{
  [TestFixture]
  public class Codegen2008Tests : PerformanceBase
  {
    private readonly GeneratedIntegerCoordinateSystemManager myGManager = GeneratedIntegerCoordinateSystemManager.Instance;
    private List<String> myStrings = new List<string>();

    [SetUp]
    public void SetUp()
    {
      myStrings = new List<string>();
    }

    [TearDown]
    public void TearDown()
    {
      DumpList();
    }

    [Test]
    public void Test_LongVsDouble()
    {
      Console.Out.WriteLine("long:{0}\r\ndouble:{1}",
                            Marshal.SizeOf(typeof (long)),
                            Marshal.SizeOf(typeof (double)));      
    }

    private ISystemSpace create2d()
    {
      return new DefaultSystemSpace(2, 0.0.Fill(2), 1.0.Fill(2), 1000L.Fill(2));
    }
    
    private ISystemSpace create3d()
    {
      return new DefaultSystemSpace(3, 0.0.Fill(3), 1.0.Fill(3), 50L.Fill(3));
    }

    private ISystemSpace create4d()
    {
      return new DefaultSystemSpace(4, 0.0.Fill(4), 1.0.Fill(4), 20L.Fill(4));
    }

    private delegate object DAction<T, Q>(T system, IEnumerable<double[]> points)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate;

    private void WriteList(string template, params object[] objs)
    {
      var x = string.Format(template, objs);
      myStrings.Add(x);
      Console.Out.WriteLine(x);
    }

    private void DumpList()
    {
      myStrings.Sort();
      foreach (var s in myStrings)
      {
        Console.Out.WriteLine("{0}", s);
      }
    }

    private void DoTest<T,Q>(string name, T system, DAction<T,Q> action) 
      where T : IIntegerCoordinateSystem<Q> 
      where Q : IIntegerCoordinate
    {
      var points = new List<double[]>();
      foreach (var ps in system.InitialSubdivision)
      {
        var x = new double[system.Dimension];
        system.CenterPoint(ps, x);
        points.Add(x);
      }

      WriteList("{0}-Points={1}", name, points.Count);

      var totalTime = new TimeSpan(0);
      var totalMem = 0L;
      const int TIMES = 4;

      for (int i = 0; i < TIMES; i++)
      {
        GCHelper.Collect();
        var mem = GC.GetTotalMemory(true);
        DateTime time = DateTime.Now;
        var xx = action(system, points);
        totalTime += DateTime.Now - time;

        GCHelper.Collect();
        totalMem += GC.GetTotalMemory(true) - mem;
        Console.Out.WriteLine("                                       x = {0}", xx.ToString().Substring(0, 1));
      }
      
      WriteList("{0}- Time={1}ms", name, totalTime.TotalMilliseconds/TIMES);
      WriteList("{0}- Memory={1}mb", name, totalMem / 1024.0 / 1024.0 / TIMES);
    }

    private class WithICS : IIntegerCoordinateSystemWith
    {
      private readonly Codegen2008Tests myInstance;
      private readonly string myName;

      public WithICS(Codegen2008Tests instance, string name)
      {
        myInstance = instance;
        myName = name;
      }

      public void Do<T, Q>(T system) where T : IIntegerCoordinateSystem<Q> where Q : IIntegerCoordinate
      {
        Console.Out.WriteLine("---------------------------");
        myInstance.DoTest<T,Q>("point(1)" + myName, system, (x, cs) => RunPointProcessor(x, x.ProcessorFactory.CreatePointProcessor(), cs));
        Console.Out.WriteLine("---------------------------");
        myInstance.DoTest<T,Q>("point(2)" + myName, system, (x, cs) => RunPointProcessor2(x, x.ProcessorFactory.CreatePointProcessor(), cs));
        Console.Out.WriteLine("---------------------------"); Console.Out.WriteLine("---------------------------");
        myInstance.DoTest<T,Q>("overlap(1)" + myName, system, (x, cs) => RunPointProcessor(x, x.ProcessorFactory.CreateOverlapedPointProcessor(0.2), cs));
        Console.Out.WriteLine("---------------------------");
        myInstance.DoTest<T, Q>("overlap(2)" + myName, system, (x, cs) => RunPointProcessor2(x, x.ProcessorFactory.CreateOverlapedPointProcessor(0.2), cs));
        Console.Out.WriteLine("---------------------------");
      }
      
      private static object RunPointProcessor<T, Q>(T system, IPointProcessor<Q> proc, IEnumerable<double[]> cells)
        where T : IIntegerCoordinateSystem<Q>
        where Q : IIntegerCoordinate
      {
        var list = new List<Q>();

        foreach (var cell in cells)
        {
          list.AddRange(proc.AddPoint(cell));
        }
        return list;
      }

      private static object RunPointProcessor2<T, Q>(T system, IPointProcessor<Q> proc, IEnumerable<double[]> cells)
        where T : IIntegerCoordinateSystem<Q>
        where Q : IIntegerCoordinate
      {
        return new List<Q>(cells.Maps(x => proc.AddPoint(x)));
      }
    }
    private class WithICS2 : IIntegerCoordinateSystemWith
    {
      private readonly Codegen2008Tests myInstance;
      private readonly string myName;

      public WithICS2(Codegen2008Tests instance, string name)
      {
        myInstance = instance;
        myName = name;
      }

      public void Do<T, Q>(T system) where T : IIntegerCoordinateSystem<Q> where Q : IIntegerCoordinate
      {
        Console.Out.WriteLine("---------------------------");
        myInstance.DoTest<T,Q>("radius(1)" + myName, system, (x, cs) => RunPointProcessor(x, x.ProcessorFactory.CreateRadiusProcessor(), cs));        
      }
      
      private static object RunPointProcessor<T, Q>(T system, IRadiusProcessor<Q> proc, IEnumerable<double[]> cells)
        where T : IIntegerCoordinateSystem<Q>
        where Q : IIntegerCoordinate
      {
        var list = new List<Q>();

        var radius = system.CellSizeHalf;

        foreach (var cell in cells)
        {
          list.AddRange(proc.ConnectCellToRadius(cell, radius));
        }
        return list;
      }
    }
    private class WithICS3 : IIntegerCoordinateSystemWith
    {
      private readonly Codegen2008Tests myInstance;
      private readonly string myName;

      public WithICS3(Codegen2008Tests instance, string name)
      {
        myInstance = instance;
        myName = name;
      }

      public void Do<T, Q>(T system) where T : IIntegerCoordinateSystem<Q> where Q : IIntegerCoordinate
      {
        Console.Out.WriteLine("---------------------------");
        myInstance.DoTest<T,Q>("rect(1)" + myName, system, (x, cs) => RunPointProcessor(x, x.ProcessorFactory.CreateRectProcessor(0.2), cs));        
      }
      
      private static object RunPointProcessor<T, Q>(T system, IRectProcessor<Q> proc, IEnumerable<double[]> cells)
        where T : IIntegerCoordinateSystem<Q>
        where Q : IIntegerCoordinate
      {
        var list = new List<Q>();

        var radius = system.CellSize;

        foreach (var cell in cells)
        {
          var right = new double[cell.Length];
          for (int i = 0; i < cell.Length; i++)
            right[i] = cell[i] + 1.345*radius[i];

            list.AddRange(proc.ConnectCellToRect(cell, right));
        }
        return list;
      }
    }

    [Test]
    public void Test_PointBuilder_2()
    {
      var sys = new IntegerCoordinateSystem(create2d());
      var gSys = myGManager.CreateSystem(2).Create(create2d(), create2d().InitialSubdivision);

//      sys.DoGeneric(new WithICS(this, "Array-2"));
//      sys.DoGeneric(new WithICS2(this, "Array-2"));
      sys.DoGeneric(new WithICS3(this, "Array-2"));
//      gSys.DoGeneric(new WithICS(this, "Gen-2"));
//      gSys.DoGeneric(new WithICS2(this, "Gen-2"));
      gSys.DoGeneric(new WithICS3(this, "Gen-2"));
    }

    [Test]
    public void Test_PointBuilder_3()
    {
      var sys = new IntegerCoordinateSystem(create3d());
      var gSys = myGManager.CreateSystem(3).Create(create3d(), create3d().InitialSubdivision);

//      sys.DoGeneric(new WithICS(this, "Array-3"));
//      sys.DoGeneric(new WithICS2(this, "Array-3"));
      sys.DoGeneric(new WithICS3(this, "Array-3"));
//      gSys.DoGeneric(new WithICS(this, "Gen-3"));
//      gSys.DoGeneric(new WithICS2(this, "Gen-3"));
      gSys.DoGeneric(new WithICS3(this, "Gen-3"));
    }
    
    [Test]
    public void Test_PointBuilder_4()
    {
      var sys = new IntegerCoordinateSystem(create4d());
      var gSys = myGManager.CreateSystem(4).Create(create4d(), create4d().InitialSubdivision);

      sys.DoGeneric(new WithICS(this, "Array-4"));
      sys.DoGeneric(new WithICS2(this, "Array-4"));
      sys.DoGeneric(new WithICS3(this, "Array-4"));
      gSys.DoGeneric(new WithICS(this, "Gen-4"));
      gSys.DoGeneric(new WithICS2(this, "Gen-4"));
      gSys.DoGeneric(new WithICS3(this, "Gen-4"));
    }
    
  }
}