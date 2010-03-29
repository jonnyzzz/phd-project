using NUnit.Framework;
using Rhino.Mocks;

namespace DSIS.Scheme2.Tests.Xml
{
  public abstract class MockTestBase
  {
    protected MockRepository myMocks;

    [SetUp]
    public virtual void SetUp()
    {
      myMocks = new MockRepository();
    }
  }
}