using System.Xml;
using DSIS.Spring.Service;
using DSIS.UI.Application.Actions;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace DSIS.UI.Application.Test
{
  [TestFixture]
  public class XmlActionPresentationManagerTest
  {
    private MockRepository myMocks;
    private IActionPresentationManager mock;

    private ActionDescriptorParserManager myParser;

    [SetUp]
    public void SetUp()
    {
      myMocks = new MockRepository();
      mock = myMocks.CreateMock<IActionPresentationManager>();
      myMocks.Record();

      var prov = myMocks.CreateMock<IServiceProvider>();
      Expect.Call(prov.GetServices<IActionDescriptorParser>()).IgnoreArguments().Return(
        new IActionDescriptorParser[]
          {
            new ActionDescriptorParser()
          }).Repeat.AtLeastOnce();

      Expect.Call(mock.RootAction).Return(null).Repeat.Any();

      myParser = new ActionDescriptorParserManager(prov);
    }

    [TearDown]
    public void TearDown()
    {
      myMocks.VerifyAll();
    }

    private static XmlElement Element(string xml)
    {
      var doc = new XmlDocument();
      doc.LoadXml(xml);
      return doc.DocumentElement;
    }

    private void Constraint(string action, string parent)
    {
      Expect.Call(() => mock.RegisterAction(null)).
        Constraints(
        Property.Value("ActionId", action) && Property.Value("ParentId", parent)
        );
    }

    [Test]
    public void Test_01()
    {
      Constraint("A", "P");

      myMocks.ReplayAll();

      var man = new XmlActionPreesentationManager(myParser, mock);
      man.LoadDeclarationsFromXml(Element("<Action Id='A' Title='T' Parent='P' Description='D'/>"), null);
    }

    [Test]
    public void Test_02()
    {
      Constraint("A", "P");
      Constraint("Z", "A");
      Constraint("X", "A");

      myMocks.ReplayAll();

      var man = new XmlActionPreesentationManager(myParser, mock);
      man.LoadDeclarationsFromXml(
        Element(
          @"<Action Id='A' Title='T' Parent='P' Description='D'>
                                               <Action Id='X'/><Action Id='Z'/></Action>
                                            "),
        null);
    }
  }
}