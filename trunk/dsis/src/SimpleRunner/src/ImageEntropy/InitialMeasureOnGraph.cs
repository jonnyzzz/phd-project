using System;
using System.Drawing;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Graph.Entropy.Impl.Loop.Weight;

namespace DSIS.SimpleRunner.ImageEntropy
{
  internal class InitialMeasureOnGraph : IEntropyEdgeWeightCallback
  {
    private readonly ImageEntropyData myData;
    private readonly Func<Color, double> myFunc;

    public InitialMeasureOnGraph(ImageEntropyData data)
    {
      myData = data;
      myFunc = data.GraphParameters.Hash.Compile();
    }

    public string Name
    {
      get { return "From image"; }
    }

    public double EdgeWeight<T, Q>(Q system, JVRPair<T> edge, int index)
      where T : ICellCoordinate
      where Q : ICellCoordinateSystem<T>
    {
      var p = CoordinateConverter<Q>.CreateCoordinatesConverter(system).Cast(edge.From);
      int x = p[0];
      int y = p[1];
      var px = myData.Image.GetPixel(x, y);
      return myFunc(px);
    }
  }
}