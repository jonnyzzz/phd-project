using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class AbstractGraphComponentIdHolder<TNode, TCell> : IGraphDataHoler<uint, TNode> where TNode : Node<TNode, TCell> where TCell : ICellCoordinate
  {
    public void Dispose()
    {
      //NOP
    }

    public uint GetData(TNode node)
    {
      return node.ComponentId;
    }

    public void SetData(TNode node, uint data)
    {
      node.SetComponentId(data);
    }

    public bool HasData(TNode node)
    {
      return true;
    }

    public void CleanAll()
    {
      //NOP
    }
  }
}