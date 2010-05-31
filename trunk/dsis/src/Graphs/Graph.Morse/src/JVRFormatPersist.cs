using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Morse
{
  public class JVRFormatPersist<T> : IMorseEvaluatorPersist<T> 
    where T : ICellCoordinate
  {
    private readonly Func<string> GetTempFile;

    public JVRFormatPersist(Func<string> getTempFile)
    {
      GetTempFile = getTempFile;
    }

    public void SaveGraph(IMorseEvaluatorGraph<T> graph, Func<INode<T>, double> weight)
    {
      var i = 0;
      var nodes = new Dictionary<INode<T>, int>();
      foreach (var node in graph.GetNodes())
      {
        nodes[node] = i++;
      }

      var info = CultureInfo.GetCultureInfo("en-US");
      using (var tw = File.CreateText(GetTempFile()))
      {
        tw.WriteLine("from to cost length");

        foreach (var from in graph.GetNodes())
        {
          var w = weight(from);
          foreach (var to in graph.GetNodes(from))
          {
            tw.WriteLine("{0} {1} {2} 1",nodes[from], nodes[to], w.ToString(info));
          }
        }
      }

    }

    public string Name
    {
      get { return "JVR"; }
    }
  }
}