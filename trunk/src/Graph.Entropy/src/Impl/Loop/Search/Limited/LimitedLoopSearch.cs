using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop.Search.Limited
{
  public class LimitedLoopSearch<T> : LoopIteratorBase<T> where T : ICellCoordinate<T>
  {
    private readonly int myDeep;
    private readonly IEqualityComparer<INode<T>> COMPARER = EqualityComparerFactory<INode<T>>.GetComparer();

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
        LoopSearch(node, skips);
      }
    }

    private void LoopSearch(INode<T> node, Hashset<INode<T>> skips)
    {
      Queue<INode<T>> list = new Queue<INode<T>>(myDeep);
      
      if (skips.Contains(node))
        return;

      list.Enqueue(node);
      foreach (INode<T> edge in myComponents.GetEdgesWithFilteredEdges(node, myComponentInfos))
      {
        DoSearch(myDeep, edge, node, list, skips);
      }
    }

    private void DoSearch(int deep, INode<T> current, INode<T> loop, Queue<INode<T>> path, Hashset<INode<T>> skips)
    {
      if (skips.Contains(current))
        return;

      if (COMPARER.Equals(current, loop))
      {
        List<INode<T>> found = new List<INode<T>>(path);
        found.Reverse();
        skips.AddRange(found);
        myCallback.OnLoopFound(found);
        return;
      }

      if (deep == 0)
        return;

      path.Enqueue(current);
      foreach (INode<T> edge in myComponents.GetEdgesWithFilteredEdges(current, myComponentInfos))
      {
        DoSearch(deep - 1, edge, loop, path, skips);
      }

      path.Dequeue();
    }
  }
}