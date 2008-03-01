using System;
using DSIS.Scheme.Attributed;
using DSIS.Scheme2.XmlModel;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace DSIS.Scheme2.Tests.src.Xml
{
  [TestFixture]
  public class CurrentAppDomainFactoryTest
  {
    private readonly MockRepository myMocks = new MockRepository();

    private IConnectionPointFactory myConnectionPoint;
    private CurrentAppDomainFactory myFactory;
    

    [SetUp]
    public virtual void SetUp()
    {
      myConnectionPoint = myMocks.CreateMock<IConnectionPointFactory>();      
      myFactory = new CurrentAppDomainFactory(myConnectionPoint);      
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
      Expect.Call(myConnectionPoint.ForProperty(null, null)).IgnoreArguments().Constraints(
        Is.TypeOf(typeof(Class_InputProperty)), Is.NotNull()
        ).Return(new MockConnectionPoint("ZZZ"));
      
      myMocks.ReplayAll();
      Assert.That(myFactory.Create(Create(typeof(Class_InputProperty))), NIs.Not.Null);
      myMocks.VerifyAll();      
    }
    
    [Test]
    public void Test_InputField()
    {
      Expect.Call(myConnectionPoint.ForField(null, null)).IgnoreArguments().Constraints(
        Is.TypeOf(typeof(Class_InputField)), Is.NotNull()
        ).Return(new MockConnectionPoint("ZZZ"));
      
      myMocks.ReplayAll();
      Assert.That(myFactory.Create(Create(typeof(Class_InputField))), NIs.Not.Null);
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
    
    public class Class_InputField
    {
      [Input("QQQ")]
      public string myField;
      
      public string Field
      {
        get { return myField; }
        set { myField = value; }
      }
    }
    
    private static XsdAction Create(Type t)
    {
      XsdUserAction action = new XsdUserAction();
      action.Assembly = t.Assembly.FullName;
      action.Class = t.FullName;
      return action;
    }
  }
}