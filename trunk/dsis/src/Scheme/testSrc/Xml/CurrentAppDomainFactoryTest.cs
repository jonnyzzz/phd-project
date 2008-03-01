using System.Reflection;
using DSIS.Scheme.XmlModel;
using NUnit.Framework;
using NUnit.Mocks;

namespace DSIS.Scheme.testSrc.Xml
{
  public class MockConnectionPointFactory : IConnectionPointFactory
  {
    public IConnectionPoint CreateConnectionPoint(object instance, PropertyInfo property)
    {
      return new MockConnectionPoint(string.Format("{0}-{1}", instance.GetType().FullName, property.Name));
    }

    public IConnectionPoint CreateConnectionPoint(object instance, FieldInfo field)
    {
      return new MockConnectionPoint(string.Format("{0}-{1}", instance.GetType().FullName, field.Name));
    }
  }

  [TestFixture]
  public class CurrentAppDomainFactoryTest
  {
    private MockConnectionPointFactory myConnectionPoint = new MockConnectionPointFactory();
    private CurrentAppDomainFactory myFactory = new CurrentAppDomainFactory();
    

    [SetUp]
    public virtual void SetUp()
    {
      DynamicMock mock = new DynamicMock(typeof(IConnectionPointFactory));
      mock.MockInstance
      

      Mock mock = new Mock();
      mock.
      
    }

  }
}