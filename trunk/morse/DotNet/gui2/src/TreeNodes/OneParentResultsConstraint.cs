using System.Xml;
using EugenePetrenko.Gui2.Application.TreeNodes;
using EugenePetrenko.Gui2.Kernell2.Constraints;
using EugenePetrenko.Gui2.Kernell2.Node;

namespace EugenePetrenko.Gui2.Kernell2.ActionFactory.Constraints
{
  /// <summary>
  /// Summary description for OneParentResultsConstraint.
  /// </summary>
  public class OneParentResultsConstraint : IConstraint
  {
    public OneParentResultsConstraint(XmlNode node)
    {
    }

    public bool Match(ResultSet resultSet)
    {
      NodeResultSet rs = resultSet as NodeResultSet;
      return rs == null || (rs.HasSameGraphs && rs.HasSameParent);
    }
  }
}