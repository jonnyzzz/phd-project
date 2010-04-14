using System;
using DSIS.Core.System;
using DSIS.IntegerCoordinates;

namespace DSIS.Graph.Morse
{
  public class DetDiffMorseEvaluator<T> : MorseEvaluator<T> where T : IIntegerCoordinate
  {
    private readonly IDetDiffFunction<double> myFunction;
    private readonly double[] myCoords;
    private readonly IIntegerCoordinateSystem<T> mySystem;

    public DetDiffMorseEvaluator(
      MorseEvaluatorOptions opts,
      IDetDiffFunction<double> function,
      IGraphStrongComponents<T> components,
      IStrongComponentInfo comp) : base(opts, new MorseStrongComponentGraph<T>(components, comp))
    {
      myFunction = function;
      myCoords = new double[myFunction.Dimension];
      mySystem = (IIntegerCoordinateSystem<T>) components.CoordinateSystem;
    }

    protected override double Cost(INode<T> node)
    {
      mySystem.CenterPoint(node.Coordinate, myCoords);
      return Math.Log(Math.Abs(myFunction.Evaluate(myCoords)));
    }
  }
}