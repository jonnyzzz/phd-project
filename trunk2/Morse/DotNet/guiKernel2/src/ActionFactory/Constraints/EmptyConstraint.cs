using EugenePetrenko.Gui2.Kernell2.Node;

namespace EugenePetrenko.Gui2.Kernell2.Constraints
{
    public class EmptyConstraint : IConstraint
    {
        public EmptyConstraint()
        {
        }

        public bool Match(ResultSet resultSet)
        {
            return true;
        }

        public override string ToString()
        {
            return "Empty ";
        }
    }
}