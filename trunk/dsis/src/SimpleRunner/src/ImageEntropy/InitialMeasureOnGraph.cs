using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Graph.Entropy.Impl.Loop.Weight;

namespace DSIS.SimpleRunner.ImageEntropy
{
  public class PixelsWeightCallback : IEntropyEdgeWeightCallback
  {
    private readonly Func<int, int, double> myWeight;

    public PixelsWeightCallback(string name, Func<int, int, double> weight)
    {
      Name = name;
      myWeight = weight;
    }

    public string Name { get; private set; }

    public double EdgeWeight<T, Q>(Q system, JVRPair<T> edge, int index)
      where T : ICellCoordinate
      where Q : ICellCoordinateSystem<T>
    {
      var p = CoordinateConverter<Q>.CreateCoordinatesConverter(system).Cast(edge.From);
      int x = p[0];
      int y = p[1];
      return myWeight(x, y);
    }
  }

  public static class PixelsWeightCallbackExtensions
  {
    public static IEntropyEdgeWeightCallback AsEntropyWeightCallback(this ImageEntropyData data)
    {
      var image = data.Image;
      var func = data.GraphParameters.Hash.Compile();
      return new PixelsWeightCallback("from image", (x, y) => func(image.GetPixel(x, y)));
    }
  }
}
