using System;
using System.Xml;
using guiKernel2.Constraints;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.Constraints
{
	/// <summary>
	/// Summary description for StrongCompGraphsConstraint.
	/// </summary>
	public class StrongCompGraphsConstraint : IConstraint
	{
		public StrongCompGraphsConstraint()
		{
		}

		public bool Mathes(ResultSet resultSet)
		{
			foreach (MorseKernel2.IResult result in resultSet.ToResults)
			{
				if (!(result is IGraphResult) || !(((IGraphResult)result).isStrongComponent())) return false;				
			}
			return true;			
		}
	}


	public class StrongCompGraphsConstraintFactory : IConstraintFactory
	{
		public IConstraint CreateConstraint(XmlNode constraintNode)
		{
			return new StrongCompGraphsConstraint();
		}
	}
}
