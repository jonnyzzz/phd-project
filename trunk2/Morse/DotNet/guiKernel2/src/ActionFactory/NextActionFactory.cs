using System;
using System.Collections;
using System.Text;
using guiKernel2.ActionFactory.ActionInfos;
using guiKernel2.Actions;
using guiKernel2.Container;
using guiKernel2.Node;
using MorseKernel2;

namespace guiKernel2.ActionFactory
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
			foreach (ActionInfo actionInfo in actions)
			{
				if (node.Results.Match(actionInfo.ResultTypeName, actionInfo.MetadataTypeName))
				{
					Logger.Logger.LogMessage("Candidate Found: {0}", actionInfo);

					result.Add(actionInfo);
				}
			}
			return (ActionInfo[])result.ToArray(typeof(ActionInfo));
		}

		public static void DumpInteraces(object o)
		{	
			Type oType = o.GetType();
			Type resultType = typeof (IResult);
						
			Logger.Logger.LogMessage("Is IResult = {0}", o is IResult);

			Logger.Logger.LogMessage("CoreImplemets = {0}", Core.ImplemetsType(o, resultType));

			Logger.Logger.LogMessage("Has interface IResult = {0}", oType.GetInterface("IResult")!= null);
			
			Logger.Logger.LogMessage("Supported interfaces of {0}:", oType.FullName);
			
			foreach (Type type in oType.GetInterfaces())
			{
				Logger.Logger.LogMessage("\t{0}", type.Name);
			}
			Logger.Logger.LogMessage("End intrface dump");
		}

		private ActionRef[] FindActionInfosForPath(KernelNode node, ActionWrapper[] beforeActions)
		{
			return FindActionInfosForPath(FindActionInfos(node), beforeActions);			
		}

		private ActionRef[] FindActionInfosForPath(ActionRef[] acceptableActons, ActionWrapper[] selected)
		{
			if (selected.Length == 0) return acceptableActons;

			string nextActionName = selected[0].ActionMappingName;

			foreach (ActionRef actionInfo in acceptableActons)
			{
				if(string.Equals(actionInfo.ActionName, nextActionName))
				{
					ActionWrapper[] dec = new ActionWrapper[selected.Length-1];
					for (int i=1; i<selected.Length; i++)
					{
						dec[i-1] = selected[i];
					}
					return FindActionInfosForPath(actionInfo.ActionRefs, dec);
				}	
			}
			return new ActionInfo[0];
		}

		public ActionWrapper[] CreateInstances(ActionRef[] infos)
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
