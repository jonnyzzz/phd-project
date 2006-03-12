using System.Xml;
using EugenePetrenko.Gui2.Kernell2.Constraints;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.Constraints 
{
    /// <summary>
    /// Summary description for StrongCompGraphsConstraint.
    /// </summary>
    public class StrongCompGraphsConstraint : IConstraint
    {
        public StrongCompGraphsConstraint(XmlNode node)
        {
        }

        public bool Match(ResultSet resultSet)
        {
            foreach (IResult result in resultSet.ToResults)
            {
                if (!(result is IGraphResult) || !(((IGraphResult) result).isStrongComponent())) return false;
            }
            return true;
        }
    }    
}