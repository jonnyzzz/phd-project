using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;
using DSIS.Graph.Abstract.Algorithms;
using DSIS.Graph.Entropy.Impl.Loop;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Tarjan;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.Graph.Entropy.Tests
{
  public abstract class LoopIteratorTestBase : GraphBaseTest
  {
    protected void DoTest(BuildGraph bg, params string[] golds)
    {
      DoTest(bg, false, golds);
    }

    protected delegate string[] LazyArray();

    protected void DoTest(BuildGraph bg, bool filter, params string[] golds)
    {
      DoTest(bg, filter, () => golds);
    }

    protected void DoTest(BuildGraph bg, bool filter, LazyArray lazyGolds)
    {
      TarjanGraph<IntegerCoordinate> graph = DoBuildGraph(bg);

      IGraphStrongComponents<IntegerCoordinate> components = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);

      Assert.IsTrue(components.ComponentCount > 0, "There is no components");

      var mcb = new MockCallback();
      IStrongComponentInfo firstComponent = components.Components.First();
      if (!filter)
      {
        ILoopIterator gws = CreateLoopIterator(graph, components, mcb, firstComponent);

        gws.WidthSearch();
      }
      else
      {
        var callback = new NonDuplicatedLoopIteratorCallback<IntegerCoordinate, MockCallback>(mcb);
        ILoopIterator gws = CreateLoopIterator(graph, components, callback, firstComponent);

        gws.WidthSearch();
      }

      var sb = new StringBuilder();
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

      string[] golds = lazyGolds();
      try
      {
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

        Assert.AreEqual(golds.Length, mcb.Loops.Count, "Incorrect loops count");
      }
      catch (Exception e)
      {
        Console.Error.WriteLine(sb.ToString().Trim());
        throw new Exception(e.Message, e);
      }
    }


    protected abstract ILoopIterator CreateLoopIterator(TarjanGraph<IntegerCoordinate> graph,
                                                                           IGraphStrongComponents<IntegerCoordinate>
                                                                             components,
                                                                           ILoopIteratorCallback<IntegerCoordinate> mcb,
                                                                           IStrongComponentInfo firstComponent);
  }
}