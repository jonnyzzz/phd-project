using System.Collections.Generic;
using System.Reflection;
using DSIS.Spring.Assemblies;
using DSIS.Spring.Service;
using Spring.Context.Support;

namespace DSIS.Spring
{
  public static class SpringIoCSetup
  {
    private static XmlApplicationContext myContext;
    private static IServiceProvider myServiceProvider;

    private static void InitSpring(params Assembly[] extra)
    {
      string rootResource = "assembly://" + typeof (SpringIoCSetup).Assembly.GetName().Name + "/" +
                            typeof (NamespaceHolder).Namespace + "/resources.spring.xml";
      myContext = new XmlApplicationContext(rootResource);
      myContext.Refresh();

      myServiceProvider = (IServiceProvider) myContext.GetObject(myContext.GetObjectNamesForType(typeof (IServiceProvider))[0]);
    
      myServiceProvider.GetService<IAssemblyIncludeManager>().RegisterAssemblies(extra);

      myServiceProvider.GetService<SpringIoC>().Start();
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
      if (myContext != null)
      {
        myContext.Dispose();
        myContext = null;
      }
    }

    public static int AsMain<Q>(string[] args, params Assembly[] extra)
      where Q : IApplicationEntryPoint
    {
      SetUp(new List<Assembly>(extra) {typeof (Q).Assembly}.ToArray());
      
      try
      {
        return myServiceProvider.GetService<SpringIoC>().AsMain<Q>(args, extra);
      }
      finally
      {
        Dispose();
      }
    }
  }
}