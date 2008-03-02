using System.Xml;
using DSIS.Scheme2.Attributed;
using DSIS.Scheme2.Impl.ObjectParsers;
using DSIS.Scheme2.Tests.src.Xml;
using DSIS.Scheme2.XmlModel;
using NUnit.Framework;

namespace DSIS.Scheme2.Tests.testData
{
  [UsedByScheme]
  public class Test_01_A : IInitializeAware
  {
    [Output("Point")]
    public event DataReady<string> OnPointReady;


    public void Initialized()
    {
      TestGraphRegistry.Log("A:Initized");
      OnPointReady("AAA");      
    }
  }

  [UsedByScheme]
  public class Test_01_B
  {
    [Input("Point")]
    public string OnPointReady
    {
      set
      {
        Assert.That(value, NIs.EqualTo("AAA"));
        TestGraphRegistry.Log("B:Recieved");
      }
    }
  }

  [UsedByScheme]
  public class Test_01_B_B : Test_01_B
  {    
  }
  
  [UsedByScheme]
  public class Test_01_C
  {
    [Input("Z")]
    public Test_01_B Test
    {
      set
      {
        Assert.That(value, NIs.Not.Null);
        TestGraphRegistry.Log("C:Test_B Recieved");
      }
    }

    [Input("Point")]
    public string OnPointReady
    {
      set
      {
        Assert.That(value, NIs.EqualTo("AAA"));
        TestGraphRegistry.Log("B:Recieved");
      }
    }
  }

  [UsedByScheme]
  public class StringObjectParser : IObjectParser
  {
    public object Parse(XmlElement element)
    {
      return element.InnerText;
    }
  }
}