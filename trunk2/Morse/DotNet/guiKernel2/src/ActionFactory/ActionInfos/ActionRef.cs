using System;
using System.Collections;
using System.Text;
using guiKernel2.src.ActionFactory.ActionInfos;
using guiKernel2.src.Container;

namespace guiKernel2.ActionFactory.ActionInfos
{
	/// <summary>
	/// Summary description for ActionRef.
	/// </summary>
	public class ActionRef
	{
		private readonly string actionName;
		private readonly bool isLeaf;
		private ArrayList actionRefs = new ArrayList();

		public ActionRef(string actionName, bool isLeaf)
		{
			this.actionName = actionName;
			this.isLeaf = isLeaf;
		}

		public string ActionName
		{
			get { return actionName; }
		}

		public bool IsLeaf
		{
			get { return isLeaf; }
		}

		public void AddActionRef(ActionRef action)
		{
			actionRefs.Add(action);
		}

		public ActionRef[] ActionRefs
		{
			get
			{
				return (ActionRef[])actionRefs.ToArray(typeof(ActionRef));
			}
		}

		public virtual ActionInfo Resolve()
		{
			return Core.Instance.NextActionFactory.Resolve(this);
		}


		public override string ToString()
		{
			return string.Format("ActionRef [name = {0}, isLeaf = {1}]", actionName, isLeaf);
		}

		public string DumpTree()
		{
			StringBuilder sb = new StringBuilder();
			DumpContext(0, sb);
			return sb.ToString();
		}

		private void DumpContext(int depth, StringBuilder sb)
		{
			string tab = new string('\t', depth);

			sb.Append(tab);
			sb.Append(this.ToString());
			sb.Append("\n");
			foreach (ActionRef actionRef in ActionRefs)
			{
				actionRef.DumpContext(depth+1, sb);
			}
		}


	}
}
