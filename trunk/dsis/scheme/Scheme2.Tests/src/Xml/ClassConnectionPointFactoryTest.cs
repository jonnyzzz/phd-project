using DSIS.Scheme2.Attributed;
using DSIS.Scheme2.Impl.ConnectionPoints;
using DSIS.Scheme2.XmlModel;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace DSIS.Scheme2.Tests.Xml
{
  [TestFixture]
  public class ClassConnectionPointFactoryTest
  {
    private ClassConnectionPointFactory myFactory;

    [SetUp]
    public void SetUp()
    {
      myFactory = new ClassConnectionPointFactory();
    }

    [Test]
    public void Test_Input()
    {
      Class_InputProperty input = new Class_InputProperty();
      IInputConnectionPoint fin = myFactory.Input("III", input, input.GetType().GetProperty("Field"));

      Assert.That(fin.Name, Is.EqualTo("III"));      
      fin.With(new AssertInput<string>("QQQQQQQ"));

      Assert.That(input.Field, Is.EqualTo("QQQQQQQ"));
    }

    [Test]
    public void Test_Output()
    {
      Class_OutputEvent evt = new Class_OutputEvent();
      IOutputConnectionPoint fou = myFactory.Output("III", evt, evt.GetType().GetEvent("OnDataXXX"));

      Assert.That(fou.Name, Is.EqualTo(fou.Name));
      fou.With(new AssertOutput<string>("QQQQQ"));
      evt.Fire("QQQQQ");            
    }

    [Test]
    public void Test_BindOnInput()
    {
      Class_OutputEvent evt = new Class_OutputEvent();
      IOutputConnectionPoint fou = myFactory.Output("III", evt, evt.GetType().GetEvent("OnDataXXX"));

      Class_InputProperty input = new Class_InputProperty();
      IInputConnectionPoint fin = myFactory.Input("III", input, input.GetType().GetProperty("Field"));

      fin.Bind(fou);

      evt.Fire("ZZZ");
      Assert.That(input.Field, Is.EqualTo("ZZZ"));            
    }
    
    [Test]
    public void Test_BindOnOutput()
    {
      Class_OutputEvent evt = new Class_OutputEvent();
      IOutputConnectionPoint fou = myFactory.Output("III", evt, evt.GetType().GetEvent("OnDataXXX"));

      Class_InputProperty input = new Class_InputProperty();
      IInputConnectionPoint fin = myFactory.Input("III", input, input.GetType().GetProperty("Field"));

      fou.Bind(fin);

      evt.Fire("ZZZ");
      Assert.That(input.Field, Is.EqualTo("ZZZ"));            
    }

    public class AssertOutput<T> : IOutputConnectionPointWith
    {
      private readonly T myData;

      public AssertOutput(T data)
      {
        myData = data;
      }

      public void Register<Q>(IOutputConnectionPoint<Q> point)
      {
        Assert.That(typeof(Q), Is.EqualTo(typeof(T)));

        point.OnDataReady += delegate(Q data) { Assert.That(data, Is.EqualTo(myData)); };
      }
    }

    public class AssertInput<T> : IInputConnectionPointWith
    {
      private readonly T myReady;

      public AssertInput(T ready)
      {
        myReady = ready;
      }

      public void Register<Q>(IInputConnectionPoint<Q> point)
      {
        Assert.That(typeof(Q), Is.EqualTo(typeof(T)));        

        point.DataReady((Q)(object)myReady);
      }      
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
      public event DataReady<string> OnDataXXX;

      public void Fire(string Q)
      {
        OnDataXXX(Q);
      }
    }
  }
}