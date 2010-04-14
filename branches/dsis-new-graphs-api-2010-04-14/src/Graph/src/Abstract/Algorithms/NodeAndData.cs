using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Tarjan;

namespace DSIS.Graph.Abstract.Algorithms
{
  internal class NodeAndData<TNode, TCell> : IEquatable<NodeAndData<TNode, TCell>>
    where TNode : class, INode<TCell>
    where TCell : ICellCoordinate
  {
    public readonly TNode Node;
    public readonly TarjanNodeData<TCell, TNode> Data;

    public NodeAndData(TNode node, IGraphDataHolder<TarjanNodeData<TCell, TNode>, TNode> holder)
    {
      Node = node;
      Data = holder.GetData(node);
    }

    public bool Equals(NodeAndData<TNode, TCell> obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      return obj.Node == Node;
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != typeof(NodeAndData<TNode, TCell>)) return false;
      return Equals((NodeAndData<TNode, TCell>)obj);
    }

    public override int GetHashCode()
    {
      return (Node != null ? Node.GetHashCode() : 0);
    }

    public static bool operator ==(NodeAndData<TNode, TCell> left, NodeAndData<TNode, TCell> right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(NodeAndData<TNode, TCell> left, NodeAndData<TNode, TCell> right)
    {
      return !Equals(left, right);
    }
  }
}