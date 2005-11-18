using System;
using System.Collections;
using System.Xml;
using EugenePetrenko.Gui2.ExternalResource.Core;
using EugenePetrenko.Gui2.ExternalResource.FileResources;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Kernell2.Serialization
{
    /// <summary>
    /// Summary description for KernelNodeSerializer.
    /// </summary>
    public class KernelNodeSerializer
    {
        #region save

        public static XmlNode SaveKernelNode(KernelNode node, XmlDocument doc, String pathBase)
        {
            XmlNode baseNode = doc.CreateElement("kernelNode");
            XmlNode xmlNode = doc.CreateElement("resultset");
            baseNode.AppendChild(xmlNode);

            TempFileAllocator allocator = ResourceManager.Instance.TempFileAllocator;

            //if (!node.Results.Match("IGraphResult", "IResultMetadata")) throw new SerializationException("Not implemented");

            try
            {
                foreach (IResult result in node.Results.ToResults)
                {
                    if (result is IGraphResult)
                    {
                        SaveResult(doc, xmlNode, allocator, (IGraphResult) result, pathBase);
                    }
                    else if (result is ISpectrumResult)
                    {
                        SaveResult(doc, xmlNode, (ISpectrumResult) result, pathBase);
                    }
                }
            }
            catch (Exception e)
            {
                throw new SerializationException("Failed to save data", e);
            }
            return baseNode;
        }

        private static void SaveResult(XmlDocument doc, XmlNode xmlNode, TempFileAllocator allocator, IGraphResult result, String pathBase)
        {
            XmlNode myNode = doc.CreateElement("result");
            xmlNode.AppendChild(myNode);

            string file = allocator.CreateFileName("dsif.data");
            result.SaveGraph(ResourceManager.Instance.SimplyfyPath(pathBase + "/" + file));

            XmlAttribute attribute = doc.CreateAttribute("filename");
            attribute.Value = file;

            myNode.Attributes.Append(attribute);

            attribute = doc.CreateAttribute("isStrongComponent");
            attribute.Value = result.isStrongComponent().ToString();

            myNode.Attributes.Append(attribute);

            XmlNode myMetadataNode = doc.CreateElement("metadata");
            myNode.AppendChild(myMetadataNode);

            SaveResultMetadata(result.GetMetadata(), myMetadataNode, doc, pathBase);
        }

        private static XmlAttribute CreateFilledAttribute(XmlDocument doc, string name, string value)
        {
            XmlAttribute attr = doc.CreateAttribute(name);
            attr.Value = value;
            return attr;
        }


        private static void SaveResult(XmlDocument doc, XmlNode xmlNode, ISpectrumResult result, String pathBase)
        {
            XmlNode myNode = doc.CreateElement("spectrum");
            xmlNode.AppendChild(myNode);

            xmlNode.Attributes.Append(CreateFilledAttribute(doc, "MinValue", result.GetLowerBound().ToString()));
            xmlNode.Attributes.Append(CreateFilledAttribute(doc, "MinLength", result.GetLowerLength().ToString()));
            xmlNode.Attributes.Append(CreateFilledAttribute(doc, "MaxValue", result.GetUpperBound().ToString()));
            xmlNode.Attributes.Append(CreateFilledAttribute(doc, "MaxLength", result.GetUpperLength().ToString()));

            XmlNode myMetadataNode = doc.CreateElement("metadata");
            myNode.AppendChild(myMetadataNode);

            SaveResultMetadata(result.GetMetadata(), myMetadataNode, doc, pathBase);
        }

        private static void SaveResultMetadata(IResultMetadata metadata, XmlNode node, XmlDocument doc, string pathBase)
        {
            if (metadata is ISymbolicImageMetadata)
            {
                XmlNode xmlNode = node;
                XmlAttribute attr = doc.CreateAttribute("type");
                attr.Value = "ISymbolicImageMetadata";

                xmlNode.Attributes.Append(attr);
            }
            else if (metadata is IMS2Metadata)
            {
                XmlAttribute attr = doc.CreateAttribute("type");
                attr.Value = "IMS2Metadata";

                node.Attributes.Append(attr);

                IMS2Metadata ms = (IMS2Metadata) metadata;
                KernelNode tmpNode = new KernelNode(ResultSet.FromResultSet(ms.GetSIGraphResult()));

                node.AppendChild(SaveKernelNode(tmpNode, doc, pathBase));
            }
            else if (metadata is ISpectrumMetadata)
            {
                XmlNode xmlNode = node;
                XmlAttribute attr = doc.CreateAttribute("type");
                attr.Value = "ISpectrumMetadata";

                xmlNode.Attributes.Append(attr);
            }
            else
            {
                throw new SerializationException("Unable to save Metadata info");
            }
        }

        #endregion

        #region load

        public static KernelNode LoadKernelNode(XmlNode root, string pathBase)
        {
            XmlNode node = root.SelectSingleNode("kernelNode/resultset");
            ArrayList results = new ArrayList();
            foreach (XmlNode resultNode in node.SelectNodes("result"))
            {
                results.Add(LoadResult(resultNode, pathBase));
            }
            ResultSet rs = ResultSet.FromResult((IResult[]) results.ToArray(typeof (IResult)));

            KernelNode kernelNode = new KernelNode(rs);

            return kernelNode;
        }

        private static IResult LoadResult(XmlNode root, string pathBase)
        {
            if (root.Name == "result")
            {
                String filename = root.Attributes["filename"].Value;
                bool isStrong = Boolean.Parse(root.Attributes["isStrongComponent"].Value);
                IResultMetadata metadata = LoadResultMetadata(root.SelectSingleNode("metadata"), pathBase);

                CGraphResultImplClass impl = new CGraphResultImplClass();
                impl.SetGraphFromFile(ResourceManager.Instance.SimplyfyPath(pathBase + "/" + filename), isStrong);
                impl.SetMetadata(metadata);

                return impl;
            }
            else if (root.Name == "spectrum")
            {
                IWritableSpectrumResult wsr = new CSpectrumResultImplClass();
                wsr.SetMetadata(LoadResultMetadata(root.SelectSingleNode("metadata"), pathBase));
                wsr.SetLowerBound(double.Parse(root.SelectSingleNode("@MinValue").Value));
                wsr.SetUpperBound(double.Parse(root.SelectSingleNode("@MaxValue").Value));

                wsr.SetLowerLength(int.Parse(root.SelectSingleNode("@MinLength").Value));
                wsr.SetUpperLength(int.Parse(root.SelectSingleNode("@MaxLength").Value));

                return (IResult) wsr;
            }
            throw new SerializationException("Unknown Element to read");
        }

        private static IResultMetadata LoadResultMetadata(XmlNode metadata, string pathBase)
        {
            if (metadata.Name != "metadata") throw new SerializationException("metadata tag expetced");

            switch (metadata.Attributes["type"].Value)
            {
                case "ISymbolicImageMetadata":
                    return new CSymbolicImageMetadataClass();
                case "ISpectrumMetadata":
                    return new CSpectrumMetadataClass();
                case "IMS2Metadata":
                    IMS2Metadata meta = new CMS2MetadataClass();
                    KernelNode node = LoadKernelNode(metadata, pathBase);
                    meta.SetSIGraphResult(node.Results.ToResultSet);
                    return meta;
                default:
                    throw new SerializationException("Unsupported metadata type");
            }
        }

        #endregion
    }
}