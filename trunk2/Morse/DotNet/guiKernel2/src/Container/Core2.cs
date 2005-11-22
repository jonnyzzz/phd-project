using System;
using EugenePetrenko.Gui2.Kernell2.xml;

namespace EugenePetrenko.Gui2.Kernell2.Container
{
	/// <summary>
	/// Summary description for Core2.
	/// </summary>
	public class Core2
	{
        private bool isInternal;
        
		public Core2(bool isInternal)
		{
		    this.isInternal = isInternal;
		    instance = this;

		    XMLParser parser = new XMLParser();
            parser.ParseAssemblyReferences();


		}



        private static Core2 instance = null;
        public static Core2 Instance
        {
            get { return instance; }
        }
	}
}
