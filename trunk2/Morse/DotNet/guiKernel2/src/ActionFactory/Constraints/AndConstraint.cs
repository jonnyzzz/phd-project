using guiKernel2.Constraints;
using guiKernel2.Node;

namespace guiKernel2.ActionFactory.Constraints
{
	/// <summary>
	/// Summary description for AndConstraint.
	/// </summary>
	public class AndConstraint : IConstraint
	{
		private readonly IConstraint[] constraints;

		public AndConstraint(params IConstraint[] constraints)
		{
			this.constraints = constraints;

		}

		public bool Mathes(ResultSet resultSet)
		{
			foreach (IConstraint constraint in constraints)
			{
				if (!constraint.Mathes(resultSet)) return false;
			}
			return true;
		}

		public override string ToString()
		{
			return "AndAction";
		}
	}
}
