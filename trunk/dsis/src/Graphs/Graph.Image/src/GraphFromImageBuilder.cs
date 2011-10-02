using System;
using System.Drawing;
using DSIS.Core.System.Impl;
using DSIS.Graph.Tarjan;
using DSIS.IntegerCoordinates;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.Graph.Images
{
  public class GraphFromImageBuilder
  {
    [Autowire]
    private IIntegerCoordinateFactory myFactory { get; set; }
      
    public IReadonlyGraph BuildGraphFromImage<T>(Bitmap image, Func<Color, double> color, Func<Color, T> hash)
      where T : IEquatable<T>
    {
      var space = new DefaultSystemSpace(2, new[] {0.0, 0.0}, new double[] {image.Width, image.Height}, new long[] {1, 1});
      var system = myFactory.Create(space, new long[] {image.Width, image.Height});

      system.DoGeneric(new WithCoordinateSystem<T>(image, color, hash));


        return null;
    }

    private class WithCoordinateSystem<T> : IIntegerCoordinateSystemWith
    {
      private readonly Bitmap myImage;
      private readonly Func<Color, double> myColor;
      private readonly Func<Color, T> myHash;

      public WithCoordinateSystem(Bitmap image, 
                                  Func<Color, double> color, 
                                  Func<Color, T> hash)
      {
        myImage = image;
        myColor = color;
        myHash = hash;
      }

      public void Do<R, Q>(R system) 
        where R : IIntegerCoordinateSystem<Q> 
        where Q : IIntegerCoordinate
      {
        var graph = new TarjanGraph<Q>(system);

        var colorMap = new MultiDictionary<T, TarjanNode<Q>>(EqualityComparerFactory<T>.GetComparer());

        //create nodes
        for (int i = 0; i < myImage.Width; i++)
        {
          for (int j = 0; j < myImage.Height; j++)
          {
            var node = graph.AddNode(system.Create(i, j));
            colorMap.AddValue(myHash(myImage.GetPixel(i, j)), node);
          }
        }

        //connect all nodes with same T
        foreach (var e in colorMap)
        {
          foreach (var a in e.Value)
          {
            foreach (var b in e.Value)
            {
              graph.AddEdgeToNode(a, b);
            }
          }
        }
      }
    }
  }
}