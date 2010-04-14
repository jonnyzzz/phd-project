using System;
using System.Threading;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Tarjan;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Graph.Entropy.Tests
{
  public class PerfomanceTestBase : GraphBaseTest
  {
    protected delegate ILoopIterator Factory<T>(IReadonlyGraph<T> graph, IReadonlyGraphStrongComponents<T> comps)
      where T : ICellCoordinate;

    public void DoWithTimeout(VoidDelegate action, TimeSpan time)
    {
      var thread = new Thread(delegate()
                                   {
                                     DateTime now = DateTime.Now;
                                     action();
                                     TimeSpan workTime = DateTime.Now - now;
                                     Console.Out.WriteLine("workTime = {0}", workTime);
                                   });
      thread.Name = "Test Action";
      thread.Start();

      thread.Join(time);
      if (!thread.IsAlive)
        return;

      thread.Interrupt();
      thread.Join(1000);

      Assert.IsTrue(thread.IsAlive);                                         
    }

    protected void DoWithFullGraph(int power, Factory<IntegerCoordinate> test, TimeSpan timeout)
    {
      TarjanGraph<IntegerCoordinate> gr = DoBuildGraph(delegate(IGraph<IntegerCoordinate> graph)
                                                         {
                                                           for (int i = 1; i <= power; i++)
                                                           {
                                                             for (int j = 1; j <= power; j++)
                                                             {
                                                               AddEdge(graph, i, j);
                                                             }
                                                           }
                                                         });
      var components  = gr.ComputeStrongComponents(NullProgressInfo.INSTANCE);
      ILoopIterator iter = test(gr, components );
      
      DoWithTimeout(iter.WidthSearch, timeout);      
    }
  }
}