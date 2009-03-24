using System;
using System.Collections.Generic;
using System.Threading;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public abstract class BuilderBase<T> 
    where T : BuilderData, ICloneable<T> 
  {
    public void Action()
    {
      BuildContiniousSystems();
    }

    protected abstract IEnumerable<IEnumerable<T>> GetSystemsToRun2();

    protected virtual IEnumerable<T> GetSystemsToRun()
    {
      return GetSystemsToRun2().Maps(x => x);
    }

    private void BuildContiniousSystems()
    {
      var queue = new List<T>(GetSystemsToRun());
      queue.Sort((x, y) => x.repeat.CompareTo(y.repeat));

      while (queue.Count > 0)
      {
        var computationData = queue[0];
        Console.Out.WriteLine("\r\n-------------------------------------------------------\r\n");
        computationData.Serialize(new ConsoleLogger());
        Console.Out.WriteLine();
        queue.RemoveAt(0);

        using (var th = new MemoryMonitorThread(2 * 1024 * 1024 * 1024L))
        {
          var computation
            = new Thread(
              delegate()
                {
                  try
                  {
                    var sys = computationData;
                    var aa = new AgregateAction(x => BuildGraph(x, sys));
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

    protected abstract void BuildGraph(IActionGraphBuilder2 bld, T sys);
  }
}