using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop.Search.Limited
{
  public class LimitedLoopSearch<T> : LoopIteratorBase<T> where T : ICellCoordinate
  {
    private static readonly IEqualityComparer<INode<T>> COMPARER = EqualityComparerFactory<INode<T>>.GetComparer();
    private readonly int myDeep;    

    public LimitedLoopSearch(int deep, ILoopIteratorCallback<T> callback, IGraphStrongComponents<T> components,
                             IStrongComponentInfo component) : base(callback, components, component)
    {
      myDeep = deep;
    }

    public override void WidthSearch()
    {
      Hashset<INode<T>> skips = new Hashset<INode<T>>(COMPARER);
      foreach (INode<T> node in myComponents.GetNodes(myComponentInfos))
      {
        if (skips.Contains(node))
          continue;

        LoopSearch(node, skips);
      }
    }

    private void LoopSearch(INode<T> node, Hashset<INode<T>> skips)
    {
      Queue<INode<T>> list = new Queue<INode<T>>(myDeep);
      Hashset<INode<T>> skips2 = new Hashset<INode<T>>(COMPARER); 

      list.Enqueue(node);
      skips2.Add(node);
              
      foreach (INode<T> edge in myComponents.GetEdgesWithFilteredEdges(node, myComponentInfos))
      { 
        DoSearch(myDeep, edge, node, list, skips, skips2);
      }
    }

    private void DoSearch(int deep, INode<T> current, INode<T> loop, Queue<INode<T>> path, Hashset<INode<T>> skips, Hashset<INode<T>> skips2)
    {    
      if (COMPARER.Equals(current, loop))
      {
        List<INode<T>> found = new List<INode<T>>(path);
        found.Reverse();
        skips.AddRange(found);
        myCallback.OnLoopFound(found);
        return;
      }

      if (skips2.Contains(current))
        return;

      if (deep == 0)
        return;

      skips2.Add(current);
      path.Enqueue(current);
        
      foreach (INode<T> edge in myComponents.GetEdgesWithFilteredEdges(current, myComponentInfos))
      {
        DoSearch(deep - 1, edge, loop, path, skips, skips2);
      }

      path.Dequeue();
      skips2.Remove(current);
    }
  }
}