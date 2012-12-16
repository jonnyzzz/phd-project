using System;
using System.Collections.Generic;
using System.Drawing;
using DSIS.Graph.Tarjan;
using DSIS.IntegerCoordinates;

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

    protected abstract void ProcessNode<R,Q>(Coord coord, R system, TarjanGraph<Q> graph)
      where R : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate;

    protected IEnumerable<Coord> Neighbours(Coord c)
    {
      var neighbous = myParameters.NumberOfNeighboursPerAxis;

      for (int x = c.X - neighbous; x <= c.X + neighbous; x++)
      {
        for (int y = c.Y - neighbous; y <= c.Y + neighbous; y++)
        {
          if (x == c.X && y == c.Y) continue;
          if (x < 0 || x >= myImage.Width) continue;
          if (y < 0 || y >= myImage.Height) continue;

          yield return new Coord(x, y);
        }
      }
    }

    private IEnumerable<Coord> AllPoints()
    {
      for (int x = 0; x < myImage.Width; x++)
        for (int y = 0; y < myImage.Height; y++ )
          yield return new Coord(x, y);
    }
  }
}