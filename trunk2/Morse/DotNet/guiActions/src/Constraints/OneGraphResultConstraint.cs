using System;
using System.Xml;
using guiKernel2.Constraints;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.src.Constraints
{
	/// <summary>
	/// Summary description for OneGraphResultConstraint.
	/// </summary>
	public class OneGraphResultConstraint : IConstraint
	{
		public OneGraphResultConstraint()
		{
		}

		public bool Mathes(ResultSet resultSet)
		{
			return resultSet.ToResults.Length == 1 && resultSet.ToResults[0] is IGraphResult;
		}
	}


	public class OneGraphResultConstraintFactory : IConstraintFactory
	{
		public IConstraint CreateConstraint(XmlNode constraintNode)
		{
			return new OneGraphResultConstraint();
		}
	}
}
