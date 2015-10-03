using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;

namespace DSIS.Graph.Entropy.Impl.Loop.Search.Limited
{
  public class LimitedLoopSearch<T,N> : LoopIteratorBase<T,N> 
    where T : ICellCoordinate
    where N : class, INode<T>
  {
    private readonly int myDeep;    

    public LimitedLoopSearch(int deep, ILoopIteratorCallback<T,N> callback, IReadonlyGraphStrongComponents<T,N> components,
                             IStrongComponentInfo component) : base(callback, components, component)
    {
      myDeep = deep;
    }

    public override void WidthSearch()
    {
      var skips = new HashSet<N>(COMPARER);
      foreach (N node in myAccessor.GetNodes())
      {
        if (skips.Contains(node))
          continue;

        LoopSearch(node, skips);
      }
    }

    private void LoopSearch(N node, HashSet<N> skips)
    {
      var queue = new Queue<N>(myDeep);
      var skips2 = new HashSet<N>(COMPARER); 

      queue.Enqueue(node);
      skips2.Add(node);
              
      foreach (N edge in myAccessor.GetEdges(node))
      { 
        DoSearch(myDeep, edge, node, queue, skips, skips2);
      }
    }

    private void DoSearch(int deep, N current, N loop, Queue<N> path, HashSet<N> skips, HashSet<N> skips2)
    {    
      if (COMPARER.Equals(current, loop))
      {
        var found = new List<N>(path);
        found.Reverse();
        skips.UnionWith(found);
        myCallback.OnLoopFound(found, found.Count);
        return;
      }

      if (skips2.Contains(current))
        return;

      if (deep == 0)
        return;

      skips2.Add(current);
      path.Enqueue(current);
        
      foreach (N edge in myAccessor.GetEdges(current))
      {
        DoSearch(deep - 1, edge, loop, path, skips, skips2);
      }

      path.Dequeue();
      skips2.Remove(current);
    }
  }
}