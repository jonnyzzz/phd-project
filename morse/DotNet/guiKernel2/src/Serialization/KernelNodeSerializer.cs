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

    private const string GRAPH_RESULT_TYPE = "GraphResult";
    private const string SPECTRUM_TYPE = "Spectrum";

    private static void SaveResult(XmlDocument doc, XmlNode xmlNode, TempFileAllocator allocator, IGraphResult result,
                                   String pathBase)
    {
      XmlNode myNode = doc.CreateElement("result");
      xmlNode.AppendChild(myNode);

      XmlAttribute type = doc.CreateAttribute("type");
      type.Value = GRAPH_RESULT_TYPE;
      myNode.Attributes.Append(type);

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

    private static XmlAttribute CreateFilledAttribute(XmlDocument doc, string name, object value)
    {
      XmlAttribute attr = doc.CreateAttribute(name);
      attr.Value = value.ToString();
      return attr;
    }


    private static void SaveResult(XmlDocument doc, XmlNode xmlNode, ISpectrumResult result, String pathBase)
    {
      XmlNode node = doc.CreateElement("result");
      xmlNode.AppendChild(node);

      XmlAttribute type = doc.CreateAttribute("type");
      type.Value = SPECTRUM_TYPE;
      node.Attributes.Append(type);


      node.Attributes.Append(CreateFilledAttribute(doc, "MinValue", result.GetLowerBound()));
      node.Attributes.Append(CreateFilledAttribute(doc, "MinLength", result.GetLowerLength()));
      node.Attributes.Append(CreateFilledAttribute(doc, "MaxValue", result.GetUpperBound()));
      node.Attributes.Append(CreateFilledAttribute(doc, "MaxLength", result.GetUpperLength()));

      XmlNode metadataNode = doc.CreateElement("metadata");
      SaveResultMetadata(result.GetMetadata(), metadataNode, doc, pathBase);
      node.AppendChild(metadataNode);
    }

    private const string MS2_METADATA = "IMS2Metadata";
    private const string MS2_METADATA_SIGRAPH = "HasSIGraph";
    private const string SI_METADATA = "ISymbolicImageMetadata";
    private const string SPECTRUM_METADATA = "ISpectrumMetadata";
    private const string MSANGLE_METADATA = "IMSAngleMetadata";

    private static void SaveResultMetadata(IResultMetadata metadata, XmlNode node, XmlDocument doc, string pathBase)
    {
      XmlAttribute attr = doc.CreateAttribute("type");
      node.Attributes.Append(attr);

      if (metadata is ISymbolicImageMetadata)
        attr.Value = SI_METADATA;
      else if (metadata is IMS2Metadata)
      {
        attr.Value = MS2_METADATA;
        XmlAttribute attr2 = doc.CreateAttribute(MS2_METADATA_SIGRAPH);

        IMS2Metadata ms = (IMS2Metadata) metadata;
        if (ms.HasSIGraphResult())
        {
          KernelNode tmpNode = new KernelNode(ResultSet.FromResultSet(ms.GetSIGraphResult()));
          node.AppendChild(SaveKernelNode(tmpNode, doc, pathBase));
          attr2.Value = "true";
        }
        else
        {
          attr2.Value = "false";
        }
        node.Attributes.Append(attr2);
      }
      else if (metadata is ISpectrumMetadata)
        attr.Value = SPECTRUM_METADATA;
      else if (metadata is IMSAngleMetadata)
        attr.Value = MSANGLE_METADATA;
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
      XmlAttribute type = root.Attributes["type"];

      if (type == null || type.Value == GRAPH_RESULT_TYPE)
      {
        String filename = root.Attributes["filename"].Value;
        bool isStrong = Boolean.Parse(root.Attributes["isStrongComponent"].Value);
        IResultMetadata metadata = LoadResultMetadata(root.SelectSingleNode("metadata"), pathBase);

        CGraphResultImplClass impl = new CGraphResultImplClass();
        impl.SetGraphFromFile(ResourceManager.Instance.SimplyfyPath(pathBase + "/" + filename), isStrong);
        impl.SetMetadata(metadata);

        return impl;
      }
      else if (type.Value == SPECTRUM_TYPE)
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
        case SI_METADATA:
          return new CSymbolicImageMetadataClass();
        case SPECTRUM_METADATA:
          return new CSpectrumMetadataClass();
        case MS2_METADATA:
          IMS2Metadata meta = new CMS2MetadataClass();
          if (metadata.Attributes[MS2_METADATA_SIGRAPH] != null
              && metadata.Attributes[MS2_METADATA_SIGRAPH].Value == "true")
          {
            KernelNode node = LoadKernelNode(metadata, pathBase);
            meta.SetSIGraphResult(node.Results.ToResultSet);
          }
          return meta;
        case MSANGLE_METADATA:
          return new CMSAngleMetadataClass();
        default:
          throw new SerializationException("Unsupported metadata type");
      }
    }

    #endregion
  }
}