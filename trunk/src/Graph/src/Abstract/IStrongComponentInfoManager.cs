using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public interface IStrongComponentInfoManager
  {
    int Count { get; }

    IEnumerable<IStrongComponentInfo> Components { get; }

    IEnumerable<INode<TCellCoordinate, TValue>> FilterNodes<TCellCoordinate, TValue>(
      IEnumerable<IStrongComponentInfo> infos, 
      IEnumerable<StrongComponentNode<TCellCoordinate, TValue>> nodes) 
      where TCellCoordinate : ICellCoordinate<TCellCoordinate>;
    
    void AddComponent(IStrongComponentInfo info);
    void OnConnection(IStrongComponentInfo from, IStrongComponentInfo to);

    IStrongComponentInfo CreateComponentInfo();
  }
}