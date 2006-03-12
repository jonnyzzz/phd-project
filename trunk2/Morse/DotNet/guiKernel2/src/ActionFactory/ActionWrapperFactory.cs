using System;
using System.Collections;
using System.Reflection;
using EugenePetrenko.Gui2.Kernell2.ActionFactory.ActionImpl;
using EugenePetrenko.Gui2.Kernell2.Actions;
using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.Logging;

namespace EugenePetrenko.Gui2.Kernell2.ActionFactory
{
    /// <summary>
    /// Summary description for ActionWrapperFactory.
    /// </summary>
    public class ActionWrapperFactory
    {
        private Hashtable mapping = new Hashtable(); //Type -> Typez
		private Hashtable nameToType = new Hashtable(); //string -> Type

        public ActionWrapperFactory(Assembly[] assemblies)
        {
            foreach (Assembly assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    ActionMappingAttribute[] attributes = (ActionMappingAttribute[]) type.GetCustomAttributes(typeof (ActionMappingAttribute), false);
                    if (attributes.Length > 1) throw new ActionWrapperFactoryException("Too much attributes for one class");

                    foreach (ActionMappingAttribute attribute in attributes)
                    {
                        AddActionMapping(attribute, type);
                    }
                }
            }
        }

        protected void AddActionMapping(ActionMappingAttribute attribute, Type type)
        {
            if (mapping.ContainsKey(attribute.ActionInterface)) throw new ActionWrapperFactoryException("ActionWrapper was allready defined");
            Logger.LogMessage("Found Action Mapping [interface = {0}, wrapper = {1}", attribute.ActionInterface.Name, type.Name);
            mapping[attribute.ActionInterface] = type;
        }

        protected Type GetWrapperType(Type action)
        {
            if (!mapping.ContainsKey(action)) 
				throw new ActionWrapperFactoryException("No action Wrapper for " + action.Name);

            return (Type) mapping[action];
        }


        public ActionWrapper CreateActionWrapper(string actionName, string actionCaption, bool isLeaf)
        {
            return CreateActionWrapper(GetTypeFromName(actionName), actionCaption, isLeaf);
        }

    	private Type GetTypeFromName(string actionName)
    	{
			return Core.Instance.TypeFinder.GetType(actionName);
    	}

    	private ActionWrapper CreateActionWrapper(Type actionType, string actionCaption, bool isLeaf)
        {
            Type wrapperType = GetWrapperType(actionType);
            ConstructorInfo info = wrapperType.GetConstructor(new Type[] {typeof (string), typeof (bool)});
            return info.Invoke(new object[] {actionCaption, isLeaf}) as ActionWrapper;
        }

        public ActionWrapper CreateDisabledAction(string caption, string detail)
        {
            IDisabledAction wrapper = (IDisabledAction) CreateActionWrapper(typeof (IDisabledActionInterface), caption, true);
            wrapper.SetComment(detail);
            return (ActionWrapper) wrapper;
        }

        public ActionWrapper CreateSeparator()
        {
            return CreateDisabledAction("--", null);
        }
    }
}