using System.Xml;
using EugenePetrenko.Gui2.Kernell2.Constraints;
using EugenePetrenko.Gui2.Kernell2.Node;

namespace EugenePetrenko.Gui2.Kernell2.ActionFactory.Constraints
{
  /// <summary>
  /// Summary description for OrConstraint.
  /// </summary>
  public class OrConstraint : IConstraint
  {
    private IConstraint[] constraints;

    public OrConstraint(XmlNode node, ParseConstraints parser)
    {
      constraints = parser(node);
    }

    public bool Match(ResultSet resultSet)
    {
      foreach (IConstraint constraint in constraints)
      {
        if (constraint.Match(resultSet))
          return true;
      }
      return false;
    }
  }
}