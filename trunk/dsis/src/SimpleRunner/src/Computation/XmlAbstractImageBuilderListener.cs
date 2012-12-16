using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.IntegerCoordinates;
using DSIS.SimpleRunner.Builder;
using DSIS.SimpleRunner.Entropy;
using DSIS.SimpleRunner.Entropy.Draw;

namespace DSIS.SimpleRunner.Computation
{
  public class XmlAbstractImageBuilderListener<T, Q> : AbstractImageBuilderListener<T, Q>, IComputeEntropyListener<Q>,
                                                       IDrawLastComputationResultEvents, IDrawEntropyImageListener
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    private readonly XmlDocument myDocument = new XmlDocument();
    private readonly string myFile;
    private readonly string myBasePath;
    private readonly XmlElement myRootElement;
    private XmlElement myCoputationElement;
    private XmlElement myStep;
    private XmlElement myGraphElement;
    private XmlElement myEntropy;

    private DateTime myComputationStartedTime;
    private DateTime myComputationStepStartedTime;
    private DateTime myComputationGraphConstructedTime;
    private DateTime myComputationEntropyStartedTime;

    private int stepCount = 0;
    private int myEdgesCount;

    public XmlAbstractImageBuilderListener(string file)
    {
      myFile = file;
      myBasePath = Path.GetDirectoryName(file);
      if (!File.Exists(file))
      {
        myDocument.AppendChild(myDocument.CreateXmlDeclaration("1.0", "utf-8", null));
        XmlElement root = myDocument.CreateElement("root");        
        myDocument.AppendChild(root);
      } else
      {
        myDocument.Load(file);
      }
      myRootElement = AppendElement(myDocument.DocumentElement, "computation-root");
      AppendAttribute(myRootElement, "path-base", myBasePath);
    }

    private static void AppendAttribute(XmlNode element, string key, string template, params object[] args)
    {
      AppendAttribute(element, key, (object) string.Format(template, args));
    }

    private static void AppendAttribute(XmlNode element, string key, object value)
    {
      XmlAttribute attr = element.OwnerDocument.CreateAttribute(key);
      attr.Value = value.ToString();
      element.Attributes.Append(attr);
    }

    private static XmlElement AppendElement(XmlNode element, string name)
    {
      return (XmlElement) element.AppendChild(element.OwnerDocument.CreateElement(name));
    }

    private void Serialize()
    {
      myDocument.Save(myFile);
    }

    public override void ComputationStarted(T system, AbstractImageBuilderContext<Q> cx, bool isUnsimmetric)
    {
      myComputationStartedTime = DateTime.Now;
      myCoputationElement = AppendElement(myRootElement, "computation");

      AppendAttribute(myCoputationElement, "system", cx.Info.PresentableName);
      AppendAttribute(myCoputationElement, "method", cx.Builder.PresentableName);
      AppendAttribute(myCoputationElement, "unsimmetric", isUnsimmetric);
      AppendAttribute(myCoputationElement, "ics", typeof (T).Name);

      stepCount = 0;
      Serialize();
    }

    private static string Subdivide(IEnumerable<long> ls)
    {
      StringBuilder sb = new StringBuilder();
      foreach (long l in ls)
      {
        sb.AppendFormat("{0}, ", l);
      }
      return sb.ToString();
    }

    public override void OnStepStarted(T system, AbstractImageBuilderContext<Q> cx, long[] subdivide)
    {
      stepCount++;
      myComputationStepStartedTime = DateTime.Now;
      myStep = AppendElement(myCoputationElement, "step");
      AppendAttribute(myStep, "step", stepCount);
      AppendAttribute(myStep, "subdivide", Subdivide(subdivide));
      Serialize();
    }

    public override void GraphConstructed(IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx)
    {
      myComputationGraphConstructedTime = DateTime.Now;
      myGraphElement = AppendElement(myStep, "graph");
      AppendAttribute(myStep, "nodes", graph.NodesCount);
      Serialize();
    }

    public override void GraphComponentsConstructed(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                           AbstractImageBuilderContext<Q> cx)
    {
      XmlElement components = AppendElement(myGraphElement, "components");

      AppendAttribute(myGraphElement, "components", comps.ComponentCount);
      AppendAttribute(components, "count", comps.ComponentCount);
      AppendAttribute(components, "total-edges", graph.EdgesCount);
      AppendAttribute(components, "total-nodes", graph.NodesCount);
      AppendAttribute(components, "time", (DateTime.Now - myComputationGraphConstructedTime).TotalMilliseconds);
      foreach (IStrongComponentInfo info in comps.Components)
      {
        XmlElement element = AppendElement(components, "component");
        AppendAttribute(element, "count", info.NodesCount);
      }
      myEdgesCount = graph.EdgesCount;

      Serialize();
    }

    public override void OnStepFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                               AbstractImageBuilderContext<Q> cx)
    {
      AppendAttribute(myStep, "time", (DateTime.Now - myComputationStepStartedTime).TotalMilliseconds);      
      Serialize();
    }
   
    public override void ComputationFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                    AbstractImageBuilderContext<Q> cx)
    {
      
      AppendAttribute(myCoputationElement, "time", (DateTime.Now - myComputationStartedTime).TotalMilliseconds);
      AppendAttribute(myCoputationElement, "totalSteps", stepCount);

      Serialize();
    }

    public void OnComputeEntropyStarted()
    {
      myUsedEdgesCount = null;
      myComputationEntropyStartedTime = DateTime.Now;
      myEntropy = AppendElement(myStep, "entropy");
    }


    private int? myUsedEdgesCount;

    public void OnComputeEntropyFinished(string key, double[] value)
    {      
      AppendAttribute(myEntropy, "graphEdges", myEdgesCount.ToString());
      AppendAttribute(myEntropy, "usedEdges", myUsedEdgesCount.ToString());
      AppendAttribute(myEntropy, "entropy-type", key);
      AppendAttribute(myEntropy, "value", value[0]);
      AppendAttribute(myEntropy, "time", (DateTime.Now - myComputationEntropyStartedTime).TotalMilliseconds);
      for (int i = 0; i < value.Length; i++)
      {
        double d = value[i];
        XmlElement el = AppendElement(myEntropy, "entropy-step");
        AppendAttribute(el, "value", d.ToString("F6"));
        AppendAttribute(el, "project", i);
      }

      Serialize();
    }

    public void OnComputeEntropyStep<P>(double value, IDictionary<Q, double> measure, IDictionary<P, double> egdes, ICellCoordinateSystem<Q> system) where P : PairBase<Q>
    {      
      if (myUsedEdgesCount == null)
      {
        myUsedEdgesCount = egdes.Count;
      }
    }

    public void EntropyImageAdded(string imageName, string file)
    {
      XmlElement img = Image(file, myCoputationElement, "entropy");
      AppendAttribute(img, "entropy-type", imageName);
    }

    public void ImageFile(string file)
    {
      Image(file, myCoputationElement, "phase");
    }

    private XmlElement Image(string file, XmlNode parent, string type)
    {
      XmlElement imageElement = AppendElement(parent, "draw-image");
      AppendAttribute(imageElement, "image", file);
      AppendAttribute(imageElement, "type", type);

      if (file.StartsWith(myBasePath))
      {
        string rel = file.Substring(myBasePath.Length);
        if (rel[0] != '\\')
          rel = "\\" + rel;
        AppendAttribute(imageElement, "rel-image", rel.TrimStart(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar));
      }
      Serialize();

      return imageElement;
    }
  }
}