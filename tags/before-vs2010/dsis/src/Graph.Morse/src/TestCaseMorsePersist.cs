using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Morse
{
  public class TestCaseMorsePersist<T> : IMorseEvaluatorPersist<T> 
    where T : ICellCoordinate
  {
    private readonly Func<string> GetTempFile;

    public TestCaseMorsePersist(Func<string> getTempFile)
    {
      GetTempFile = getTempFile;
    }

    public void SaveGraph(IMorseEvaluatorGraph<T> graph, Func<INode<T>, double> weight)
    {
      using(var tw = File.CreateText(GetTempFile()))
      {
        int i = 0;
        //NOTE: Preserve order
        var nodes = new Dictionary<INode<T>, int>();
        foreach (var node in graph.GetNodes())
        {
          var nodeCost = weight(node);
          var cost = nodeCost.ToString("R", CultureInfo.GetCultureInfo("en-US"));
          var sCost = Convert.ToBase64String(BitConverter.GetBytes(nodeCost));
          tw.WriteLine("ctx.AddCost({0},{1}, \"{3}\"); //{2}", i, cost, node, sCost);
          i++;
        }

        tw.WriteLine();
        //NOTE: Preserve order!
        foreach (var node in graph.GetNodes())
        {
          foreach (var to in graph.GetNodes(node))
          {
            tw.WriteLine("ctx.AddEdge({0}, {1});", nodes[node], nodes[to]);
          }
        }
      }
    }

    public string Name
    {
      get { return "TestCase"; }
    }
  }
}