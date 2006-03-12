using System.Xml;
using EugenePetrenko.Gui2.Kernell2.Constraints;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.Constraints
{
    public class FixedDimensionConstraint : IConstraint
    {
		private int[] dimensions;

    	public FixedDimensionConstraint(XmlNode constraintNode)
    	{
    		string value = constraintNode.Attributes["dimension"].Value;
			string[] data = value.Split(',');
			dimensions = new int[data.Length];
			for (int i=0; i<data.Length; i++)
			{
				dimensions[i] = int.Parse(data[i]);
			}        	
        }
    
        public bool Match(ResultSet resultSet)
        {
            foreach (IResult result in resultSet.ToResults)
            {
                if (result is IGraphResult)
                {
                    IGraphResult graphResult = (IGraphResult) result;
					bool succ = false;
                	foreach (int dimention in dimensions)
                	{
                		if (graphResult.GetGraphInfo().GetDimension() == dimention)
							succ = true;
                	}                	
                    if (!succ) 
						return false;
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