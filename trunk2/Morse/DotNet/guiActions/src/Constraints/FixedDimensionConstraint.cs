using System.Xml;
using EugenePetrenko.Gui2.Kernell2.Constraints;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.Constraints
{
    public class FixedDimensionConstraintFactory : IConstraintFactory
    {
        public IConstraint CreateConstraint(XmlNode constraintNode)
        {
            return new FixedDimensionConstraint(int.Parse(constraintNode.Attributes["dimension"].Value));
        }
    }

    /// <summary>
    /// Summary description for FixedDimensionConstraint.
    /// </summary>
    public class FixedDimensionConstraint : IConstraint
    {
        private int dimension;

        public bool Match(ResultSet resultSet)
        {
            foreach (IResult result in resultSet.ToResults)
            {
                if (result is IGraphResult)
                {
                    IGraphResult graphResult = (IGraphResult) result;
                    if (graphResult.GetGraphInfo().GetDimension() != dimension)
                        return false;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public FixedDimensionConstraint(int dimension)
        {
            this.dimension = dimension;
        }
    }
}