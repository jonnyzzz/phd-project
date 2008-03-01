using DSIS.Scheme2.Attributed;
using DSIS.Scheme2.Tests.src.Xml;
using DSIS.Scheme2.XmlModel;
using DSIS.Utils;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace DSIS.Scheme2.Tests.Xml
{
  [TestFixture]
  public class CurrentAppDomainFactoryTest : XsdUtil
  {
    private readonly MockRepository myMocks = new MockRepository();

    private IConnectionPointFactoryExtension myConnectionPoint;
    private CurrentAppDomainFactory myFactory;
    

    [SetUp]
    public virtual void SetUp()
    {
      myConnectionPoint = myMocks.CreateMock<IConnectionPointFactoryExtension>();      
      myFactory = new CurrentAppDomainFactory(new ConnectionPointFactory(CollectionUtil.AsList(myConnectionPoint)));      
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
      Expect.Call(myConnectionPoint.Input(null, null, null)).IgnoreArguments().Constraints(
        Is.Equal("QQQ"), 
        Is.TypeOf(typeof(Class_InputProperty)), 
        Is.NotNull()
        ).Return(myMocks.CreateMock<IInputConnectionPoint>());
      
      myMocks.ReplayAll();
      Assert.That(myFactory.Create(Create(typeof(Class_InputProperty))), NIs.Not.Null);
      myMocks.VerifyAll();      
    }
    
    [Test]
    public void Test_OutputEvent()
    {
      Expect.Call(myConnectionPoint.Output(null, null, null)).IgnoreArguments().Constraints(
        Is.Equal("QQQ"),
        Is.TypeOf(typeof(Class_OutputEvent)), 
        Is.NotNull()
        ).Return(myMocks.CreateMock<IOutputConnectionPoint>());
      
      myMocks.ReplayAll();
      Assert.That(myFactory.Create(Create(typeof(Class_OutputEvent))), NIs.Not.Null);
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
    
    public class Class_OutputEvent
    {      
      [Output("QQQ")]
      public event DataReady<int> OnDataXXX;      
    }   
  }
}