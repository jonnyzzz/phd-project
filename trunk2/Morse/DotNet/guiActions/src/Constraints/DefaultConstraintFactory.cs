using System.Xml;
using EugenePetrenko.Gui2.Kernell2.Constraints;

namespace EugenePetrenko.Gui2.Actions.Constraints
{
    /// <summary>
    /// Summary description for DefaultConstraintFactory.
    /// </summary>
    public class DefaultConstraintFactory : IConstraintFactory
    {
        public IConstraint CreateConstraint(XmlNode constraintNode)
        {
            XmlAttributeCollection attributes = constraintNode.Attributes;
            return new DefaultConstraint(attributes["metadata"].Value, attributes["result"].Value);
        }
    }
}