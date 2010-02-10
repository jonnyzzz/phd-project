using System.Collections.Generic;

namespace DSIS.Spring.Config
{
  public interface ISpringConfigProvider
  {
    IEnumerable<string> GetSpringConfigPaths();
  }
}