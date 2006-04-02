using System.Xml;
using EugenePetrenko.Gui2.Kernell2.Node;

namespace EugenePetrenko.Gui2.Kernell2.Constraints
{
	public delegate IConstraint[] ParseConstraints(XmlNode root); 
    /// <summary>
    /// Summary description for IConstraint.
    /// Should have constructor from XmlNode , [ParseConstraints delegate]
    /// </summary>
    public interface IConstraint
    {
        bool Match(ResultSet resultSet);
    }
}