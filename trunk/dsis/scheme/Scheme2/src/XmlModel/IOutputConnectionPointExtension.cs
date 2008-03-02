namespace DSIS.Scheme2.XmlModel
{
  public interface IOutputConnectionPointExtension
  {
    IOutputConnectionPoint Create(ISchemeGraphBuildContext ctx, XsdConnectionsArcFrom arc);
  }
}