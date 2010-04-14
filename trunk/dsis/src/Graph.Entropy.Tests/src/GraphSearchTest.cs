using System;
using System.Collections.Generic;
using System.Text;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Entropy.Impl.Loop;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Tarjan;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.Graph.Entropy.Tests
{
  public abstract class GraphSearchTest : GraphBaseTest
  {
    protected void DoTest(BuildGraph bg, params string[] golds)
    {
      TarjanGraph<IntegerCoordinate> graph = DoBuildGraph(bg);

      var components = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);
      
      var mcb = new MockCallback();
      ILoopIterator gws = Create(graph, mcb, components);

      gws.WidthSearch();

      var sb = new StringBuilder();
      foreach (List<string> loop in mcb.Loops)
      {
//        loop.Reverse();
        foreach (string s in loop)
        {
          sb.Append(s);
          sb.Append(", ");
        }
        sb.AppendLine();
      }
      try
      {
        Assert.AreEqual(golds.Length, mcb.Loops.Count);
        for (int index = 0; index < mcb.Loops.Count; index++)
        {
          List<string> loop = mcb.Loops[index];
          var sbb = new StringBuilder();
          foreach (string s in loop)
          {
            sbb.Append(s);
            sbb.Append(", ");
          }
          Assert.AreEqual(golds[index].Trim(), sbb.ToString().Trim());
        }
      }
      catch
      {
        Console.Error.WriteLine(sb.ToString().Trim());
        throw;
      }
    }

    protected abstract ILoopIterator Create<T, N>(IReadonlyGraph<T,N> graph, ILoopIteratorCallback<T, N> mcb,
                                                  IReadonlyGraphStrongComponents<T,N> components)
      where T : ICellCoordinate
      where N : class, INode<T>;
  }
}