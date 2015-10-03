using System;

namespace EugenePetrenko.Gui2.Kernell2.ActionFactory2
{
	/// <summary>
	/// Summary description for ActionHandlerAttribute.
	/// </summary>
	/// 
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class ActionHandlerAttribute : Attribute
	{
	    private readonly string name;

	    public ActionHandlerAttribute(string name)
		{
		    this.name = name;
		}

	    public string Name
	    {
	        get { return name; }
	    }
	}
}
