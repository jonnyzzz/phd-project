using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.SimpleRunner.Entropy.Draw
{
  public abstract class DrawEntropyWithSpaceBase<T> : DrawBase 
    where T : IIntegerCoordinate
  {
    private Pair<ICellCoordinateSystem<T>, IDictionary<T, double>>? myWights;
    private double? myEntropy;

    protected double? Entropy
    {
      get { return myEntropy; }
    }

    protected Pair<ICellCoordinateSystem<T>, IDictionary<T, double>>? Wights
    {
      get { return myWights; }
    }

    public void SetMeasure(ICellCoordinateSystem<T> system, IDictionary<T, double> measure, double entropy)
    {
      myWights = new Pair<ICellCoordinateSystem<T>, IDictionary<T, double>>(system, measure);
      myEntropy = entropy;
    }
  }
}