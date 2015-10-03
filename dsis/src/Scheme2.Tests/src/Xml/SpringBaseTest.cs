using System.Collections.Generic;
using System.Reflection;
using DSIS.Scheme2.XmlModel;
using DSIS.Spring;
using DSIS.Spring.Attributes;
using DSIS.Spring.Service;
using NUnit.Framework;

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

  public abstract class SpringBaseTest
  {
    protected abstract IEnumerable<Assembly> SpringAssemblies {get; }
    public static IServiceProvider myServiceProvider;

    [SetUp]
    public virtual void SetUp()
    {
      myServiceProvider = null;
      SpringIoCSetup.SetUp(new List<Assembly>(SpringAssemblies).ToArray());     
    }

    [TearDown]
    public void TearDown()
    {
      SpringIoCSetup.Dispose();
    }    


    protected XsdComputationScheme Load(string file)
    {
      return TestSchemeGraphLoader.Load(GetType().Assembly, file);
    }
  }
}