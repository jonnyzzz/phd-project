using System;
using System.Collections;
using guiKernel2.Container;
using guiKernel2.Node;
using MorseKernel2;

namespace guiKernel2.Node
{
	/// <summary>
	/// Summary description for Results.
	/// </summary>
	public class ResultSet
	{
		private ArrayList results = new ArrayList();

		protected ResultSet()
		{
		}

		#region getters
		private IResultSet resultSet = null;
		public IResultSet ToResultSet
		{
			get
			{
				if (resultSet == null) 
				{
					IWritableResultSet set = new CResultSetImplClass();
					foreach (IResultBase resultBase in ToResults)
					{
						set.AddResult(resultBase);
					}
					resultSet = (IResultSet)set;
				}
				return resultSet;
			}
		}

		public IResult[] ToResults
		{
			get
			{
				return (IResult[])results.ToArray(typeof(IResult));
			}
		}

		public KernelNode[] ToNodes
		{
			get
			{
				ArrayList nodes = new ArrayList();
				IResult[] results = ToResults;
				if (results.Length > 0 ) 
				{
					foreach (IResult result in results)
					{
						nodes.Add(new KernelNode(ResultSet.FromResult(result)));
					}
				} else
				{
					nodes.Add(new KernelNode(ResultSet.Empty()));
				}
				return (KernelNode[])nodes.ToArray(typeof(KernelNode));
			}
		}


		public int Count
		{
			get
			{
				return results.Count;
			}
		}

		#endregion

		#region protected Add's

		protected internal void AddResult(IResultBase result)
		{
			results.Add((IResult)result);
		}

		protected internal void AddResultRange(IResultBase[] results)
		{
			this.results.AddRange(results);
		}

		protected internal void AddResultSet(IResultSet set)
		{
			for (int count = 0; count < set.GetCount(); count++)
			{
				AddResult(set.GetResult(count));
			}
		}
		#endregion

		#region static

		public static ResultSet FromResultSets(params ResultSet[] resultSet)
		{
			ResultSet result = new ResultSet();
			foreach (ResultSet set in resultSet)
			{
				result.AddResultRange(set.ToResults);
			}
			return result;
		}

		public static ResultSet FromResultSet(IResultSet set)
		{
			ResultSet resultSet = new ResultSet();
			resultSet.AddResultSet(set);
			return resultSet;
		}

		public static ResultSet FromResult(params IResultBase[] result)
		{
			ResultSet resultSet = new ResultSet();
			resultSet.AddResultRange(result);
			return resultSet;
		}

		public static ResultSet Empty()
		{
			return new ResultSet();
		}

		public static ResultSet Merge(ResultSet resultSet, params IResult[] objs)
		{
			ResultSet resultSetRet = new ResultSet();
			resultSetRet.AddResultRange(resultSet.ToResults);
			resultSetRet.AddResultRange(objs);
			return resultSetRet;
		}

		#endregion


		public bool Match(string resultInterface, string metadataInterface)
		{
			IResult[] results = ToResults;
			if (results.Length == 0) return false;
			foreach (IResult result in results)
			{
				if (!(Core.ImplemetsType(result, resultInterface) && Core.ImplemetsType(result.GetMetadata(), metadataInterface))) 
				{
					return false;
				} 
			}
			return true;
		}


		public override string ToString()
		{
			return string.Format("ResultSet [ length = {0} ]", this.results.Count);
		}

	}
}
