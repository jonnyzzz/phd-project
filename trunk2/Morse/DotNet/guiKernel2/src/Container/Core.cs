using System;
using System.Reflection;
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
			XMLParser xmlParser = new XMLParser();
			this.assemblies = xmlParser.ImplAssemblies;			
		}

        private NextActionFactory nextActionFactory = new NextActionFactory();
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
		

		private static Core instance = null;
		public static Core Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Core();
				}
				return instance;
			}
		}
	}
}
