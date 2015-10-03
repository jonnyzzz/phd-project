using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class NodeSetFactory<TNode, TCell>
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>
  {
    private readonly INodeSetState<TNode, TCell> ourEmptyStatelessNodeState = CreateEmptyStatelessNode();

    private static readonly ArrayNodeSet<TNode, TCell>.DelegateAddOnOverflow myFromFourElementArray = FromFourElementArray;
    private static readonly ArrayNodeSet<TNode, TCell>.DelegateAddOnOverflow myFromEightElementArray = FromEightElementArray;
    private static readonly OneNodeSetState<TNode, TCell>.NextDelegate myFromOneNodeState = FromOneNodeState;
    private static readonly EmptyNodeSetState<TNode, TCell>.NextDelegate myFromEmptyState = FromEmptyState;

    public INodeSetState<TNode, TCell> Create()
    {      
      return ourEmptyStatelessNodeState;
    }

    private static EmptyNodeSetState<TNode, TCell> CreateEmptyStatelessNode()
    {
      return new EmptyNodeSetState<TNode, TCell>(myFromEmptyState);
    }

    private static INodeSetState<TNode, TCell> FromEmptyState(TNode t)
    {
      return new OneNodeSetState<TNode, TCell>(t, myFromOneNodeState);                                                    
    }

    private static INodeSetState<TNode, TCell> FromOneNodeState(TNode thisNode, TNode next)
    {
      return new ArrayNodeSet<TNode, TCell>(4, myFromFourElementArray, thisNode, next);
    }

    private static INodeSetState<TNode, TCell> FromFourElementArray(TNode[] nodes, TNode t)
    {
      return new ArrayNodeSet<TNode, TCell>(8, myFromEightElementArray, t, nodes);
    }

    private static INodeSetState<TNode, TCell> FromEightElementArray(TNode[] nodes, TNode t)
    {
      return new GraphNodeHashListSetState<TNode, TCell>(8, t, nodes);
    }
  }
}