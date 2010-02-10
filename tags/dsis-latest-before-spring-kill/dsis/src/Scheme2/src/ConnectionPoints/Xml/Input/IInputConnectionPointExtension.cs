using DSIS.Scheme2.Graph;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.ConnectionPoints.Xml.Input
{
  public interface IInputConnectionPointExtension
  {
    IInputConnectionPoint Create(ISchemeGraphBuildContext ctx, XsdConnectionsArcTO arc);
  }
}