using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DSIS.Graph.Tarjan;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.Graph.Images
{
  internal abstract class GraphFromPictureBuilderBase : IIntegerCoordinateSystemWith
  {
    public IReadonlyGraph Graph { get; protected set; }

    public abstract void Do<R, Q>(R system)
      where R : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate;
  }

  internal abstract class GraphFromPictureBuilderBase<T>: GraphFromPictureBuilderBase
    where T : GraphFromImageBuilderParameters
  {
    protected readonly Bitmap myImage;
    protected readonly T myParameters;
    protected readonly Func<Color, double> myHash;
      
    protected GraphFromPictureBuilderBase(Bitmap image, T parameters)
    {
      myImage = image;
      myParameters = parameters;
      myHash = myParameters.Hash.Compile();
    }

    public static bool Accepts(GraphFromImageBuilderParameters p)
    {
      return p is T;
    }

    public override void Do<R, Q>(R system)
    {
      var graph = new TarjanGraph<Q>(system);

      foreach (var p in AllPoints())
      {
        ProcessNode(p, system, graph);
      }
      Graph = graph;
    }

    protected abstract void ProcessNode<R,Q>
      (Coord coord, R system, TarjanGraph<Q> graph)
      where R : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate;

    protected IEnumerable<Coord> Neighbours(Coord c)
    {
      var neighbous = myParameters.NumberOfNeighboursPerAxis;
      return from x in NeighbourCoords(c.X, neighbous)
             where x >= 0 && x < myImage.Width

             from y in NeighbourCoords(c.Y, neighbous)
             where y >= 0 && y < myImage.Height

             select new Coord(x, y);
    }

    private IEnumerable<int> NeighbourCoords(int c, int o)
    {
      int from = c - o;
      int to = c + o;

      while (from < c)
        yield return from++;
      from = c + 1;
      while (from <= to)
        yield return from++;
    }

    private IEnumerable<Coord> AllPoints()
    {
      return from x in 0.To(myImage.Width)
             from y in 0.To(myImage.Height)
             select new Coord(x, y);
    }
  }
}