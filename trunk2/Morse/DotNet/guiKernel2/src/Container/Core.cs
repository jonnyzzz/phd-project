using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using guiKernel2.ActionFactory;
using guiKernel2.Document;
using guiKernel2.xml;
using MorseKernel2;

namespace guiKernel2.Container
{
	/// <summary>
	/// Summary description for Container.
	/// </summary>
	public class Core
	{
		public Core()
		{			
			instance = this;
			nextActionFactory = new NextActionFactory();

			XMLParser xmlParser = new XMLParser();
			
			this.assemblies = xmlParser.Assemblies;
			actionWrapperFactory = new ActionWrapperFactory(assemblies);
		}

        private NextActionFactory nextActionFactory = null;
		private ActionWrapperFactory actionWrapperFactory = null;
		private Assembly[] assemblies = null;
		private KernelDocument document = null;

		public void SetKernelDocument(KernelDocument document)
		{
			this.document = document;
		}

		public KernelDocument KernelDocument
		{
			get { return document; }
		}

		public Assembly[] Assemblies
		{
			get { return assemblies; }
		}


		public NextActionFactory NextActionFactory
		{
			get
			{
				return nextActionFactory;
			}
		}

		public ActionWrapperFactory ActionWrapperFactory
		{
			get { return actionWrapperFactory; }
		}

		private static Core instance = null;
		public static Core Instance
		{
			get
			{
				if (instance == null)
				{
					new Core();
				}
				return instance;
			}
		}


		public static Type GetType(string name)
		{
			foreach (Assembly assembly in Core.Instance.Assemblies)
			{
				foreach (Type type in assembly.GetTypes())
				{
					if (string.Equals(type.Name, name))
					{
						return type;
					}
				}
			}			

			throw new TypeLoadException("Unable to load type: Type not Found!");
		}


		public static bool ImplemetsType(object o, string interf) {
			return ImplemetsType(o, GetType(interf));
			
		}

		public static bool ImplemetsType(object o, Type t)
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
			} else
			{
				return o.GetType().GetInterface(t.Name) != null;
			}
		}
	}
}
