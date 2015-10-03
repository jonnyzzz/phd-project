using System;

namespace DSIS.Graph
{
  public interface IGraphDataHoler<TData,TNode> : IDisposable
  {
    TData GetData(TNode node);

    void SetData(TNode node, TData data);
    bool HasData(TNode node);

    void CleanAll();
  }
}