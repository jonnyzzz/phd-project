using System;
using System.Collections;
using guiKernel2.Actions;

namespace guiKernel2.src.ActionFactory
{
	/// <summary>
	/// Summary description for ActionNamingFactory.
	/// </summary>
	public class ActionNamingFactory
	{
		private Hashtable names = new Hashtable(); //interfaceName -> caption
		public ActionNamingFactory()
		{
		}

		public void AddActionNaming(string actionName, string caption )
		{
			if (names.ContainsKey(actionName)) throw new ActionException("Unable to map more than one caption to one action");
			names[actionName] = caption;
		}


		public string FindActionCaption(string actionName)
		{
			string name = names[actionName] as string;
			if (name == null)
			{
				name = "ActionCaptionNotDefined: " + actionName;
			}
			return name;
		}
	}
}
