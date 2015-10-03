using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Utils.Bean;

namespace DSIS.Graph.Entropy.Impl.Loop.Weight
{
  public static class EntropyEdgeWeights
  {
    [IncludeValue(Title = "1")]
    public static readonly IEntropyEdgeWeightCallback CONST = new EntrotyEdgeConstWeight(1);

    private class EntrotyEdgeConstWeight : IEntropyEdgeWeightCallback
    {
      private readonly double myWeight;

      public EntrotyEdgeConstWeight(double weight)
      {
        myWeight = weight;
      }

      public string Name
      {
        get { return "Const"; }
      }

      public double EdgeWeight<T, Q>(Q system, JVRPair<T> edge, int index) 
        where T : ICellCoordinate 
        where Q : ICellCoordinateSystem<T>
      {
        return myWeight;
      }
    }
  }
}