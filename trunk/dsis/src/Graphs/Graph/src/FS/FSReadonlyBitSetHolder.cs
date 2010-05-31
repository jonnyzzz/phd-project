using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.FS
{
  public class FSReadonlyBitSetHolder<TNode, TCell> : IGraphDataHolder<bool, TNode>
    where TNode : FSReadonlyNode<TCell>
    where TCell : ICellCoordinate
  {
    private readonly BitSet myBitSet = new BitSet();

    public void Dispose()
    {
    }

    public bool GetData(TNode node)
    {
      return myBitSet.IsSet(node.Entry.EntryId);
    }

    public void SetData(TNode node, bool data)
    {
      myBitSet.Set(node.Entry.EntryId, data);
    }

    public bool HasData(TNode node)
    {
      return true;
    }
  }
}