using System;

namespace gui.Attributes
{
	/// <summary>
	/// Summary description for InitializeStaticAttrubute.
	/// </summary>
	/// 

    [AttributeUsage(AttributeTargets.Method)]
	public class InitializeOnRunAttribute : Attribute
	{        
		public InitializeOnRunAttribute()
		{            
	    }
	}
}
