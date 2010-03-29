using System.Collections.Generic;
using System.Reflection;
using DSIS.Spring.Config;
using log4net;

namespace DSIS.Spring.Assemblies
{
  [UsedBySpring]
  public class AttributedSpringContextLoader : IAssemblyLoadListener
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (AttributedSpringContextLoader));

    private readonly List<string> myConfigXmls = new List<string>();

    public void AssemblyLoaded(Assembly assembly)
    {
      if (assembly == GetType().Assembly)
        return;

      string assemblyPath = assembly.GetName().Name;
      foreach (SpringConfigXmlAttribute attr in assembly.GetCustomAttributes(typeof(SpringConfigXmlAttribute), true))
      {
        string portion = string.Format("assembly://{0}/{1}/{2}", assemblyPath, attr.Namespace, attr.Location);
        LOG.InfoFormat("Config: {0}", portion);
        myConfigXmls.Add(portion);
      }
    }

    public IEnumerable<string> Resources
    {
      get { return myConfigXmls; }
    }
  }
}