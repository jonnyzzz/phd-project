using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Core.Processor;
using DSIS.Utils;

namespace DSIS.Graph
{
  public class CachedGraphStrongComponents<T> : IGraphStrongComponents<T>
    where T : ICellCoordinate
  {
    private readonly IGraphStrongComponents<T> myOriginal;
    private readonly Dictionary<IStrongComponentInfo, IGraph<T>> myCache = new Dictionary<IStrongComponentInfo, IGraph<T>>();

    public CachedGraphStrongComponents(IGraphStrongComponents<T> original)
    {
      myOriginal = original;
    }

    private IGraph<T> Cache(IStrongComponentInfo info)
    {
      IGraph<T> graph;
      if (!myCache.TryGetValue(info, out graph))
      {
        graph = myOriginal.AsGraph(new[] {info});
        myCache[info] = graph;
      }
      return graph;
    }

    ICellCoordinateSystem IGraphStrongComponents.CoordinateSystem
    {
      get { return CoordinateSystem; }
    }

    public void DoGeneric(IGraphStrongComponentsWith with)
    {
      with.With(this);
    }

    public ICellCoordinateSystem<T> CoordinateSystem
    {
      get { return myOriginal.CoordinateSystem; }
    }

    public IEnumerable<INode<T>> GetNodes(IEnumerable<IStrongComponentInfo> componentIds)
    {
      var set = new HashSet<IStrongComponentInfo>(componentIds);
      return set.Maps(x => Cache(x).Nodes);
    }

    public IEnumerable<INode<T>> GetEdgesWithFilteredEdges(INode<T> node, IEnumerable<IStrongComponentInfo> componentIds)
    {
      //todo: Take into account edges between components!

      var set = new HashSet<IStrongComponentInfo>(componentIds);

      foreach (var info in myCache.Keys.Where(set.Contains).Join(set.Where(x => !myCache.ContainsKey(x))))
      {
        var g = (IReadonlyGraphEx<T>)Cache(info);
        var n = g.Find(node.Coordinate);
        if (n != null)
          //only one strong component may contain a node
          return g.GetEdges(n);
      }
      return EmptyArray<INode<T>>.Instance;
    }

    public ICellCoordinateCollection<T> GetCoordinates(IEnumerable<IStrongComponentInfo> componentIds)
    {
      var nodes = GetNodes(componentIds).Map(x => x.Coordinate);
      var count = new HashSet<IStrongComponentInfo>(componentIds).FoldLeft(0, (x,y)=>x.NodesCount+y);

      return new CellCoordinateCollection<T>(CoordinateSystem, nodes, count);
    }

    public IStrongComponentInfo GetNodeComponent(INode<T> node)
    {
      return myOriginal.GetNodeComponent(node);
    }

    public IGraph<T> AsGraph(IEnumerable<IStrongComponentInfo> components)
    {
      var set = new HashSet<IStrongComponentInfo>(components);
      if (set.Count != 1)
        throw new NotImplementedException("Cached components does not support extracting more than one component");

      return Cache(set.First());
    }

    public IEnumerable<IStrongComponentInfo> Components
    {
      get { return myOriginal.Components; }
    }

    public int ComponentCount
    {
      get { return myOriginal.ComponentCount; }
    }
  }
}