using System.Xml;
using EugenePetrenko.Gui2.Kernell2.Constraints;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot
{
    /// <summary>
    /// Summary description for GnuPlotConstaint.
    /// </summary>
    public class GnuPlotConstraintFactory : IConstraintFactory, IConstraint
    {
        public GnuPlotConstraintFactory()
        {
        }

        public IConstraint CreateConstraint(XmlNode constraintNode)
        {
            return this;
        }

        public bool Match(ResultSet resultSet)
        {
            foreach (IResult result in resultSet.ToResults)
            {
                if (result is IGraphResult)
                {
                    IGraphResult graphResult = (IGraphResult) result;
                    int dimension = graphResult.GetGraphInfo().GetDimension();

                    if (dimension != 2 && dimension != 3) return false;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}