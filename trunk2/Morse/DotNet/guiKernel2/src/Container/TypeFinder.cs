using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;

namespace EugenePetrenko.Gui2.Kernell2.Container
{
	/// <summary>
	/// Summary description for TypeFinder.
	/// </summary>
	/// 
	public class TypeFinder
	{
        private Hashtable nameToType = new Hashtable();

		public void Init()
		{
			foreach (Assembly assembly in Core.Instance.Assemblies)
			{
				foreach (Type type in assembly.GetTypes())
				{
					nameToType[type.Name] = type;
				}
			}
		}

		public Type GetType(string name)
		{
			Type t = (Type) nameToType[name];
			if (t == null)
			{
				throw new TypeLoadException("Unable to load type: Type not Found! " + name);				
			}
			return t;
		}

		public bool ImplementsType(object o, string name)
		{
			return ImplementsType(o, GetType(name));
		}

		public bool ImplementsType(object o, Type t)
		{
			if (o.GetType().IsCOMObject)
			{
				try
				{
					Marshal.Release(Marshal.GetComInterfaceForObject(o, t));
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			}
			else
			{
				return o.GetType().IsAssignableFrom(t);
			}
		}
	}
}
