using System.Xml;
using EugenePetrenko.Gui2.Kernell2.Constraints;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.Constraints
{
  public class OneGraphResultConstraint : IConstraint
  {
    public OneGraphResultConstraint(XmlNode constraintNode)
    {
    }

    public bool Match(ResultSet resultSet)
    {
      return resultSet.ToResults.Length == 1 && resultSet.ToResults[0] is IGraphResult;
    }
  }
}