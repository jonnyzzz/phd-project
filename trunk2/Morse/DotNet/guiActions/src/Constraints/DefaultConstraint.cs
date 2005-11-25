using System;
using EugenePetrenko.Gui2.Kernell2.Constraints;
using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.Constraints
{
    /// <summary>
    /// Summary description for DefaultConstraint.
    /// </summary>
    public class DefaultConstraint : IConstraint
    {
        private readonly string metadataType;
        private readonly string resultType;

        public DefaultConstraint(Type metadata, Type resultType) : this(metadata.Name, resultType.Name)
        {
        }

        public DefaultConstraint(string metadataType, string resultType)
        {
            this.metadataType = metadataType;
            this.resultType = resultType;
        }

        public bool Match(ResultSet resultSet)
        {
            IResult[] results = resultSet.ToResults;
            if (results.Length == 0) return false;
            foreach (IResult result in results)
            {
                if (!(Core.ImplemetsType(result, resultType) && Core.ImplemetsType(result.GetMetadata(), metadataType)))
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            return string.Format("Default [ result = {0}, meta = {1}]", resultType, metadataType);
        }
    }
}