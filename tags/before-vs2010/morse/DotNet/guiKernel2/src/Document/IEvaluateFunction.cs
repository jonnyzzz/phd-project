namespace EugenePetrenko.Gui2.Kernell2.Document
{
  /// <summary>
  /// Summary description for IEvaluateFunction.
  /// </summary>
  public interface IEvaluateFunction
  {
    int Dimension { get; }
    double[] MinimalValue { get; }
    double[] MaximalValue { get; }
    double[] LipshitzConstant { get; }
  }
}