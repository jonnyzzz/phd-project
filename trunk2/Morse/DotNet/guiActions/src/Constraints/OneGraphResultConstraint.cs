using System.Xml;
using EugenePetrenko.Gui2.Kernell2.Constraints;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.Constraints
{
    public class OneGraphResultConstraintFactory : IConstraintFactory
    {
        public IConstraint CreateConstraint(XmlNode constraintNode)
        {
            return new OneGraphResultConstraint();
        }
    }

    /// <summary>
    /// Summary description for OneGraphResultConstraint.
    /// </summary>
    public class OneGraphResultConstraint : IConstraint
    {
        public OneGraphResultConstraint()
        {
        }

        public bool Match(ResultSet resultSet)
        {
            return resultSet.ToResults.Length == 1 && resultSet.ToResults[0] is IGraphResult;
        }
    }
}