using System.Collections.Generic;
using DSIS.Spring.Util;

namespace DSIS.Spring.Config
{
  [UsedBySpring]
  public class SpringConfigRegistry : AbstractRegistry<ISpringConfigProvider>, ISpringConfigProvider
  {
    public IEnumerable<string> GetSpringConfigPaths()
    {
      return ForCollect(x => x.GetSpringConfigPaths());
    }
  }
}