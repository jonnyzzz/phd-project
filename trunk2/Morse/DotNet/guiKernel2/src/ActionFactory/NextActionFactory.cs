using System;
using System.Collections;
using System.Text;
using guiKernel2.ActionFactory.ActionInfos;
using guiKernel2.Actions;
using guiKernel2.src.ActionFactory.ActionInfos;
using guiKernel2.src.Node;
using MorseKernel2;

namespace guiKernel2.src.ActionFactory
{
	/// <summary>
	/// Summary description for NextActionFactory.
	/// </summary>
	public class NextActionFactory
	{
		#region resovler

		public ActionWrapper[] NextAction(KernelNode node, ActionWrapper[] beforeActions )
		{
			return CreateInstances(FindActionInfosForPath(node, beforeActions));
		}

		public ActionWrapper[] NextAction(KernelNode node)
		{			
			ActionInfo[] infos = FindActionInfos(node);
			return CreateInstances(infos);
		}
		

		private ActionInfo[] FindActionInfos(KernelNode node)
		{
			ArrayList result = new ArrayList();
			string resultType = node.Result.GetType().Name;
			foreach (ActionInfo actionInfo in actions)
			{
				if (string.Equals(actionInfo.ResultType, resultType))
				{
					Logger.Logger.LogMessage("Candidate Found: {0}", actionInfo);
					IResultMetadata metadata =  node.Result.GetMetadata();
					if (metadata.GetType().GetInterface(actionInfo.MetadataName) != null)
					{
						result.Add(actionInfo);
					}
				}
			}
			return (ActionInfo[])result.ToArray(typeof(ActionInfo));
		}

		private ActionInfo[] FindActionInfosForPath(KernelNode node, ActionWrapper[] beforeActions)
		{
			return FindActionInfosForPath(FindActionInfos(node), beforeActions);			
		}

		private ActionInfo[] FindActionInfosForPath(ActionInfo[] acceptableActons, ActionWrapper[] selected)
		{
			if (selected.Length == 0) return acceptableActons;

			string nextActionName = selected[0].ActionMappingName;

			foreach (ActionInfo actionInfo in acceptableActons)
			{
				if(string.Equals(actionInfo.ActionName, nextActionName))
				{
					ActionWrapper[] dec = new ActionWrapper[selected.Length-1];
					for (int i=1; i<selected.Length; i++)
					{
						dec[i-1] = selected[i];
					}
					return FindActionInfosForPath(Resolve(actionInfo.ActionRefs), dec);
				}	
			}
			return new ActionInfo[0];
		}

		public ActionInfo Resolve(ActionRef reference)
		{
			return actionResolver[reference.ActionName] as ActionInfo;
		}

		public ActionInfo[] Resolve(ActionRef[] references)
		{
			ArrayList infos = new ArrayList();
			foreach (ActionRef actionRef in references)
			{
				infos.Add(actionRef.Resolve());
			}
			return (ActionInfo[])infos.ToArray(typeof(ActionInfo));
		}

		public ActionWrapper[] CreateInstances(ActionInfo[] infos)
		{
			ActionWrapper[] wrappers = new ActionWrapper[infos.Length];
			for (int i = 0; i<infos.Length; i++)
			{
				wrappers[i] = infos[i].CreateInstance();
			}
			return wrappers;
	}

		#endregion
		
		#region mapper

		ArrayList actions = new ArrayList();
		Hashtable actionResolver = new Hashtable();
		public void RegisterAction(ActionInfo info)
		{
			actions.Add(info);
			actionResolver[info.ActionName] = info;
		}	

		#endregion

		#region toStrings+ debugging

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("NextActionFactory :\n");

			foreach (ActionInfo actionInfo in actions)
			{
				sb.AppendFormat("\tRegistered Action : {0} \n", actionInfo.ToString());
			}

			return sb.ToString();
		}

		#endregion
	}
}
