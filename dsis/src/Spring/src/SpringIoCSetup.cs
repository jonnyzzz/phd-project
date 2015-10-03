using System;
using System.Collections.Generic;
using System.Reflection;

namespace DSIS.Spring
{
  public static class SpringIoCSetup
  {
    private static void InitSpring(params Assembly[] extra)
    {
      throw new NotImplementedException();
    }

    public static void SetUp(params Assembly[] extraRefs)
    {
      Log4NetConfigurator.SetUp();
      InitSpring(extraRefs);
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

    public static void Dispose()
    {
    }

    public static int AsMain<Q>(string[] args, params Assembly[] extra)
      where Q : IApplicationEntryPoint
    {
      SetUp(new List<Assembly>(extra) {typeof (Q).Assembly}.ToArray());

      throw new NotImplementedException();
    }
  }
}