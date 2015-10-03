using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Kernell2.Document
{
  /// <summary>
  /// Summary description for EvaluateFunction.
  /// </summary>
  public class EvaluateFunction : IEvaluateFunction
  {
    private int dimension;
    private double[] minimalValue;
    private double[] maximalValue;
    private double[] lipshitzValue;

    public EvaluateFunction(IFunction function)
    {
      dimension = function.GetDimension();
      minimalValue = new double[dimension];
      maximalValue = new double[dimension];
      lipshitzValue = new double[dimension];

      for (int i = 0; i < dimension; i++)
      {
        minimalValue[i] = function.GetMinimum(i);
        maximalValue[i] = function.GetMaximum(i);
        lipshitzValue[i] = function.GetLipshitz(i);
      }
    }

    public EvaluateFunction(Function function) : this(function.IFunction)
    {
    }

    public int Dimension
    {
      get { return dimension; }
    }

    public double[] MinimalValue
    {
      get { return minimalValue; }
    }

    public double[] MaximalValue
    {
      get { return maximalValue; }
    }

    public double[] LipshitzConstant
    {
      get { return lipshitzValue; }
    }
  }
}