using System.Xml;
using guiKernel2.Node;

namespace guiKernel2.Constraints
{
	/// <summary>
	/// Summary description for IConstraint.
	/// </summary>
	public interface IConstraint
	{
		bool Mathes(ResultSet resultSet);		
	}
}
