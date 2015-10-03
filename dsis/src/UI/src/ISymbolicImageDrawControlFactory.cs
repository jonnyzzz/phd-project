using System.Collections.Generic;
using DSIS.Graph;

namespace DSIS.UI.UI
{
  public interface ISymbolicImageDrawControlFactory
  {
    ISymbolicImageDrawControl Create(IGraphStrongComponents components, IEnumerable<IStrongComponentInfo> info);
  }
}