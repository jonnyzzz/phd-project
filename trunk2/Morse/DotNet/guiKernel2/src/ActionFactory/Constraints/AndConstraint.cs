using EugenePetrenko.Gui2.Kernell2.Node;

namespace EugenePetrenko.Gui2.Kernell2.Constraints
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

        public bool Match(ResultSet resultSet)
        {
            foreach (IConstraint constraint in constraints)
            {
                if (!constraint.Match(resultSet)) return false;
            }
            return true;
        }

        public override string ToString()
        {
            return "AndAction";
        }
    }
}