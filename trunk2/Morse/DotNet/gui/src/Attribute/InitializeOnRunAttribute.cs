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

		public InitializeOnRunAttribute(bool isInternala)
		{
			this.isInternal = isInternala;
		}

		public bool IsInternal
		{
			get { return isInternal; }
		}
	}
}
