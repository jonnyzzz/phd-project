using System;
using System.Reflection;
using gui.Logger;

namespace gui.Attributes
{
	/// <summary>
	/// Summary description for AttributeProcessor.
	/// </summary>
	public class AttributeProcessor
	{
        public static void InitializeStaticAttribute(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                MethodInfo[] methods =  type.GetMethods(BindingFlags.Public | BindingFlags.Static);
                foreach (MethodInfo method in methods)
                {
                    try 
                    {
                        InitializeOnRunAttribute[] attrs = (InitializeOnRunAttribute[])method.GetCustomAttributes(typeof(InitializeOnRunAttribute), false);
                        if (attrs.Length != 0)
                        {
                            method.Invoke(null, null);
                        }
                    } catch (Exception e)
                    {
                        Log.LogMessage(typeof(AttributeProcessor), "Type failed to initialize {0}", type.Name);
                        Log.LogException(typeof(AttributeProcessor), e, "Reflection exception in loading Actions");
                    }
                }
                /*
                try 
                {
                    object[] attributes = type.GetCustomAttributes(typeof(InitializeStaticAttrubute), true);
                    if (attributes.Length == 1)
                    {
                        InitializeStaticAttrubute att = (InitializeStaticAttrubute)attributes[0];
                        string register = att.Register;
                        MethodInfo mi =  type.GetMethod(register);                        
                        mi.Invoke(null, null);
                    }

                } catch (Exception e){
                    Log.LogMessage(typeof(AttributeProcessor), "Type failed to initialize {0}", type.Name);
                    Log.LogException(typeof(AttributeProcessor), e, "Reflection exception in loading Actions");
                }
                */
            }
        }
	}
}
