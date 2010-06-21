using System;
using DSIS.Core.System;
using DSIS.IntegerCoordinates;

namespace DSIS.Graph.Morse
{
  public class DetDiffMorseEvaluator<T,Q> : IMorseEvaluatorCost<T> 
    where T : INode<Q> 
    where Q : IIntegerCoordinate
  {
    private readonly IDetDiffFunction<double> myFunction;
    private readonly double[] myCoords;
    private readonly IIntegerCoordinateSystem<Q> mySystem;

    public DetDiffMorseEvaluator(IDetDiffFunction<double> function, IIntegerCoordinateSystem<Q> system) 
    {
      myFunction = function;
      myCoords = new double[myFunction.Dimension];
      mySystem = system;
    }

    public double Cost(T node)
    {
      mySystem.CenterPoint(node.Coordinate, myCoords);
      return Math.Log(Math.Abs(myFunction.Evaluate(myCoords)));
    }
  }
}