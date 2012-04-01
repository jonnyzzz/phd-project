using System;
using System.Drawing;
using DSIS.Core.System.Impl;
using DSIS.IntegerCoordinates;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.Graph.Images
{
  [ComponentImplementation]
  public class GraphFromImageBuilder
  {
    [Autowire]
    private IIntegerCoordinateFactory myFactory { get; set; }
      
    public IReadonlyGraph BuildGraphFromImage(Bitmap image, GraphFromImageBuilderParameters parameters)
    {
      var space = new DefaultSystemSpace(2, new[] {0.0, 0.0}, new double[] {image.Width, image.Height}, new long[] {1, 1});
      var system = myFactory.Create(space, new long[] {image.Width, image.Height});

      GraphFromPictureBuilderBase with;
      if (ComplexBuilder.Accepts(parameters))
      {
        with = new ComplexBuilder(image, (ComplexGraphFromImageBuilderParameters) parameters);
      } else if (FullBuilder.Accepts(parameters))
      {
        with = new FullBuilder(image, (FullGraphFromImageBuilderParameters) parameters);
      } else
      {
        throw new Exception("Failed to find suitable builder for " + parameters);
      }
      
      system.DoGeneric(with);

      return with.Graph;
    }
  }
}