using System;
using System.Reflection;
using guiKernel2.ActionFactory;
using guiKernel2.src.ActionFactory;
using guiKernel2.xml;

namespace guiKernel2.src.Container
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
			
			this.assemblies = xmlParser.ImplAssemblies;
			actionWrapperFactory = new ActionWrapperFactory(assemblies);
		}

        private NextActionFactory nextActionFactory = null;
		private ActionWrapperFactory actionWrapperFactory = null;
		private Assembly[] assemblies = null;

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
	}
}
