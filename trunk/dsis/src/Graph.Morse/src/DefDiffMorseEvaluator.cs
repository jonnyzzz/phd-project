using System;
using DSIS.Core.System;
using DSIS.IntegerCoordinates;

namespace DSIS.Graph.Morse
{
  public class DefDiffMorseEvaluator<T> : MorseEvaluator<T> where T : IIntegerCoordinate
  {
    private readonly IDetDiffFunction<double> myFunction;
    private readonly double[] myCoords;
    private readonly IIntegerCoordinateSystem<T> mySystem;

    public DefDiffMorseEvaluator(
      MorseEvaluatorOptions opts,
      IDetDiffFunction<double> function,
      IGraphStrongComponents<T> components,
      IStrongComponentInfo comp) : base(opts, components, comp)
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