using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  public class LoopIteratorSmart<T> : LoopIteratorBase<T>, ILoopIteratorCallback<T> where T : ICellCoordinate<T>
  {
    private readonly IGraphWeightSearch<T> mySearch;
    private readonly Hashset<INode<T>> myNodes = new Hashset<INode<T>>(EqualityComparerFactory<INode<T>>.GetComparer());

    public LoopIteratorSmart(ILoopIteratorCallback<T> callback, IGraphStrongComponents<T> components, IStrongComponentInfo component, IGraphWeightSearch<T> search) : base(callback, components, component)
    {
      mySearch = search;
    }

    public override void WidthSearch()
    {
      foreach (INode<T> node in myComponents.GetNodes(myComponentInfos))
      {
        if (myNodes.Contains(node))
          continue;
        
        mySearch.WidthSearch(this, node);
      }
    }

    public void OnLoopFound(IList<INode<T>> loop)
    {
      myNodes.AddRange(loop);
      myCallback.OnLoopFound(loop);
    }
  }
}