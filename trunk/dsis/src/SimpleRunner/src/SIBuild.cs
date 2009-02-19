using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DSIS.Scheme;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl;
using DSIS.Scheme.Impl.Actions;
using DSIS.Scheme.Impl.Actions.Performance;
using DSIS.Scheme.Xml;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public static class ComputationDataUtil
{
    public static IEnumerable<SIBuild.ComputationData> ForBuilders(this IEnumerable<SIBuild.ComputationData> data, params SIBuild.Builder[] bld)
    {
      foreach (var computationData in data)
      {
        foreach (var b in bld)
        {
          var d = computationData.Clone();
          d.builder = b;
          yield return d;
        }
      }
    }

    public static IEnumerable<SIBuild.ComputationData> ForAllBuilders(this IEnumerable<SIBuild.ComputationData> data)
    {
      return data.ForBuilders(Enum.GetValues(typeof (SIBuild.Builder)).Cast<SIBuild.Builder>().ToArray());
    }

    public static IEnumerable<SIBuild.ComputationData> ForSteps(this IEnumerable<SIBuild.ComputationData> data, params int[] steps)
    {
      foreach (var computationData in data)
      {
        foreach (var b in steps)
        {
          var d = computationData.Clone();
          d.repeat = b;
          yield return d;
        }
      }
    }
}

  public class SIBuild
  {
    public void Action()
    {
      BuildContiniousSystems();
    }

    protected static List<ComputationData> ForBuildser(IEnumerable<ComputationData> data, params Builder[] bld)
    {
      var d = new List<ComputationData>();
      foreach (var computationData in data)
      {
        foreach (var b in bld)
        {
          var dd = computationData.Clone();
          dd.builder = b;
          d.Add(dd);
        }
      }
      return d;
    }

    private void BuildContiniousSystems()
    {
      List<ComputationData> data = GetSystemsToRun().ToList();
      var queue = new List<ComputationData>(data);
      
      while(queue.Count > 0)
      {
        var computationData = queue[0];
        Console.Out.WriteLine("\r\n-------------------------------------------------------\r\n");
        Console.Out.WriteLine("system = {0}", computationData.system);
        Console.Out.WriteLine("method = {0}", computationData.builder);
        Console.Out.WriteLine("repeat = {0}", computationData.repeat);
        Console.Out.WriteLine();
        queue.RemoveAt(0);
        
        using (var th = new MemoryMonitorThread(2*1024*1024*1024L))
        {
          var computation
            = new Thread(
              delegate()
                {
                  try
                  {
                    var sys = computationData;
                    var aa = new AgregateAction(x => BuildGraph(new ActionBuilder2Adaptor(x), sys));
                    aa.Apply(new Context());
                    Console.Out.WriteLine("---------------------------------------------------------");
                  }
                  catch (OutOfMemoryException e)
                  {
                    Console.Out.WriteLine("-----------------------------OOE-------------------------");
                    Console.Out.WriteLine(e);
                    Console.Out.WriteLine("-----------------------------OOE-------------------------");
                    queue.RemoveAll(x => x.Equals(computationData));
                  }
                  catch (Exception e)
                  {
                    Console.Out.WriteLine("-----GENERAL ERROR------------------------OOE-------------------------");
                    Console.Out.WriteLine(e);
                    Console.Out.WriteLine("-----------------------------OOE-------------------------");
                    queue.RemoveAll(x => x.Equals(computationData));
                  }
                  GCHelper.Collect();
                });

          th.MemoryLimit += delegate
                              {
                                computation.Interrupt();
                                computation.Abort();
                              };
          computation.Start();
          th.Run();
          computation.Join();
        }
      }
    }

    protected virtual IEnumerable<ComputationData> GetSystemsToRun()
    {
      var data = new List<ComputationData>();
      foreach (int rep in new[] {8, 10})
      {
        data.AddRange(ForBuildser(new List<ComputationData>
                                    {
//                       new ComputationData {system = SystemInfoFactory.Henon1_4(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.Ikeda(), repeat = rep},
                                      new ComputationData {system = SystemInfoFactory.OsipenkoBio2(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.Delayed(2.27), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.Duffing2x2Runge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.Duffing1_5x1_5Runge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.Duffing1_4x1_4Runge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.Duffing1_3x1_3Runge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.Duffing1_2x1_2Runge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.DuffingRunge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.VanDerPolRunge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.LorentzRunge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.RosslerRunge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.BrusselatorRunge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.ChuaRunge(), repeat = rep},
                                    },
                                  new[]
                                    {
                                      Builder.Adaptive,
                                      Builder.Box
                                    }));
      }
      return data;
    }


    public enum Builder
    {
      Box,
      Adaptive,
      Point
    }

    public struct ComputationData : IEquatable<ComputationData>
    {
      public IAction system { get; set; }
      public int repeat { get; set; }
      public Builder builder { get; set; }

      public ComputationData Clone()
      {
        return new ComputationData
                 {
                   system = system,
                   repeat = repeat,
                   builder = builder
                 };
      }

      public bool Equals(ComputationData obj)
      {
        return Equals(obj.system, system) && Equals(obj.builder, builder);
      }

      public override bool Equals(object obj)
      {
        if (obj.GetType() != typeof (ComputationData)) return false;
        return Equals((ComputationData) obj);
      }

      public override int GetHashCode()
      {
        unchecked
        {
          int result = (system != null ? system.GetHashCode() : 0);
          result = (result*397) ^ builder.GetHashCode();
          return result;
        }
      }

      public static bool operator ==(ComputationData left, ComputationData right)
      {
        return left.Equals(right);
      }

      public static bool operator !=(ComputationData left, ComputationData right)
      {
        return !left.Equals(right);
      }
    }

    private void BuildGraph(IActionGraphBuilder2 bld, ComputationData sys)
    {
      var graphs = new XsdGraphXmlLoader().Load(typeof (SIBuild).Assembly, "DSIS.SimpleRunner.resources.si.xml");
      var builder = new XsdGraphBuilder().BuildActions(graphs);

      var image = builder["imageBuilder" + sys.builder];
      var init = builder["init"];
      var workingFolder = builder["workingFolder"];
      var dump = builder["dumpGraph"];
      var draw = builder["drawGraph"];

      var id = new SetIterationSteps(new IterationSteps(sys.repeat));
      bld.Start.Edge(sys.system).Edge(init).Edge(image);
      bld.Start.Edge(sys.system).Edge(workingFolder).With(x => x.Back(id));

      var rootAction = RepeatSI(
        bld.Start,
        sys.repeat,
        builder["build"],
        new[] {image, init},
        new[] {image},
        sys.system);

      rootAction
        .With(x => x.Edge(dump).
                     With(xx => xx.Back(image)).
                     With(xx => xx.Back(workingFolder).Back(image)))
        .Edge(draw).
        With(x => x.Back(workingFolder))
        .Edge(bld.Finish).Back(new DumpSlotTimesAction("BuildSI"));
      ;
    }

    private IActionEdgesBuilder RepeatSI(IActionEdgesBuilder holder, int count, IAction buildSI,
                                         IEnumerable<IAction> firstContext, IEnumerable<IAction> innerContext,
                                         IAction system)
    {
      if (count < 2)
        throw new ArgumentException("Count should be >= 2", "count");

      var next = holder.Edge(buildSI.Clone()).With(x => firstContext.Join(system).ForEach(y => x.Back(y)));
      for (int i = 1; i < count; i++)
      {
        var tmp = next;
        next = CreateActionsAfterSI(
          next
            .Edge(buildSI.Clone())
            .With(x => innerContext.Join(system).ForEach(y => x.Back(y)))
            .With(x => x.Back(new MergeComponetsAction()).Back(tmp)),
          system,
          i + 1 == count);
      }

      return next;
    }

    protected virtual IActionEdgesBuilder CreateActionsAfterSI(IActionEdgesBuilder siConstructionAction, IAction system,
                                                               bool isLast)
    {
      return siConstructionAction;
    }
  }
}