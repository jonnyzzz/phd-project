using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class GraphDataHolderProxy<TData, TCell, TNode> : IGraphDataHoler<TData, INode<TCell>>
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>     
  {
    private readonly IGraphDataHoler<TData, TNode> myHolder;

    public IGraphDataHoler<TData, TNode> Holder
    {
      get { return myHolder; }
    }

    public GraphDataHolderProxy(IGraphDataHoler<TData, TNode> holder)
    {
      myHolder = holder;
    }
   
    public TData GetData(INode<TCell> node)
    {
      return myHolder.GetData((TNode) node);
    }

    public void SetData(INode<TCell> node, TData data)
    {
      myHolder.SetData((TNode) node, data);
    }

    public bool HasData(INode<TCell> node)
    {
      return myHolder.HasData((TNode) node);
    }

    public void CleanAll()
    {
      myHolder.CleanAll();
    }

    public void Dispose()
    {
      myHolder.Dispose();
    }
  }
}