using System;
using System.Collections;
using guiKernel2.ActionFactory.ActionInfos;
using guiKernel2.Actions;
using guiKernel2.src.Container;

namespace guiKernel2.src.ActionFactory.ActionInfos
{
	/// <summary>
	/// Summary description for ActionInfo.
	/// </summary>
	public class ActionInfo : ActionRef
	{
		private readonly string metadataName;
		private readonly string resultType;

		public ActionInfo(string actionName, string resultType, string metadataName, bool isLeaf) : base(actionName, isLeaf)
		{
			this.metadataName = metadataName;
			this.resultType = resultType;
		}

		public string MetadataName
		{
			get { return metadataName; }
		}

		public string ResultType
		{
			get { return resultType; }
		}

		public override string ToString()
		{
			return string.Format("ActionInfo: [name = {0}, result = {1}, matadata = {2}, isLeaf = {3}]", ActionName, ResultType, MetadataName, IsLeaf);
		}

		public override ActionInfo Resolve()
		{
			return this;
		}

		public ActionWrapper CreateInstance()
		{
			return Core.Instance.ActionWrapperFactory.CreateActionWrapper(ActionName, IsLeaf);
		}
	}
}
