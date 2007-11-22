using System.Reflection;
using NUnit.ConsoleRunner;
using NUnit.Framework;

namespace DSIS.Utils.Test
{
  public static class NUnitFixtureHelper
  {
    public static void RunTests(Assembly ass)
    {
      Assert.AreEqual(0, ConsoleUi.Main(new string[] { ass.Location, "/nodots", "/nologo", "/labels" }));
    }
  }
}