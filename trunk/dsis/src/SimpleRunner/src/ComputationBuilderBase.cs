using System;
using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public abstract class ComputationBuilderBase<T>
    where T : BuilderDataBase, ICloneable<T> 
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
      SlotStore.Clear();

      var queue = new List<T>(GetSystemsToRun());

      while (queue.Count > 0)
      {
        SortTasks(queue);

        var computationData = queue[0];
        Console.Out.WriteLine("\r\n-------------------------------------------------------\r\n");
        computationData.Serialize(new ConsoleLogger());
        Console.Out.WriteLine();
        queue.RemoveAt(0);

        var executor = new GuardedExecutor(computationData.MemoryLimit, computationData.ExecutionTimeout);
        executor.Error += e =>
                            {
                              if (e is OutOfMemoryException)
                              {
                                Console.Out.WriteLine("-----------------------------OOME-------------------------");
                                Console.Out.WriteLine(e);
                                Console.Out.WriteLine("-----------------------------OOME-------------------------");
                                OnComputationInterrupt(queue, computationData);
                              }
                              else
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

        executor.Execute("Simulation", () =>
                                         {
                                           SlotStore.Clear();
                                           ComputeAll(computationData);
                                         });

        GC.Collect();
        GC.GetTotalMemory(true);

        Console.Out.WriteLine("---------------------------------------------------------");
      }
    }

    protected virtual void SortTasks(List<T> queue)
    {      
    }

    protected abstract void ComputeAll(T computationData);
  }
}