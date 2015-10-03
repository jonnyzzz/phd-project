using System.Xml;
using Eugene.Petrenko.Gui2.MethodComparer.Actions;
using EugenePetrenko.Gui2.Kernel2.Document;
using EugenePetrenko.Gui2.Kernell2.Document;

namespace Eugene.Petrenko.Gui2.MethodComparer.Parameters
{
  public class MethodParametersSerializer
  {
    public static IMethodParameters Load(XmlNode root)
    {
      XmlNode node = root.SelectSingleNode("methodComparation");

      int dimension = Int(node, "Dimension/text()");
      int[] subdivision = IntArray(node, "Subdevision/text()");
      int[] numberOfPoints = IntArray(node, "NumberOfPoints/text()");
      double[] offset = DoubleArray(node, "OverlapingOffset/text()");
      int numberOfSteps = Int(node, "NumberOfSteps/text()");
      int[] translatePrecision = IntArray(node, "AdaptivePrecisionFactor/text()");
      bool boxUseDerivate = Bool(node, "LinearUseDerivate/text()");
      Function function = FunctionSerializer.LoadFunction(node);
      int adaptiveLimit = Int(node, "AdaptiveUpperLimit/text()");
      string caption = node.SelectSingleNode("caption/text()").Value;
      bool needResolveEdges = Bool(node, "NeedResolveEdges/text()");
      bool unsim = SafeBool(node, "unsimmetric/text()", false);
      
      return new XMLMethodParameters(dimension,
                                     subdivision,
                                     numberOfPoints,
                                     offset,
                                     numberOfSteps,
                                     translatePrecision,
                                     boxUseDerivate,
                                     function,
                                     adaptiveLimit,
                                     caption,
                                     needResolveEdges,
                                     unsim
        );
    }

    private static bool SafeBool(XmlNode node, string xpath, bool def)
    {
      XmlNode anode = node.SelectSingleNode(xpath);
      return anode != null ? bool.Parse(anode.Value) : def;
    }
    
    private static bool Bool(XmlNode node, string xpath)
    {
      return bool.Parse(node.SelectSingleNode(xpath).Value);
    }

    private static int Int(XmlNode node, string xpath)
    {
      return int.Parse(node.SelectSingleNode(xpath).Value);
    }

    private static int[] IntArray(XmlNode node, string xpath)
    {
      return ReadArrayInt(node.SelectSingleNode(xpath).Value);
    }

    private static double[] DoubleArray(XmlNode node, string xpath)
    {
      return ReadArrayDouble(node.SelectSingleNode(xpath).Value);
    }


    private static int[] ReadArrayInt(string text)
    {
      string[] ts = text.Split(',');
      int[] d = new int[ts.Length];
      for (int i = 0; i < ts.Length; i++)
      {
        d[i] = int.Parse(ts[i]);
      }
      return d;
    }

    private static double[] ReadArrayDouble(string text)
    {
      string[] ts = text.Split(',');
      double[] d = new double[ts.Length];
      for (int i = 0; i < ts.Length; i++)
      {
        d[i] = double.Parse(ts[i].Replace('.', ','));
      }
      return d;
    }
  }
}