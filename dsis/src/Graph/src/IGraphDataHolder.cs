using System;
using System.Collections.Generic;

namespace DSIS.Graph
{
  public interface IGraphDataHolder<TData, in TNode> : IDisposable
  {
    TData GetData(TNode node);

    void SetData(TNode node, TData data);
    bool HasData(TNode node);

    IEnumerable<TData> Values { get; }
  }

  public static class GraphDataHolderUtilities
  {
    public static void Holding<TData, TNode>(this IGraphDataHolder<TData, TNode> holder, TNode node, Action<TData> action)
    {
      var data = holder.GetData(node);
      action(data);
      holder.SetData(node, data);
    }
  }
}