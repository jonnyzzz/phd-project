using System;
using System.Collections;
using System.Reflection;
using guiKernel2.ActionFactory;
using guiKernel2.Actions;
using guiKernel2.src.ActionFactory;
using guiKernel2.src.Container;
using MorseKernel2;

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
			
			mapping[attribute.ActionInterface] = type;
		}

		public ActionWrapper CreateActionWrapper(string actionName, bool isLeaf)
		{
			return CreateActionWrapper(Type.GetType(actionName), isLeaf);
			
		}

		private ActionWrapper CreateActionWrapper(Type actionType, bool isLeaf)
		{
			IAction action = actionType.GetConstructor(new Type[]{}).Invoke(null, new object[]{}) as IAction;
			return CreateActionWrapper(action, actionType, isLeaf);
		}


		private ActionWrapper CreateActionWrapper(IAction action, Type actionType, bool isLeaf)
		{
			if (!mapping.ContainsKey(actionType)) throw new ActionWrapperFactoryException("Unable to find action mapping");

			Type wrapperType = mapping[actionType] as Type;

			ConstructorInfo constructor = wrapperType.GetConstructor(new Type[] { typeof(IAction), typeof(bool) } );
			return constructor.Invoke(null, new object[]{action, isLeaf}) as ActionWrapper;
		}	
	}
}
