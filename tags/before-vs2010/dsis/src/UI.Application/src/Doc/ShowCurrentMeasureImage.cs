using System.Drawing;
using DSIS.Core.Ioc;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.UI.Application.Progress;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc
{
  [DocumentComponent]
  public class ShowCurrentMeasureImage : ShowCurrentImageBase<IoCDrawEntropyMeasure>
  {
    public ShowCurrentMeasureImage(IApplicationDocument doc, IoCDrawEntropyMeasure action, IActionExecution exec, ITypeInstantiator typeInstantiator, IInvocator invocator) 
      : base(doc, action, exec, typeInstantiator, invocator)
    {
    }

    public override string SortOrder
    {
      get { return "000h"; }
    }

    public override string ControlTitle
    {
      get { return "Invariant Measure"; }
    }
  }
}