namespace DSIS.Scheme2.XmlModel
{
  public class SchemeGraphFactory
  {
    private readonly SchemeNodeFactory myFactory;
    private readonly OutputConnectionPointFactory myOutputConnectionFactory;

    public SchemeGraphFactory(SchemeNodeFactory factory, OutputConnectionPointFactory outputConnectionFactory)
    {
      myFactory = factory;
      myOutputConnectionFactory = outputConnectionFactory;
    }

    public SchemeGraph Build(XsdComputationScheme scheme)
    {
      return new SchemeGraph(scheme, myFactory, myOutputConnectionFactory);
    }
  }
}