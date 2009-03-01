using System;
using System.Collections.Generic;
using System.Threading;
using DSIS.Scheme;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl;
using DSIS.Scheme.Impl.Actions;
using DSIS.Scheme.Impl.Actions.Console;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Scheme.Impl.Actions.Performance;
using DSIS.Scheme.Xml;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public abstract class SIBuild<T> 
    where T : ComputationData
  {
    public void Action()
    {
      BuildContiniousSystems();
    }

    protected static List<ComputationData> ForBuildser(IEnumerable<ComputationData> data,
                                                       params ComputationDataBuilder[] bld)
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
      var queue = new List<T>(GetSystemsToRun());
      queue.Sort((x, y) => x.repeat.CompareTo(y.repeat));

      while (queue.Count > 0)
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

    private class DumpComputationDataAction : ActionBase
    {
      private readonly ComputationData myData;

      public DumpComputationDataAction(ComputationData data)
      {
        myData = data;
      }

      public override ICollection<ContextMissmatch> Compatible(Context ctx)
      {
        return EmptyArray<ContextMissmatch>.Instance;
      }

      protected override void Apply(Context ctx, Context result)
      {
        var log = Logger.Instance(ctx);

        myData.Serialize(log);
      }
    }

    private void BuildGraph(IActionGraphBuilder2 bld, T sys)
    {
      var graphs = new XsdGraphXmlLoader().Load(typeof (SIBuild).Assembly, "DSIS.SimpleRunner.resources.si.xml");
      var builder = new XsdGraphBuilder().BuildActions(graphs);

      var image = builder["imageBuilder" + sys.builder];
      var init = builder["init"];
      var workingFolder = builder["workingFolder"];
      var dump = builder["dumpGraph"];
      var draw = builder["drawGraph"];
      var logger = new LoggerAction();

      var id = new SetIterationSteps(new IterationSteps(sys.repeat));
      bld.Start.Edge(workingFolder).Edge(logger).Back(new DumpComputationDataAction(sys));
      bld.Start.Edge(sys.system).Edge(init).Edge(image);
      bld.Start.Edge(sys.system).Edge(workingFolder).With(x => x.Back(id));

      var rootAction = RepeatSI(
        bld.Start,
        sys.repeat,
        new RecordTimeSlotAction(builder["build"], "total"),
        new[] {image, init, logger},
        new[] {image, workingFolder, logger},
        sys.system, workingFolder, logger, sys);

      rootAction
        .With(x => x.Edge(dump).
                     With(xx => xx.Back(image)).
                     With(xx => xx.Back(workingFolder).Back(image)))
        .Edge(draw).With(x => x.Back(workingFolder))
        .Edge(bld.Finish)
        .With(x => x.Back(new DumpSlotTimesAction("BuildSI")).Back(logger))
        .With(x => x.Back(new DumpSlotTimesAction("total")).Back(logger));
    }

    private IActionEdgesBuilder RepeatSI(IActionEdgesBuilder holder, int count, IAction buildSI,
                                         IEnumerable<IAction> firstContext, IEnumerable<IAction> innerContext,
                                         IAction system, IAction workingFolder, IAction logger, T sys)
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
          workingFolder,
          logger, sys,
          i + 1 == count)
          .With(x => innerContext.ForEach(y => x.Back(y)))
          .With(x => x.Edge(new DumpGraphInfoAction()).Back(logger))
          .With(x => x.Edge(new DumpGraphComponentsInfoAction()).Back(logger))
          .With(x => x.Edge(new DumpSeparatorAction()).Back(logger))
          ;
      }

      return next;
    }

    protected virtual IActionEdgesBuilder CreateActionsAfterSI(IActionEdgesBuilder siConstructionAction,
                                                               IAction system,
                                                               IAction workingFolder,
                                                               IAction logger,
                                                               T computationData,
                                                               bool isLast)
    {
      return siConstructionAction;
    }

    protected abstract IEnumerable<IEnumerable<T>> GetSystemsToRun2();

    protected virtual IEnumerable<T> GetSystemsToRun()
    {
      return GetSystemsToRun2().Maps(x => x);
    }
  }
}