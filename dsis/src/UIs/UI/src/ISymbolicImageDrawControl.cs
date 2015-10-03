using System.Collections.Generic;
using System.Windows.Forms;
using DSIS.Graph;

namespace DSIS.UI.UI
{
  public interface ISymbolicImageDrawControl
  {
    IEnumerable<IStrongComponentInfo> Components { get; set; }
    Control Control { get; }
  }
}