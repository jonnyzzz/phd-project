using System;
using System.Collections.Generic;
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
  public class SIBuild
  {
    public void Action()
    {
      BuildContiniousSystems();
    }

    private static List<ComputationData> ForBuildser(IEnumerable<ComputationData> data, params Builder[] bld)
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
      for (int rep = 3; rep < 13; rep++)
      {
        var data = ForBuildser(new List<ComputationData>
                     {
//                       new ComputationData {system = SystemInfoFactory.Henon1_4(), repeat = rep},
                       new ComputationData {system = SystemInfoFactory.Ikeda(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.Delayed(2.21), repeat = rep},
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
                     new []{                         
//                       Builder.Point, 
                       Builder.Box
                     });
        foreach (var _computationData in new List<ComputationData>(data))
        {
          var computationData = _computationData;
          using (var th = new MemoryMonitorThread(2 * 1024 * 1024 * 1024L))
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
                    data.RemoveAll(x=>x.Equals(computationData));
                  } catch (Exception e)
                  {
                    Console.Out.WriteLine("-----GENERAL ERROR------------------------OOE-------------------------");
                    Console.Out.WriteLine(e);
                    Console.Out.WriteLine("-----------------------------OOE-------------------------");
                    data.RemoveAll(x=>x.Equals(computationData));
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
    }


    private enum Builder
    {
      Box,
      Adaptive,
      Point
    }

    private struct ComputationData : IEquatable<ComputationData>
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

      var next = holder.Edge(buildSI.Clone()).With(x => firstContext.Join(system).Each(y => x.Back(y)));
      for (int i = 1; i < count; i++)
      {
        var tmp = next;
        next = CreateActionsAfterSI(
          next
          .Edge(buildSI.Clone())
          .With(x => innerContext.Join(system).Each(y => x.Back(y)))
          .With(x => x.Back(new MergeComponetsAction()).Back(tmp)),
          system,
          i + 1 == count);
      }

      return next;
    }

    protected virtual IActionEdgesBuilder CreateActionsAfterSI(IActionEdgesBuilder siConstructionAction, IAction system, bool isLast)
    {
      return siConstructionAction;
    }
  }
}