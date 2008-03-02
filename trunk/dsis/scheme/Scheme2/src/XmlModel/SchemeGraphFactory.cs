namespace DSIS.Scheme2.XmlModel
{
  public class SchemeGraphFactory
  {
    private readonly SchemeNodeFactory myFactory;
    private readonly OutputConnectionPointFactory myOutputConnectionFactory;
    private readonly InputConnectionPointFactory myInputConnectionFactory;

    public SchemeGraphFactory(SchemeNodeFactory factory, OutputConnectionPointFactory outputConnectionFactory, InputConnectionPointFactory inputConnectionFactory)
    {
      myFactory = factory;
      myInputConnectionFactory = inputConnectionFactory;
      myOutputConnectionFactory = outputConnectionFactory;
    }

    public SchemeGraph Build(XsdComputationScheme scheme)
    {
      return new SchemeGraph(scheme, myFactory, myOutputConnectionFactory, myInputConnectionFactory);
    }
  }
}