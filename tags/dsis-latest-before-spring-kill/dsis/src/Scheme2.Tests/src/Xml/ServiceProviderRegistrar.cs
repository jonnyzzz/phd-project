using DSIS.Spring.Attributes;
using DSIS.Spring.Service;

namespace DSIS.Scheme2.Tests.Xml
{
  [SpringBean]
  public class ServiceProviderRegistrar
  {
    public ServiceProviderRegistrar(IServiceProvider prov)
    {
      SpringBaseTest.myServiceProvider = prov;
    }
  }
}