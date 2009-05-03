using System;
using System.Collections.Generic;
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

    protected virtual void OnComputationInterrupt(List<T> actions, T action)
    {
      actions.RemoveAll(x => x.Equals(action));
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

        var executor = new GuardedExecutor(2 * 1024 * 1024 * 1024L, computationData.ExecutionTimeout);
        executor.Error += e =>
                            {
                              if (e is OutOfMemoryException)
                              {
                                Console.Out.WriteLine("-----------------------------OOME-------------------------");
                                Console.Out.WriteLine(e);
                                Console.Out.WriteLine("-----------------------------OOME-------------------------");
                                OnComputationInterrupt(queue, computationData);                                
                              } else
                              {
                                Console.Out.WriteLine("-----GENERAL ERROR------------------------OOE-------------------------");
                                Console.Out.WriteLine(e);
                                Console.Out.WriteLine("-----------------------------OOE-------------------------");
                                OnComputationInterrupt(queue, computationData);
                              }
                            };
        executor.TimeOut += () =>
                              {
                                Console.Out.WriteLine("-----TIMEOUT-------------------------------------------------");
                                OnComputationInterrupt(queue, computationData);
                              };
        executor.OutOfMemory += () =>
                                  {
                                    Console.Out.WriteLine("-----------------------------OOME-------------------------");
                                    OnComputationInterrupt(queue, computationData);
                                  };

        executor.Execute("Simulation", ()=>
                           {
                             var sys = computationData;
                             var aa = new AgregateAction(x => BuildGraph(x, sys));
                             aa.Apply(new Context());
                           });
        Console.Out.WriteLine("---------------------------------------------------------");
      }
    }

    protected abstract void BuildGraph(IActionGraphBuilder2 bld, T sys);
  }
}