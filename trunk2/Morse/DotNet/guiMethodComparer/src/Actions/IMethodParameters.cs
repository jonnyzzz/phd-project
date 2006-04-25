using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.Kernell2.Node;

namespace Eugene.Petrenko.Gui2.MethodComparer.Actions
{
  public interface IMethodParameters
  {
    ResultSet InitialResultSet { get; }
    int NumberOfSteps { get; }
    int Dimension { get; }

    string Caption { get; }

    int Subdivision(int index);
    int NumberOfPoints(int index);
    double PointMethodOffset(int index);
    int TranslatePrecisionDevider(int index);
    bool BoxMethodUseDerivative();
    bool NeedResolveEdges();
    Function GetSystemFunction();
    int AdaptiveUpperLimit();
    
    bool DevideUnsimmetric { get; }
  }
}