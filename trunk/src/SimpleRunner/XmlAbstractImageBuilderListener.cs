using System;
using System.IO;
using System.Xml;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates;

namespace DSIS.SimpleRunner
{
  public class XmlAbstractImageBuilderListener<T, Q> : IAbstractImageBuilderListener<T, Q>, IComputeEntropyListener,
                                                       IDrawLastComputationResultEvents
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    private readonly XmlDocument myDocument = new XmlDocument();
    private readonly string myFile;
    private readonly string myBasePath;
    private XmlElement myCoputationElement;
    private XmlElement myStep;
    private XmlElement myGraphElement;

    private DateTime myComputationStartedTime;
    private DateTime myComputationStepStartedTime;
    private DateTime myComputationGraphConstructedTime;
    private DateTime myComputationEntropyStartedTime;

    private int stepCount = 0;

    public XmlAbstractImageBuilderListener(string file)
    {
      myFile = file;
      myDocument.AppendChild(myDocument.CreateXmlDeclaration("1.0", "utf-8", null));
      XmlElement root = myDocument.CreateElement("root");
      AppendAttribute(root, "path-base", myBasePath = Path.GetDirectoryName(file));
      myDocument.AppendChild(root);
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

    public void ComputationStarted(T system, AbstractImageBuilderContext<Q> cx)
    {
      myComputationStartedTime = DateTime.Now;
      myCoputationElement = AppendElement(myDocument.DocumentElement, "computation");

      AppendAttribute(myCoputationElement, "system", cx.Info.PresentableName);
      AppendAttribute(myCoputationElement, "method", cx.Builder.PresentableName);
      AppendAttribute(myCoputationElement, "ics", typeof (T).Name);

      stepCount = 0;
      Serialize();
    }

    public void OnStepStarted(T system, AbstractImageBuilderContext<Q> cx)
    {
      stepCount++;
      myComputationStepStartedTime = DateTime.Now;
      myStep = AppendElement(myCoputationElement, "step");
      AppendAttribute(myStep, "step", stepCount);
      Serialize();
    }

    public void GraphConstructed(IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx)
    {
      myComputationGraphConstructedTime = DateTime.Now;
      myGraphElement = AppendElement(myStep, "graph");
      AppendAttribute(myStep, "nodes", graph.NodesCount);
      Serialize();
    }

    public void GraphComponentsConstructed(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                           AbstractImageBuilderContext<Q> cx)
    {
      XmlElement components = AppendElement(myGraphElement, "components");

      AppendAttribute(myGraphElement, "components", comps.ComponentCount);
      AppendAttribute(components, "count", comps.ComponentCount);
      AppendAttribute(components, "time", (DateTime.Now - myComputationGraphConstructedTime).TotalMilliseconds);
      foreach (IStrongComponentInfo info in comps.Components)
      {
        XmlElement element = AppendElement(components, "component");
        AppendAttribute(element, "count", info.NodesCount);
      }

      Serialize();
    }

    public void OnStepFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                               AbstractImageBuilderContext<Q> cx)
    {
      AppendAttribute(myStep, "time", (DateTime.Now - myComputationStepStartedTime).TotalMilliseconds);
      myStep = null;
      myGraphElement = null;

      Serialize();
    }

    public void ComputationFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                    AbstractImageBuilderContext<Q> cx)
    {
      AppendAttribute(myCoputationElement, "time", (DateTime.Now - myComputationStartedTime).TotalMilliseconds);
      AppendAttribute(myCoputationElement, "totalSteps", stepCount);

      Serialize();
    }

    public void OnComputeEntropyStarted()
    {
      myComputationEntropyStartedTime = DateTime.Now;
    }

    public void OnComputeEntropyFinished(double value)
    {
      XmlElement eltropy = AppendElement(myCoputationElement, "entropy");
      AppendAttribute(eltropy, "value", value);
      AppendAttribute(eltropy, "time", (DateTime.Now - myComputationEntropyStartedTime).TotalMilliseconds);

      Serialize();
    }

    public void ImageFile(string file)
    {
      AppendAttribute(AppendElement(myCoputationElement, "draw-image"), "image", file);

      if (file.StartsWith(myBasePath))
      {
        string rel = file.Substring(myBasePath.Length);
        if (rel[0] != '\\')
          rel = "\\" + rel;
        AppendAttribute(AppendElement(myCoputationElement, "draw-image"), "rel-image", rel);
      }
      Serialize();
    }
  }
}