using System.Collections.Generic;
using System.Reflection;
using DSIS.Spring.Assemblies;
using DSIS.Spring.Util;
using log4net;

namespace DSIS.Spring.Config
{
  [UsedBySpring]
  public class SpringConfigXmlProvider : Registrar<ISpringConfigProvider, SpringConfigRegistry>, ISpringConfigProvider, IAssemblyLoadListener
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (SpringConfigXmlProvider));

    private readonly List<string> myResources = new List<string>();
    public SpringConfigXmlProvider(SpringConfigRegistry factory) : base(factory)
    {
    }

    public IEnumerable<string> GetSpringConfigPaths()
    {
      return myResources;
    }

    public void AssemblyLoaded(Assembly assembly)
    {
      foreach (SpringConfigXmlAttribute attr in assembly.GetCustomAttributes(typeof(SpringConfigXmlAttribute), true))
      {
        myResources.Add("assembly://" + assembly.GetName().Name + "/" +
                        attr.Namespace + "/" + attr.Location);
      }
    }
  }
}