using System.Xml;
using guiKernel2.Constraints;
using guiKernel2.Container;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.Constraints
{
	/// <summary>
	/// Summary description for DefaultConstraint.
	/// </summary>
	public class DefaultConstraint : IConstraint
	{
		private readonly string metadataType;
		private readonly string resultType;

		public DefaultConstraint(string metadataType, string resultType)
		{
			this.metadataType = metadataType;
			this.resultType = resultType;
		}

		public bool Mathes(ResultSet resultSet)
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
