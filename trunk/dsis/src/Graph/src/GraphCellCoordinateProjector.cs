using System;
using DSIS.Core.Coordinates;

namespace DSIS.Graph
{
  public class GraphCellCoordinateProjector<T> : ICellCoordinateSystemProjector<T> where T : ICellCoordinate<T>
  {
    private readonly ICellCoordinateSystemProjector<T> myProjector;
    private readonly IGraph<T> myGraph;

    public GraphCellCoordinateProjector(IGraph<T> graph, ICellCoordinateSystemProjector<T> projector)
    {
      myProjector = projector;
      myGraph = graph;

      if (!myGraph.CoordinateSystem.Equals(projector.ToSystem))
        throw new ArgumentException("Coordinate systems should be the same");
    }

    public T Project(T coordinate)
    {
      T project = myProjector.Project(coordinate);
      return project != null && !myGraph.Contains(coordinate) ? default(T) : project;
    }

    public ICellCoordinateSystem<T> FromSystem
    {
      get { return myProjector.FromSystem; }
    }

    public ICellCoordinateSystem<T> ToSystem
    {
      get { return myProjector.ToSystem; }
    }
  }
}