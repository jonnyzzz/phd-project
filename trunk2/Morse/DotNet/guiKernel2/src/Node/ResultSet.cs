using System;
using System.Collections;
using guiKernel2.Node;
using MorseKernel2;

namespace guiKernel2.src.Node
{
	/// <summary>
	/// Summary description for Results.
	/// </summary>
	public class ResultSet
	{
		private ArrayList results = new ArrayList();

		public ResultSet()
		{
		}

		public IResultSet ToResultSet
		{
			get
			{
				IWritableResultSet set = new CResultSetImplClass();
				foreach (IResultBase resultBase in ToResults)
				{
					set.AddResult(resultBase);
				}
				return (IResultSet)set;
			}
		}

		public IResultBase[] ToResults
		{
			get
			{
				return (IResultBase[])results.ToArray(typeof(IResultBase));
			}
		}

		public KernelNode[] ToNodes
		{
			get
			{
				ArrayList nodes = new ArrayList();
				foreach (IResultBase resultBase in ToResults)
				{
					nodes.Add(new KernelNode(resultBase));
				}
				return (KernelNode[])nodes.ToArray(typeof(KernelNode));
			}
		}

		protected void AddResult(IResultBase result)
		{
			results.Add(result);
		}

		protected void AddResultRange(IResultBase[] results)
		{
			this.results.AddRange(results);
		}

		protected void AddResultSet(IResultSet set)
		{
			for (int count = 0; count < set.GetCount(); count++)
			{
				AddResult(set.GetResult(count));
			}
		}

		public static ResultSet FromKernelNode(KernelNode node)
		{
			ResultSet resultSet = new ResultSet();
			resultSet.AddResult(node.Result);
			return resultSet;
		}

		public static ResultSet FromResultSet(IResultSet set)
		{
			ResultSet resultSet = new ResultSet();
			resultSet.AddResultSet(set);
			return resultSet;
		}
	}
}
