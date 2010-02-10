using NUnit.Framework;

namespace DSIS.Graph.Tests
{
  [TestFixture]
  public class GenericsTest
  {
    [Test]
    public void Test_01()
    {
      C c = new C();
      Assert.AreEqual(4, c.DoIt());
    }

    private interface A
    {
      int Foo();
    }

    private class B<Inh> where Inh : B<Inh>, A
    {
      public int DoIt()
      {
        return ((Inh) this).Foo();
      }
    }

    private class   C : B<C>, A
    {
      public int Foo()
      {
        return 4;
      }
    }
  }
}