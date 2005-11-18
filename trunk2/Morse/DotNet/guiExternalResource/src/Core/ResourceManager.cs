using System;
using System.IO;
using System.Xml;
using EugenePetrenko.Gui2.ExternalResource.FileResources;
using EugenePetrenko.Gui2.ExternalResource.Strings;
using EugenePetrenko.Gui2.ExternalResource.Xml;

namespace EugenePetrenko.Gui2.ExternalResource.Core
{
    /// <summary>
    /// Summary description for ResourceManeger.
    /// </summary>
    public class ResourceManager : IDisposable
    {
        private readonly bool isInternal;
        private static ResourceManager instance = null;

        public ResourceManager(bool isInternal)
        {
            this.isInternal = isInternal;
            instance = this;
            tempFileAllocator = new TempFileAllocator(isInternal);
            fileResources = new FileResources.FileResources();
            stringResources = new StringSet();
        }

        public bool IsInternal
        {
            get { return isInternal; }
        }

        public void Start()
        {
            xmlParser = new XMLParser();
        }

        public static ResourceManager Instance
        {
            get { return instance; }
        }

        private string resourcePath = null;
        private string temporaryPath = null;
        private TempFileAllocator tempFileAllocator = null;
        private FileResources.FileResources fileResources = null;
        private StringSet stringResources = null;
        private XMLParser xmlParser = null;

        public XmlNode GetXmlResource(string name)
        {
            return xmlParser.XmlResource(name);
        }

        public StringSet StringResources
        {
            get { return stringResources; }
        }

        public FileResources.FileResources FileResources
        {
            get { return fileResources; }
        }

        public string ResourcePath
        {
            get { return resourcePath; }
        }

        public string TemporaryPath
        {
            get { return temporaryPath; }
        }

        public TempFileAllocator TempFileAllocator
        {
            get { return tempFileAllocator; }
        }


        public void SetResourcePath(string path)
        {
            this.resourcePath = path;
        }

        public void SetTemporaryPath(string path)
        {
            this.temporaryPath = path;
        }

        public void Dispose()
        {
            if (TempFileAllocator != null) TempFileAllocator.Dispose();
        }

        public string AbsolutePathFileName(string path)
        {
            return SimplyfyPath(ResourcePath + "/" + path);
        }

        public string SimplyfyPath(string path)
        {
            return Path.GetFullPath(path);
        }
    }
}