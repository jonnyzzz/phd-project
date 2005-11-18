using System.Xml;

namespace EugenePetrenko.Gui2.Kernell2.Constraints
{
    /// <summary>
    /// Summary description for ConstraintFactory.
    /// </summary>
    public interface IConstraintFactory
    {
        IConstraint CreateConstraint(XmlNode constraintNode);
    }
}