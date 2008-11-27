using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace Eugene.Petrenko.Gui2.MethodComparer.Actions
{
  /// <summary>
  /// Summary description for AdaptiveMethodDefinedAction.
  /// </summary>
  public class AdaptiveMethodDefinedAction : UnsimmetricDefinedActionBase, IAdaptiveMethodParameters
  {
    private IAdaptiveMethodAction action;
    private double[] prec;

    public AdaptiveMethodDefinedAction(IMethodParameters methodParameters) : base(methodParameters)
    {
      action = (IAdaptiveMethodAction) Action;
    }

    public override string Name
    {
      get { return "Adaptive Method"; }
    }

    public override IAction Action
    {
      get { return new CAdaptiveMethodActionClass(); }
    }

    public override IParameters GetParameters(ResultSet forSet)
    {
      int dim = action.GetDimension(forSet.ToResultSet);
      prec = new double[dim];
      for (int i = 0; i < dim; i++)
      {
        prec[i] = action.GetRecomendedPrecision(forSet.ToResultSet, i)/GlobalParameters.TranslatePrecisionDevider(i);
      }
      return this;
    }

    public double GetPrecision(int index)
    {
      return prec[index];
    }

    public int GetUpperLimit()
    {
      return GlobalParameters.AdaptiveUpperLimit();
    }
  }
}