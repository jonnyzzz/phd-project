using System;
using System.Collections.Generic;

namespace DSIS.Graph.Morse
{
  public abstract class MorseEvaluatorBase<T, ANode> : IMorseEvaluatorSaveSupport<T>
  {
    private readonly List<IMorseEvaluatorPersist<T>> myPersist = new List<IMorseEvaluatorPersist<T>>();
    private readonly IMorseEvaluatorGraph<T> myGraphComponent;
    private readonly IMorseEvaluatorCost<T> myCost;

    private readonly Dictionary<T, ANode> myNodes;
    private readonly Func<T, double, ANode> myCreateNode;

    protected MorseEvaluatorBase(IMorseEvaluatorGraph<T> graphComponent, IMorseEvaluatorCost<T> cost, Func<T, double, ANode> createNode)
    {
      myGraphComponent = graphComponent;
      myCreateNode = createNode;
      myCost = cost;
      myNodes = new Dictionary<T, ANode>(graphComponent.Comparer);
    }

    public void AddPersist(IMorseEvaluatorPersist<T> persist)
    {
      myPersist.Add(persist);
    }

    protected void SaveGraph(Func<T,double> cost)
    {
      foreach (var persist in myPersist)
      {
        persist.SaveGraph(myGraphComponent, cost);
      }
    }

    protected ANode CreateNode(T node)
    {
      ANode gnode;
      if (!myNodes.TryGetValue(node, out gnode))
      {
        gnode = myCreateNode(node, myCost.Cost(node));
        myNodes.Add(node, gnode);
      }
      return gnode;
    }

    protected long NodesCount { get { return myNodes.Count; } }

    protected IEnumerable<ANode> Nodes { get { return myNodes.Values; } }
  }
}