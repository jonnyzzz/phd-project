using System;
using System.Collections.Generic;
using System.Linq;

namespace DSIS.Graph.Morse
{
  public abstract class MorseEvaluatorBase<T, ANode> : IMorseEvaluatorSaveSupport<T>, IDisposable
  {
    private readonly List<IMorseEvaluatorPersist<T>> myPersist = new List<IMorseEvaluatorPersist<T>>();
    private readonly IMorseEvaluatorGraph<T> myGraphComponent;
    private readonly IMorseEvaluatorCost<T> myCost;

    private readonly IMorseEvaluatorNodesMap<T, ANode> myNodes;
    private readonly Func<T, double, ANode> myCreateNode;

    protected MorseEvaluatorBase(IMorseEvaluatorGraph<T> graphComponent, IMorseEvaluatorCost<T> cost, Func<T, double, ANode> createNode)
    {
      myGraphComponent = graphComponent;
      myCreateNode = createNode;
      myCost = cost;

      if (graphComponent is IMorseEvaluatorNodeMapProvider<T>)
        myNodes = ((IMorseEvaluatorNodeMapProvider<T>) graphComponent).CreateMap<ANode>();
      else
        myNodes = new DictionaryBasedNodesMap<T, ANode>(graphComponent.Comparer);
    }

    public void Dispose()
    {
      myNodes.Dispose();
    }

    public ComputationResult<T> Minimize()
    {
      foreach (var node in myGraphComponent.GetNodes())
      {
        var gnode = myCreateNode(node, myCost.Cost(node));
        myNodes.Put(node, gnode);
      }
      
      SaveGraph();
      
      return MinimizeInternal();
    }

    protected abstract ComputationResult<T> MinimizeInternal();
    
    public void AddPersist(IMorseEvaluatorPersist<T> persist)
    {
      myPersist.Add(persist);
    }

    private void SaveGraph()
    {
      foreach (var persist in myPersist)
      {
        //NOTE: this may not be optimal way. This leads to cost recomputation
        persist.SaveGraph(myGraphComponent, x=>myCost.Cost(x));
      }
    }

    private ANode CreateNode(T node)
    {
      return myNodes.Find(node);
    }

    protected long NodesCount { get { return myNodes.Count; } }

    protected IEnumerable<ANode> Nodes { get { return myNodes.Nodes; } }

    protected IEnumerable<ANode> NodesFrom(T node)
    {
      return myGraphComponent.GetNodes(node).Select(CreateNode);
    }
  }
}