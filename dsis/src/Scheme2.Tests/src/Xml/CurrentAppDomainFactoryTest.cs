using System;
using DSIS.Scheme2.Attributed;
using DSIS.Scheme2.ConnectionPoints;
using DSIS.Scheme2.ConnectionPoints.Object;
using DSIS.Scheme2.Nodes;
using DSIS.Scheme2.Tests.src.Xml;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace DSIS.Scheme2.Tests.Xml
{
  [TestFixture]
  public class CurrentAppDomainFactoryTest : XsdUtil
  {
    private IInputObjectConnectionPointFactoryExtension myInputObjectConnectionPoint;
    private IOutputObjectConnectionPointFactoryExtension myOutputObjectConnectionPoint;
    private ObjectNodeFactory myFactory;

    [SetUp]
    public override void SetUp()
    {
      base.SetUp();
      myInputObjectConnectionPoint = myMocks.CreateMock<IInputObjectConnectionPointFactoryExtension>();
      myOutputObjectConnectionPoint = myMocks.CreateMock<IOutputObjectConnectionPointFactoryExtension>();
      var ifactory = new InputObjectConnectionPointFactory();
      var ofactory = new OutputObjectConnectionPointFactory();
      throw new NotImplementedException("Code was commented out!");
//      ifactory.Register(myInputObjectConnectionPoint);
//      ofactory.Register(myOutputObjectConnectionPoint);
      myFactory = new ObjectNodeFactory(myMocks.DynamicMock<SchemeNodeFactory>(), ifactory, ofactory);
    }

    [Test]
    public void Test_Null()
    {
      myMocks.ReplayAll();
      Assert.That(myFactory.Create(null), NIs.Null);
      myMocks.VerifyAll();
    }

    [Test]
    public void Test_InputProperty()
    {
      Expect.Call(myInputObjectConnectionPoint.Input(null, null, null)).IgnoreArguments().Constraints(
        Is.Equal("QQQ"),
        Is.TypeOf(typeof (Class_InputProperty)),
        Is.NotNull()
        ).Return(myMocks.CreateMock<IInputConnectionPoint>());

      myMocks.ReplayAll();
      Assert.That(myFactory.Create(Create(typeof (Class_InputProperty))), NIs.Not.Null);
      myMocks.VerifyAll();
    }

    [Test]
    public void Test_InputMethod()
    {
      Expect.Call(myInputObjectConnectionPoint.Input(null, null, null)).IgnoreArguments().Constraints(
        Is.Equal("QQQ"),
        Is.TypeOf(typeof (Class_InputMethod)),
        Is.NotNull()
        ).Return(myMocks.CreateMock<IInputConnectionPoint>());

      myMocks.ReplayAll();
      Assert.That(myFactory.Create(Create(typeof (Class_InputMethod))), NIs.Not.Null);
      myMocks.VerifyAll();
    }

    [Test]
    public void Test_OutputEvent()
    {
      Expect.Call(myOutputObjectConnectionPoint.Output(null, null, null)).IgnoreArguments().Constraints(
        Is.Equal("QQQ"),
        Is.TypeOf(typeof (Class_OutputEvent)),
        Is.NotNull()
        ).Return(myMocks.CreateMock<IOutputConnectionPoint>());

      myMocks.ReplayAll();
      Assert.That(myFactory.Create(Create(typeof (Class_OutputEvent))), NIs.Not.Null);
      myMocks.VerifyAll();
    }

    public class Class_InputProperty
    {
      public string myField;

      [Input("QQQ")]
      public string Field
      {
        get { return myField; }
        set { myField = value; }
      }
    }

    public class Class_InputMethod
    {
      public string myField;

      [Input("QQQ")]
      public void SetField(string fff)
      {
      }
    }

    public class Class_OutputEvent
    {
      [Output("QQQ")]
      public event DataReady<int> OnDataXXX;
    }
  }
}