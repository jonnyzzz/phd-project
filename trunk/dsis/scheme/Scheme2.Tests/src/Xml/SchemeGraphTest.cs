using System.Collections.Generic;
using System.Reflection;
using DSIS.Scheme2.Graph;
using DSIS.Scheme2.Tests.src.Xml;
using DSIS.Scheme2.Tests.testData;
using DSIS.Scheme2.XmlModel;
using DSIS.Spring;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace DSIS.Scheme2.Tests.Xml
{
  [TestFixture]
  public class SchemeGraphTest : SchemeGraphBaseTest
  {    
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

    [Test]
    public void Test_2_objects_1_arc()
    {
      SchemeGraph build = myFactory.Build(TestSchemeGraphLoader.LoadTest_01());
      Assert.That(build, NIs.Not.Null);

      build.Start();

      TestGraphRegistry.AssertData("A:Initized", "B:Recieved");
    }
    
    [Test]
    public void Test_3_objects_2_arc()
    {
      SchemeGraph build = myFactory.Build(TestSchemeGraphLoader.LoadTest_02());
      Assert.That(build, NIs.Not.Null);

      build.Start();

      TestGraphRegistry.AssertData("A:Initized", "B:Recieved", "B:Recieved");
    }

    
    [Test]
    public void Test_FromActionObject()
    {
      SchemeGraph build = myFactory.Build(TestSchemeGraphLoader.LoadTest_03());
      Assert.That(build, NIs.Not.Null);

      build.Start();

      TestGraphRegistry.AssertData("C:Test_B Recieved");
    }

    [Test]
    public void Test_FromActionObjectDowncast()
    {
      SchemeGraph build = myFactory.Build(TestSchemeGraphLoader.LoadTest_04());
      Assert.That(build, NIs.Not.Null);

      build.Start();

      TestGraphRegistry.AssertData("C:Test_B Recieved");
    }
    
    [Test]
    public void Test_FromObject()
    {
      SchemeGraph build = myFactory.Build(TestSchemeGraphLoader.LoadTest_05());
      Assert.That(build, NIs.Not.Null);

      build.Start();

      TestGraphRegistry.AssertData("B:Recieved");
    }
    
    [Test]
    public void Test_FromsubAction()
    {
      SchemeGraph build = myFactory.Build(TestSchemeGraphLoader.LoadTest_06());
      Assert.That(build, NIs.Not.Null);

      build.Start();

      TestGraphRegistry.AssertData("A:Initized", "B:Recieved");
    }
  }
}