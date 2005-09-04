using System;
using System.Xml;
using guiKernel2.Constraints;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.src.Constraints
{
	/// <summary>
	/// Summary description for FixedDimensionConstraint.
	/// </summary>
	public class FixedDimensionConstraint : IConstraint
	{
        private int dimension;

	    public bool Match(ResultSet resultSet)
	    {
	        foreach (MorseKernel2.IResult result in resultSet.ToResults)
	        {
	            if (result is IGraphResult)
	            {
	                IGraphResult graphResult = (IGraphResult) result;
                    if (graphResult.GetGraphInfo().GetDimension() != dimension) 
                        return false;
	            } else
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

    public class FixedDimensionConstraintFactory : IConstraintFactory
    {
        public IConstraint CreateConstraint(XmlNode constraintNode)
        {
            return new FixedDimensionConstraint(int.Parse(constraintNode.Attributes["dimension"].Value));
        }
    }
}
