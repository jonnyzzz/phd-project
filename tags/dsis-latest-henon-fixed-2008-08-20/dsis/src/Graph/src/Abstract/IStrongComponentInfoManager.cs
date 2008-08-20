using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public interface IStrongComponentInfoManager
  {
    int Count { get; }

    IEnumerable<IStrongComponentInfo> Components { get; }

    IEnumerable<INode<TCellCoordinate>> FilterNodes<TCellCoordinate>(
      IEnumerable<IStrongComponentInfo> infos,
      IEnumerable<StrongComponentNode<TCellCoordinate>> nodes)
      where TCellCoordinate : ICellCoordinate;

    void AddComponent(IStrongComponentInfo info);
    void OnConnection(IStrongComponentInfo from, IStrongComponentInfo to);

    IStrongComponentInfo CreateComponentInfo();
  }
}