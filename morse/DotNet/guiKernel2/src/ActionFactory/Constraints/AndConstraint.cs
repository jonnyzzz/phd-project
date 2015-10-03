using System.Xml;
using EugenePetrenko.Gui2.Kernell2.Node;

namespace EugenePetrenko.Gui2.Kernell2.Constraints
{
  /// <summary>
  /// Summary description for AndConstraint.
  /// </summary>
  public class AndConstraint : IConstraint
  {
    private readonly IConstraint[] constraints;

    public AndConstraint(params IConstraint[] constraints)
    {
      this.constraints = constraints;
    }

    public AndConstraint(XmlNode node, ParseConstraints parser) : this(parser(node))
    {
    }

    public bool Match(ResultSet resultSet)
    {
      foreach (IConstraint constraint in constraints)
      {
        if (!constraint.Match(resultSet)) return false;
      }
      return true;
    }

    public override string ToString()
    {
      return "AndAction";
    }
  }
}