using System.Collections.Generic;
using System.Reflection;

namespace DSIS.Spring
{
  public class SpringIoCSetup : SpringIoC
  {
    internal protected SpringIoCSetup(params Assembly[] extra)
      : base(extra)
    {
    }

    public static void SetUp(params Assembly[] extraRefs)
    {
      SetInsance(new SpringIoC(extraRefs));
    }

    public static void SetUpFiles(params string[] paths)
    {
      var list = new List<Assembly>();
      foreach (string path in paths)
      {
        list.Add(Assembly.LoadFile(path));
      }
      SetUp(list.ToArray());
    }

    public static new void Dispose()
    {
      SpringIoC.Dispose();
    }
  }
}