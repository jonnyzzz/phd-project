using System.Collections.Generic;

namespace DSIS.Graph.Abstract
{
  public interface IStrongComponentInfoConnectivity
  {
    IEnumerable<IStrongComponentInfo> Out { get; }
    IEnumerable<IStrongComponentInfo> In { get; }
  }
}