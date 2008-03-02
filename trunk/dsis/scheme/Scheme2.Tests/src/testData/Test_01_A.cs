using DSIS.Scheme2.Attributed;
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
}