using System;
using guiKernel2.Actions;
using guiKernel2.src.ActionFactory;

namespace guiKernel2.src.Actions
{
	/// <summary>
	/// Summary description for AttributeHolder.
	/// </summary>
	public class AttributeHolder
	{
		private ActionMappingAttribute myCachedAttribute = null;
		protected ActionMappingAttribute MyAttribute
		{
			get
			{
				if (myCachedAttribute == null) 
				{
					ActionMappingAttribute[] attributes = (ActionMappingAttribute[])this.GetType().GetCustomAttributes(typeof(ActionMappingAttribute), true);
					if (attributes.Length != 1) throw new ActionException("Incorrect Attribute");

					return myCachedAttribute = attributes[0];
				} 
				else
				{
					return myCachedAttribute;
				}
			}
		}
	}
}
