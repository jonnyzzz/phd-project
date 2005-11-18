using EugenePetrenko.Gui2.Kernell2.Node;

namespace EugenePetrenko.Gui2.Kernell2.Constraints
{
    /// <summary>
    /// Summary description for IConstraint.
    /// </summary>
    public interface IConstraint
    {
        bool Match(ResultSet resultSet);
    }
}