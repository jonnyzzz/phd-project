using System.Xml;
using guiKernel2.Constraints;

namespace guiKernel2.Constraints
{
	/// <summary>
	/// Summary description for ConstraintFactory.
	/// </summary>
	public interface IConstraintFactory
	{
		IConstraint CreateConstraint(XmlNode constraintNode);
	}
}