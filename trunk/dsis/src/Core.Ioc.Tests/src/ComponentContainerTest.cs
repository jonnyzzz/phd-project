using NUnit.Framework;

namespace DSIS.Core.Ioc.Tests
{
  [TestFixture]
  public class ComponentContainerTest : ComponentContainerTestBase
  {
    protected override IComponentContainer CreateContainer<TI, TC, TO>()
    {
      return new ComponentContainer<TI, TC, TO>();
    }
  }
}