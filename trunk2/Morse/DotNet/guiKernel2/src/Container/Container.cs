using System;
using guiKernel2.src.ActionFactory;

namespace guiKernel2.src.Container
{
	/// <summary>
	/// Summary description for Container.
	/// </summary>
	public class Container
	{
		public Container()
		{			
		}

        private NextActionFactory nextActionFactory = new NextActionFactory();
		public NextActionFactory NextActionFactory
		{
			get
			{
				return nextActionFactory;
			}
		}
		

		private static Container instance = null;
		public static Container Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Container();
				}
				return instance;
			}
		}
	}
}
