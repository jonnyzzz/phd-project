using System.Reflection;
using NUnit.Framework;

namespace DSIS.Utils.Test
{
  public static class NUnitFixtureHelper
  {
    public static void RunTests(Assembly ass)
    {
      Assert.Fail("Not implemented");
//      Assert.AreEqual(0, ConsoleUi.Main(new string[] { ass.Location, "/nodots", "/nologo", "/labels" }));
    }
  }
}