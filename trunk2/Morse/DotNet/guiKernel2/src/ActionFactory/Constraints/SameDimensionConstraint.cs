using System;
using System.Xml;
using EugenePetrenko.Gui2.Kernell2.Constraints;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Kernell2.ActionFactory.Constraints
{
	/// <summary>
	/// Summary description for SameDimensionConstraint.
	/// </summary>
	public class SameDimensionConstraint : IConstraint, IConstraintFactory
	{
		public SameDimensionConstraint()
		{
		}

		public bool Match(ResultSet resultSet)
		{
			if (resultSet.Count == 0) 
				return true;

			IGraphResult graph = resultSet[0] as IGraphResult;
			if (graph == null)
				return false;
			int dim = graph.GetGraphInfo().GetDimension();
			
			foreach (IResult result in resultSet)
			{
				IGraphResult graphResult = result as IGraphResult;
				if (graphResult == null || graphResult.GetGraphInfo().GetDimension() != dim)
					return false;				
			}
			return true;
		}

		public IConstraint CreateConstraint(XmlNode constraintNode)
		{
			return this;
		}
	}
}
