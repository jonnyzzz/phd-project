using System;
using System.Xml;
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
        private readonly Type metadataType;
        private readonly Type resultType;

		public DefaultConstraint(XmlNode constraintNode)
		{
			XmlAttributeCollection attributes = constraintNode.Attributes;
			TypeFinder typeFinder = Core.Instance.TypeFinder;

			metadataType = typeFinder.GetType(attributes["metadata"].Value);
			resultType = typeFinder.GetType(attributes["result"].Value);
		}

    	public DefaultConstraint(Type metadata, Type resultType) 
        {
			metadataType = metadata;
			this.resultType = resultType;
        }

        public bool Match(ResultSet resultSet)
        {
            IResult[] results = resultSet.ToResults;
            if (results.Length == 0) return false;
            foreach (IResult result in results)
            {
            	TypeFinder typeFinder = Core.Instance.TypeFinder;
            	if (!typeFinder.ImplementsType(result, resultType) || !typeFinder.ImplementsType(result.GetMetadata(), metadataType))                
                    return false;
            }
            return true;
        }

        public override string ToString()
        {
            return string.Format("Default [ result = {0}, meta = {1}]", resultType, metadataType);
        }    		
	}
}