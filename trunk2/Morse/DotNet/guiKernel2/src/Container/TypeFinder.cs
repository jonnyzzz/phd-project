using System;
using System.Collections;
using System.Reflection;

namespace EugenePetrenko.Gui2.Kernell2.src.Container
{
	/// <summary>
	/// Summary description for TypeFinder.
	/// </summary>
	/// 

    public delegate void TypeFound(Type t, object attribute);

	public class TypeFinder
	{
        private Hashtable/* Attribute -> Handler */ listeners = new Hashtable();

        public void Register(TypeFound found, Type attribute)
        {
            listeners[attribute] = found;
        }

        public void UnRegister(TypeFound found)
        {
            listeners.Remove(found);
        }

        public void Init(Assembly[] assemblies)
        {
            foreach (Assembly assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    foreach (object attribute in type.GetCustomAttributes(false))
                    {
                        foreach (DictionaryEntry entry in listeners)
                        {
                            if (attribute.GetType().Equals((Type)entry.Key))
                            {
                                ((TypeFound)entry.Value)(type, attribute);
                            }
                        }
                    }
                }
            }
        }        		
	}
}
