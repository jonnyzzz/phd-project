using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Persistance.Tests
{
  [TestFixture]
  public class DefaultSystemSpacePersistanceTest : PersistanceTestBase
  {
    [Test]
    public void Test_01()
    {
      DoSpaceTest(new DefaultSystemSpace(1, 1.0.Fill(1), 2.0.Fill(1), 5L.Fill(1)));
    }

    [Test]
    public void Test_02()
    {
      DoSpaceTest(new DefaultSystemSpace(2, new[] {1.0, 1.1}, new[]{2.0, 2.1}, new[]{5L,6L}));
    }
    
    [Test]
    public void Test_03()
    {
      DoSpaceTest(new DefaultSystemSpace(3, new[] {1.0, 1.1, 1.2}, new[]{2.0, 2.1, 2.2}, new[]{5L,6L, 7L}));
    }

    private static void DoSpaceTest(ISystemSpace space)
    {
      var ps = new DefaultSystemSpacePersistance();
      DoTest(
        space,
        (w,x)=>ps.Save(x,w),
        ps.Load,
        (a,b)=>Assert.That(a, Is.EqualTo(b))
        );
    }
  }
}
