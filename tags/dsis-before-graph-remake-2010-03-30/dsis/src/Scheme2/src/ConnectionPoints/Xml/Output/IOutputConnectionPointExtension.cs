using DSIS.Scheme2.Graph;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.ConnectionPoints.Xml.Output
{
  public interface IOutputConnectionPointExtension
  {
    IOutputConnectionPoint Create(ISchemeGraphBuildContext ctx, XsdConnectionsArcFrom arc);
  }
}