using System.Xml;
using guiActions.Constraints;
using guiKernel2.Constraints;

namespace guiActions.Constraints
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
