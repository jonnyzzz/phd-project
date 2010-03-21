using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;

namespace DSIS.Graph.Tarjan
{
  public class TarjanGraph<TCell> :
    AbstractGraph<TarjanGraph<TCell>, TCell, TarjanNode<TCell>>,
    IGraphExtension<TarjanNode<TCell>, TCell>,
    IGraphBuilder<TCell>
    where TCell : ICellCoordinate
  {
    public TarjanGraph(ICellCoordinateSystem<TCell> coordinateSystem) : base(coordinateSystem)
    {
    }

    public override IEqualityComparer<TarjanNode<TCell>> Comparer
    {
      get { return new NodeEqualityComparer<TarjanNode<TCell>, TCell>(); }
    }

    protected override TarjanGraph<TCell> CreateGraph(ICellCoordinateSystem<TCell> system)
    {
      return new TarjanGraph<TCell>(system);
    }

    public TarjanNode<TCell> CreateNode(TCell coordinate)
    {
      return new TarjanNode<TCell>(coordinate);
    }

    public void NodeAdded(TarjanNode<TCell> node)
    {      
    }

    public void EdgeAdded(TarjanNode<TCell> from, TarjanNode<TCell> to)
    {     
    }

    public void Dispose()
    {      
    }

    public void AddEdges(TCell from, IEnumerable<TCell> tos)
    {
      TarjanNode<TCell> fromNode = AddNode(from);
      foreach (var to in tos)
      {
        AddEdgeToNode(fromNode, AddNode(to));
      }
    }

    public IReadonlyGraph<TCell> BuildFinished()
    {
      return this;
    }
  }
}