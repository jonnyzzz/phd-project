using System.Collections;
using System.Text;
using guiKernel2.ActionFactory.ActionInfos;
using guiKernel2.Actions;
using guiKernel2.Constraints;
using guiKernel2.Container;

namespace guiKernel2.ActionFactory.ActionInfos
{
	/// <summary>
	/// Summary description for ActionRef.
	/// </summary>
	public class ActionRef
	{
		private readonly string actionName;
		private readonly IConstraint constraint;
		private readonly bool isLeaf;
		private ArrayList actionRefs = new ArrayList();

		public ActionRef(string actionName, IConstraint constraint, bool isLeaf)
		{
			this.actionName = actionName;
			this.constraint = constraint;
			this.isLeaf = isLeaf;
		}

		public ActionWrapper CreateInstance()
		{
			string caption = Core.Instance.ActionNamingFactory.FindActionCaption(ActionName);
			return Core.Instance.ActionWrapperFactory.CreateActionWrapper(ActionName, caption, IsLeaf);
		}

		public IConstraint Constraint
		{
			get { return constraint; }
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

		public override string ToString()
		{
			return string.Format("ActionRef [name = {0}, constraint = {2},  isLeaf = {1}]", actionName, isLeaf, constraint.ToString());
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
