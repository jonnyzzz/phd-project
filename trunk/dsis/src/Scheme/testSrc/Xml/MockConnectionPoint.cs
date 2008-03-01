using DSIS.Scheme.XmlModel;

namespace DSIS.Scheme.testSrc.Xml
{
  public class MockConnectionPoint : IConnectionPoint
  {
    private readonly string myName;

    public MockConnectionPoint(string name)
    {
      myName = name;
    }

    public string Name
    {
      get { return myName; }
    }

    public virtual void With(IConnectionPointWith with)
    {
      throw new System.NotImplementedException("This is light mock");
    }
  }
}