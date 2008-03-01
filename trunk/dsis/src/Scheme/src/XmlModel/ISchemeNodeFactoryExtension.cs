namespace DSIS.Scheme.XmlModel
{
  public interface ISchemeNodeFactoryExtension
  {
    INode Create(XsdAction action);
  }
}