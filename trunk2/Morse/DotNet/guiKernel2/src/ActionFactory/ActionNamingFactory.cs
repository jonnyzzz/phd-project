using System;
using System.Collections;
using guiKernel2.Actions;

namespace guiKernel2.ActionFactory
{
	/// <summary>
	/// Summary description for ActionNamingFactory.
	/// </summary>
	public class ActionNamingFactory
	{
        private class Data
        {
            public string caption;
            public string detail;

            public Data(string caption, string detail)
            {
                this.caption = caption;
                this.detail = detail;
            }
        }

		private Hashtable names = new Hashtable(); //interfaceName -> caption
		public ActionNamingFactory()
		{
		}

		public void AddActionNaming(string actionName, string caption, string detail)
		{
			if (names.ContainsKey(actionName)) throw new ActionException("Unable to map more than one caption to one action");
			names[actionName] = new Data(caption, detail);
		}


		public string FindActionCaption(string actionName)
		{
            Data data = (Data) names[actionName];
            if (data == null) return "ActionCaptionNotDefined: " + actionName;            

			return data.caption;
		}

        public string FindActionComment(string actionName)
        {
            Data data = (Data) names[actionName];
            if (data == null) return "ActionDetailNotDefined: " + actionName;

            return data.detail;            
        }
	}
}
