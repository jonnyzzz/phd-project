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
		public InitializeOnRunAttribute() : this(false)
		{            
	    }

		private bool isInternal;

		public InitializeOnRunAttribute(bool isInternal)
		{
			this.isInternal = isInternal;
		}

		public bool IsInternal
		{
			get { return isInternal; }
		}
	}
}
