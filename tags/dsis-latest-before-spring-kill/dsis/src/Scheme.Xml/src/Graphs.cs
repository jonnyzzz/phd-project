using System.Collections.Generic;

namespace DSIS.Scheme.Xml
{
  public partial class Graphs
  {
    public Graph Find(string name)
    {
      foreach (var graph in graphField)
      {
        if (graph.Id == name)
        {
          return graph;
        }
      }
      throw new KeyNotFoundException("Graph with name " + name + " was not found");
    }
  }
}