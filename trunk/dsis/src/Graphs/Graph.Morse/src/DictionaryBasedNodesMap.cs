using System;
using System.Collections.Generic;

namespace DSIS.Graph.Morse
{
  public class DictionaryBasedNodesMap<T, ANode> : IMorseEvaluatorNodesMap<T, ANode>
  {
    private readonly Dictionary<T, ANode> myNodes;

    public DictionaryBasedNodesMap(IEqualityComparer<T> comparer)
    {
      myNodes = new Dictionary<T, ANode>(comparer);
    }

    public ANode Find(T node)
    {
      return myNodes[node];
    }

    public void Put(T node, ANode value)
    {
      myNodes[node] = value;
    }

    public IEnumerable<ANode> Nodes
    {
      get { return myNodes.Values; }
    }

    public long Count
    {
      get { return myNodes.Count; }
    }

    public void Dispose()
    {      
    }
  }
}