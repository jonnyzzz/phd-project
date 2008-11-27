using DSIS.Core.Ioc;
using DSIS.Scheme2.ConnectionPoints.Xml.Input;
using DSIS.Scheme2.ConnectionPoints.Xml.Output;
using DSIS.Scheme2.Nodes;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.Graph
{
  [UsedBySpring]
  public class SchemeGraphFactory
  {
    private readonly SchemeNodeFactory myFactory;
    private readonly OutputConnectionPointFactory myOutputConnectionFactory;
    private readonly InputConnectionPointFactory myInputConnectionFactory;

    public SchemeGraphFactory(SchemeNodeFactory factory, OutputConnectionPointFactory outputConnectionFactory,
                              InputConnectionPointFactory inputConnectionFactory)
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