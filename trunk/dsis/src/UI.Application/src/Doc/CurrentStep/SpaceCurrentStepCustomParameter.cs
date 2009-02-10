using System;
using System.Collections.Generic;
using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.Scheme.Ctx;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Doc.CurrentStep
{
  [DocumentComponent]
  public class SpaceCurrentStepCustomParameter : ICurrentStepCustomParameter
  {
    [Autowire]
    private IApplicationDocument Document { get; set; }
    
    public string Name
    {
      get { return "Space"; }
    }

    public int Order
    {
      get { return (int) StepOrders.Space; }
    }

    public bool IsAvailable(Context ctx)
    {
      return true;
    }

    public string GetValue(Context ctx)
    {
      return PresentSystemSpace(Document.Space).JoinString(Environment.NewLine);
    }

    private static IEnumerable<string> PresentSystemSpace(ISystemSpace space)
    {
      for (int i = 0; i < space.Dimension; i++)
      {
        yield return string.Format("[{0}; {1}]", space.AreaLeftPoint[i], space.AreaRightPoint[i]);
      }
    }

  }
}