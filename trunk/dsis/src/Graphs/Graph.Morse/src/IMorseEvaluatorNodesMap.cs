using System;
using System.Collections.Generic;

namespace DSIS.Graph.Morse
{
  public interface IMorseEvaluatorNodesMap<in T, ANode> : IDisposable
  {
    ANode Find(T node);
    void Put(T node, ANode value);
    IEnumerable<ANode> Nodes { get; }
    long Count { get; }
  }
}