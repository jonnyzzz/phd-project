using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Morse
{
  public class MorseStrongComponentGraph<T, TNode> : IMorseEvaluatorGraph<TNode> 
    where T : ICellCoordinate
    where TNode : class, INode<T>
  {
    private readonly IReadonlyGraphStrongComponents<T, TNode> myComponents;
    private readonly IReadonlyGraphStrongComponentsAccessor<T, TNode> myAccessor;
    private readonly long myCount;
    private readonly IEqualityComparer<TNode> myEqualityComparer;

    public MorseStrongComponentGraph(IReadonlyGraphStrongComponents<T, TNode> components, IStrongComponentInfo componentInfos)
    {
      myComponents = components;
      myAccessor = components.Accessor(componentInfos.Enum());
      myCount = componentInfos.NodesCount;
      myEqualityComparer = components.UnderlyingGraph.Comparer;
    }

    public IEnumerable<TNode> GetNodes(TNode node)
    {
      return myAccessor.GetEdges( node);
    }

    public IEnumerable<TNode> GetNodes()
    {
      return myAccessor.GetNodes();
    }

    public long Count
    {
      get { return myCount; }
    }

    public IEqualityComparer<TNode> Comparer
    {
      get { return myEqualityComparer; }
    }

    public IGraphDataHolder<T1, TNode> AllocDataHolder<T1>(Func<TNode, T1> def)
    {
      return myComponents.UnderlyingGraph.CreateDataHolder(def);
    }
  }
}