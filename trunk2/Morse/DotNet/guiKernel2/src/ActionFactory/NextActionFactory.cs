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
			ActionRef[] infos = FindActionRefs(node);
			return CreateInstances(infos);
		}
		

		private ActionRef[] FindActionRefs(KernelNode node)
		{
			ArrayList result = new ArrayList();
			foreach (ActionRef actionInfo in actions)
			{
				if ( actionInfo.Constraint.Mathes(node.Results) )
				{
					Logger.Logger.LogMessage("Candidate Found: {0}", actionInfo);

					result.Add(actionInfo);
				}
			}
			return (ActionRef[])result.ToArray(typeof(ActionRef));
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
			return FindActionInfosForPath(FindActionRefs(node), beforeActions);			
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
			return new ActionRef[0];
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
		public void RegisterAction(ActionRef info)
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

			foreach (ActionRef actionRef in actions)
			{
				sb.AppendFormat("\tRegistered Action : {0} \n", actionRef.ToString());
			}

			return sb.ToString();
		}

		#endregion
	}
}
