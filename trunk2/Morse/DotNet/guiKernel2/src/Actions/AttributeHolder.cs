using EugenePetrenko.Gui2.Kernell2.ActionFactory;

namespace EugenePetrenko.Gui2.Kernell2.Actions
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
                    ActionMappingAttribute[] attributes = (ActionMappingAttribute[]) this.GetType().GetCustomAttributes(typeof (ActionMappingAttribute), true);
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