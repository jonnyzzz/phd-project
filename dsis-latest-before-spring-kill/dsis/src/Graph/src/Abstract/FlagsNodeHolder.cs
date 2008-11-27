using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class FlagsNodeHolder<TInh, TNode, TCell> : IGraphDataHoler<bool, TNode>
    where TNode : Node<TNode, TCell>
    where TCell : ICellCoordinate
    where TInh : AbstractGraph<TInh, TCell, TNode>, IGraphExtension<TNode, TCell>
  {
    private readonly AbstractGraph<TInh, TCell, TNode> myGraph;
    private readonly NodeFlag myFlag;
    private readonly NodeFlags myFlags;

    public FlagsNodeHolder(AbstractGraph<TInh, TCell, TNode> graph, NodeFlags flags, NodeFlag flag)
    {
      myGraph = graph;
      myFlag = flag;
      myFlags = flags;
    }

    public NodeFlag Flag
    {
      get { return myFlag; }
    }

    public void Dispose()
    {
      myFlags.RemoveFlag(myFlag);
    }

    public bool GetData(TNode node)
    {
      return node.FlagValues.GetFlag(myFlag);
    }

    public void SetData(TNode node, bool data)
    {
      node.FlagValues.SetFlag(myFlag, data);
    }

    public bool HasData(TNode node)
    {
      return true;
    }

    public void CleanAll()
    {
      foreach (var tNode in myGraph.NodesInternal)
      {
        tNode.SetFlag(myFlag, false);
      }
    }
  }
}