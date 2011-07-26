using System;
using System.Drawing;
using DSIS.Core.System.Impl;
using DSIS.IntegerCoordinates;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.Graph.Images
{
  public class GraphFromImageBuilder
  {
    [Autowire]
    private IIntegerCoordinateFactory myFactory { get; set; }
      
    public IReadonlyGraph BuildGraphFromImage<T>(Image image, Func<Color, double> color, Func<Color, T> hash)
      where T : IEquatable<T>
    {
      var space = new DefaultSystemSpace(2, new[] {0.0, 0.0}, new double[] {image.Width, image.Height}, new long[] {1, 1});
      var system = myFactory.Create(space, new long[] {image.Width, image.Height});


      return null;
    }
  }
}