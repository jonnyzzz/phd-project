using System.Xml;
using guiKernel2.ActionFactory.Constraints;
using guiKernel2.Constraints;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.src.actionImpl.GnuPlot
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

		public bool Mathes(ResultSet resultSet)
		{
			foreach (IResult result in resultSet.ToResults)
			{
				if (result is IGraphResult)
				{
					IGraphResult graphResult = (IGraphResult)result;
					int dimension = graphResult.GetGraphInfo().GetDimension();

					if (dimension != 2 && dimension != 3) return false;
				} else
				{
					return false;
				}
			}
			return true;
		}
	}
}
