using System;
using System.Collections;
using System.Reflection;
using guiKernel2.ActionFactory;
using guiKernel2.ActionFactory.ActionInfos;
using guiKernel2.Actions;
using guiKernel2.Container;

namespace guiKernel2.ActionFactory
{
	/// <summary>
	/// Summary description for ActionWrapperFactory.
	/// </summary>
	public class ActionWrapperFactory
	{
		Hashtable mapping = new Hashtable(); //Type -> Type
		
		public ActionWrapperFactory(Assembly[] assemblies)
		{
			foreach (Assembly assembly in assemblies)
			{
				foreach (Type type in assembly.GetTypes())
				{
					ActionMappingAttribute[] attributes = (ActionMappingAttribute[])type.GetCustomAttributes(typeof(ActionMappingAttribute), false);
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
			Logger.Logger.LogMessage("Found Action Mapping [interface = {0}, wrapper = {1}", attribute.ActionInterface.Name, type.Name);
			mapping[attribute.ActionInterface] = type;
		}

		protected Type GetWrapperType(Type action)
		{
			if (!mapping.ContainsKey(action)) throw new ActionWrapperFactoryException("No action Wrapper for " + action.Name);
			return mapping[action] as Type;
		}


		public ActionWrapper CreateActionWrapper(string actionName, bool isLeaf)
		{
			return CreateActionWrapper(Core.GetType(actionName), isLeaf);			
		}

		private ActionWrapper CreateActionWrapper(Type actionType, bool isLeaf)
		{
			Type wrapperType = GetWrapperType(actionType);
			ConstructorInfo info = wrapperType.GetConstructor(new Type[]{typeof(bool)});
			return info.Invoke(new object[]{isLeaf}) as ActionWrapper;			
		}
	}
}
