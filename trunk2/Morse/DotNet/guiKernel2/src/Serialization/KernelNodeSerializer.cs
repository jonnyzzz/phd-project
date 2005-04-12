using System;
using System.Collections;
using System.Xml;
using guiExternalResource.Core;
using guiExternalResource.src.FileResources;
using guiKernel2.Node;
using MorseKernel2;

namespace guiKernel2.Serialization
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
			
			if (!node.Results.Match("IGraphResult", "IResultMetadata")) throw new SerializationException("Not implemented");

			try 
			{
				foreach (IGraphResult result in node.Results.ToResults)
				{
					SaveResult(doc, xmlNode, allocator, result, pathBase);
				}
			} catch (Exception e)
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

			SaveResultMetadata(result.GetMetadata(), myMetadataNode, doc);
		}

		private static void SaveResultMetadata(IResultMetadata metadata, XmlNode node, XmlDocument doc)
		{
			if (metadata is ISymbolicImageMetadata)
			{
				XmlNode xmlNode = node;
				XmlAttribute attr = doc.CreateAttribute("type");
				attr.Value = "ISymbolicImageMetadata";

				xmlNode.Attributes.Append(attr);			
			} else
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
			ResultSet rs = ResultSet.FromResult((IResult[])results.ToArray(typeof(IResult)));

			KernelNode kernelNode = new KernelNode(rs);

			return kernelNode;
		}

		private static IResult LoadResult(XmlNode root, string pathBase)
		{
			if (root.Name != "result") throw new SerializationException("result xml tag expected");

			String filename = root.Attributes["filename"].Value;
			bool isStrong = Boolean.Parse(root.Attributes["isStrongComponent"].Value);
			IResultMetadata metadata = LoadResultMetadata(root.SelectSingleNode("metadata"));

			CGraphResultImplClass impl = new CGraphResultImplClass();
			impl.SetGraphFromFile(ResourceManager.Instance.SimplyfyPath(pathBase + "/" + filename), isStrong);
			impl.SetMetadata(metadata);

			return impl;
		}

		private static IResultMetadata LoadResultMetadata(XmlNode metadata)
		{
			if (metadata.Name != "metadata") throw new SerializationException("metadata tag expetced");
			if (metadata.Attributes["type"].Value != "ISymbolicImageMetadata") throw new SerializationException("type not supported");
			return new CSymbolicImageMetadataClass();
		}	

		#endregion
	}
}
