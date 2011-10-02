using System;
using System.Collections.Generic;
using System.Drawing;
using DSIS.Core.System.Impl;
using DSIS.Graph.Tarjan;
using DSIS.IntegerCoordinates;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;
using System.Linq;

namespace DSIS.Graph.Images
{
  public class GraphFromImageBuilderParameters
  {
    public Func<Color, double> Hash { get; set; }
    public int NumberOfEdgesPerPixel { get; set; }
    public int NumberOfNeighboursPerAxis { get; set; }
    public double Threasold { get; set; }    
  }

  [ComponentImplementation]
  public class GraphFromImageBuilder
  {
    [Autowire]
    private IIntegerCoordinateFactory myFactory { get; set; }
      
    public IReadonlyGraph BuildGraphFromImage(Bitmap image, GraphFromImageBuilderParameters parameters)
    {
      var space = new DefaultSystemSpace(2, new[] {0.0, 0.0}, new double[] {image.Width, image.Height}, new long[] {1, 1});
      var system = myFactory.Create(space, new long[] {image.Width, image.Height});

      var with = new WithCoordinateSystem(image, parameters);
      system.DoGeneric(with);

      return with.Graph;
    }

    private class WithCoordinateSystem: IIntegerCoordinateSystemWith
    {
      private readonly Bitmap myImage;
      private readonly GraphFromImageBuilderParameters myParameters;

      public WithCoordinateSystem(Bitmap image, GraphFromImageBuilderParameters parameters)
      {
        myImage = image;
        myParameters = parameters;
      }

      public IReadonlyGraph Graph { get; private set; }

      public void Do<R, Q>(R system) 
        where R : IIntegerCoordinateSystem<Q> 
        where Q : IIntegerCoordinate
      {
        var graph = new TarjanGraph<Q>(system);

        foreach (var p in AllPoints())
        {
          ProcessNode(p, system, graph);
        }
        Graph = graph;
      }

      private double Hash(Coord p)
      {
        return myParameters.Hash(myImage.GetPixel(p.X, p.Y));
      }

      private void ProcessNode<R, Q>(Coord p, R system, TarjanGraph<Q> graph)
        where R : IIntegerCoordinateSystem<Q>
        where Q : IIntegerCoordinate
      {
        var node = graph.AddNode(system.Create(p.X, p.Y));
        var hash = Hash(p);
        var arcs = Neighbours(p).ToArray();

        for (int i = 0; i < myParameters.NumberOfEdgesPerPixel; i++)
        {
          var arc = arcs.Minimize(_ => Math.Abs(hash - Hash(_)));
          if (Math.Abs(hash - Hash(arc)) > myParameters.Threasold) break;

          arcs = arcs.Where(_ => _ != arc).ToArray();

          graph.AddEdgeToNode(node, graph.AddNode(system.Create(arc.X, arc.Y)));
        }
      }

      private IEnumerable<Coord> Neighbours(Coord c)
      {
        var neighbous = myParameters.NumberOfNeighboursPerAxis;
        return from x in (c.X - neighbous).To(c.X + neighbous)
               where x >= 0 && x < myImage.Width && x != c.X

               from y in (c.Y - neighbous).To(c.Y + neighbous)               
               where y >= 0 && y < myImage.Height && y != c.Y

               select new Coord(x, y);
      }

      private IEnumerable<Coord> AllPoints()
      {
        return from x in 0.To(myImage.Width)
               from y in 0.To(myImage.Height)
               select new Coord(x, y);        
      }

      private struct Coord : IEquatable<Coord>
      {
        public readonly int X;
        public readonly int Y;

        public Coord(int x, int y)
        {
          X = x;
          Y = y;
        }

        public bool Equals(Coord other)
        {
          return other.X == X && other.Y == Y;
        }

        public override bool Equals(object obj)
        {
          if (ReferenceEquals(null, obj)) return false;
          if (obj.GetType() != typeof (Coord)) return false;
          return Equals((Coord) obj);
        }

        public override int GetHashCode()
        {
          unchecked { return (X*397) ^ Y; }
        }

        public static bool operator ==(Coord left, Coord right)
        {
          return left.Equals(right);
        }

        public static bool operator !=(Coord left, Coord right)
        {
          return !left.Equals(right);
        }
      }
    }
  }
}