using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.Nodes
{
  public interface ISchemeNodeFactoryExtension
  {
    INode Create(XsdAction action);
  }
}