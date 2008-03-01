namespace DSIS.Scheme2.XmlModel
{
  public class SchemeGraphFactory
  {
    private readonly SchemeNodeFactory myFactory;

    public SchemeGraphFactory(SchemeNodeFactory factory)
    {
      myFactory = factory;
    }
    
    public SchemeGraph Build(XsdComputationScheme scheme)
    {
      return new SchemeGraph(scheme, myFactory);
    }
  }
}