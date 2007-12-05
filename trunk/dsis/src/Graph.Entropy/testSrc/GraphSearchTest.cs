using System;
using System.Collections.Generic;
using System.Text;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.Graph.Entropy
{
  public abstract class GraphSearchTest : GraphBaseTest
  {
    protected void DoTest(BuildGraph bg, params string[] golds)
    {
      TarjanGraph<IntegerCoordinate> graph = DoBuildGraph(bg);

      IGraphStrongComponents<IntegerCoordinate> components = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);
      
      MockCallback mcb = new MockCallback();
      ILoopIterator<IntegerCoordinate> gws = Create(graph, mcb, components);

      gws.WidthSearch();

      StringBuilder sb = new StringBuilder();
      foreach (List<string> loop in mcb.Loops)
      {
        loop.Reverse();
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
          StringBuilder sbb = new StringBuilder();
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

    protected abstract ILoopIterator<T> Create<T>(IGraph<T> graph, ILoopIteratorCallback<T> mcb, IGraphStrongComponents<T> components) 
      where T : ICellCoordinate<T>;
  }
}