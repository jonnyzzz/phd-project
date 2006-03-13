using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using EugenePetrenko.Gui2.ExternalResource.Core;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.Kernell2.xml;
using EugenePetrenko.Gui2.Logging;

namespace EugenePetrenko.Gui2.Kernell2.Container
{
    /// <summary>
    /// Summary description for Container.
    /// </summary>
    public class Core : IDisposable
    {
        private readonly bool isInternal;
		private ActionNamingFactory actionNamingFactory = null;
		private NextActionFactory nextActionFactory = null;
		private ActionWrapperFactory actionWrapperFactory = null;
		private Assembly[] assemblies = null;
		private KernelDocument document = null;
		private TypeFinder typeFinder = new TypeFinder();
		private static Core instance = null;
		private ResourceManager resourceManager = null;


        public Core(bool isInternal)
        {
        	Application.CurrentCulture = new CultureInfo("en-US");
        	Thread.CurrentThread.Name = "UI";

            this.isInternal = isInternal;
            instance = this;

            resourceManager = new ResourceManager(IsInternal);
            
            nextActionFactory = new NextActionFactory();
            actionNamingFactory = new ActionNamingFactory();

            XMLParser xmlParser = new XMLParser();
            xmlParser.ParseAssemblyReferences();

            this.assemblies = xmlParser.Assemblies;
			typeFinder.Init();

            xmlParser.ParseActions();
            actionWrapperFactory = new ActionWrapperFactory(assemblies);

            NextActionFactory.CreateActionInstances();
        }

        public void ForseResourceManagerStart()
        {
            resourceManager.SetResourcePath("");
            resourceManager.SetTemporaryPath(Path.GetTempPath());
            resourceManager.Start();
        }
 
        public void Dispose()
        {
            if (resourceManager != null) resourceManager.Dispose();
            nextActionFactory = null;
            actionWrapperFactory = null;
            assemblies = null;
            document = null;
			typeFinder = null;
        }

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
            get { return nextActionFactory; }
        }

        public ActionNamingFactory ActionNamingFactory
        {
            get { return actionNamingFactory; }
        }

        public ActionWrapperFactory ActionWrapperFactory
        {
            get { return actionWrapperFactory; }
        }

    	public TypeFinder TypeFinder
    	{
    		get { return typeFinder; }
    	}

        public ResourceManager ResourceManager
        {
            get { return resourceManager; }
        }

        public static Core Instance
        {
            get { return instance; }
        }

        public bool IsInternal
        {
            get { return isInternal; }
        }

        public void GC()
        {
            Logger.LogMessage("Cleaning Memory: GC");
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            System.GC.Collect();
            Logger.LogMessage("Cleaning Memory: GC Finished");
        }
    }
}