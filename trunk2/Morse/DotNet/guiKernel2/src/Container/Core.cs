using System;
using System.Reflection;
using System.Runtime.InteropServices;
using EugenePetrenko.Gui2.ExternalResource.Core;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.Kernell2.xml;

namespace EugenePetrenko.Gui2.Kernell2.Container
{
    /// <summary>
    /// Summary description for Container.
    /// </summary>
    public class Core : IDisposable
    {
        private readonly bool isInternal;

        public Core(bool isInternal)
        {
            this.isInternal = isInternal;
            instance = this;

            resourceManager = new ResourceManager(IsInternal);

            nextActionFactory = new NextActionFactory();
            actionNamingFactory = new ActionNamingFactory();

            XMLParser xmlParser = new XMLParser();

            xmlParser.ParseAssemblyReferences();

            this.assemblies = xmlParser.Assemblies;

            xmlParser.ParseActions();


            actionWrapperFactory = new ActionWrapperFactory(assemblies);
        }

        private ActionNamingFactory actionNamingFactory = null;
        private NextActionFactory nextActionFactory = null;
        private ActionWrapperFactory actionWrapperFactory = null;
        private Assembly[] assemblies = null;
        private KernelDocument document = null;

        public void Dispose()
        {
            if (resourceManager != null) resourceManager.Dispose();
            nextActionFactory = null;
            actionWrapperFactory = null;
            assemblies = null;
            document = null;
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

        private static Core instance = null;
        private ResourceManager resourceManager = null;

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


        public static bool ImplemetsType(object o, string interf)
        {
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
            }
            else
            {
                return o.GetType().GetInterface(t.Name) != null;
            }
        }
    }
}