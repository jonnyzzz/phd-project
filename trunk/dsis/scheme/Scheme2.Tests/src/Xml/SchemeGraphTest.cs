using DSIS.Scheme2.XmlModel;
using DSIS.Spring;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace DSIS.Scheme2.Tests.Xml
{
  [TestFixture]
  public class SchemeGraphTest
  {
    private SchemeGraphFactory myFactory;
    
    [SetUp]
    public void SetUp()
    {
      Log4NetConfigurator.SetUp();
      SpringIoCSetup.SetUp(typeof(SchemeGraph).Assembly);

      myFactory = SpringIoC.Instance.GetComponent<SchemeGraphFactory>("schemeGraphFactory");
    }

    [TearDown]
    public void TearDown()
    {
      SpringIoCSetup.Dispose();
      Log4NetConfigurator.Dispose();
    }
    
    [Test]
    public void Test_CreateFactory()
    {
      Assert.That(myFactory, Is.Not.Null);
    }
    
    [Test]
    public void Test_CreateObject_OnEmpty()
    {
      Assert.That(myFactory.Build(new XsdComputationScheme()), Is.Not.Null);
    }

  }
}