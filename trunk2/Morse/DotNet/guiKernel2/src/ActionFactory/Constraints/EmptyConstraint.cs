using System.Xml;
using guiKernel2.Node;

namespace guiKernel2.Constraints
{
	public class EmptyConstraint : IConstraint
	{
		public EmptyConstraint()
		{			
		}

		public bool Mathes(ResultSet resultSet)
		{
			return true;
		}

		public override string ToString()
		{
			return "Empty ";
		}
	}
}
