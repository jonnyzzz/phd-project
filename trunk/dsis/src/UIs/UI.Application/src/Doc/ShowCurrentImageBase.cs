using System.Windows.Forms;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.UI.Application.Progress;
using DSIS.UI.UI;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.Application.Doc
{
  public abstract class ShowCurrentImageBase<T> : IDocumentCenterControl
    where T : IIocDrawHelper
  {
    private readonly ActionExecutorProgressAdapter myHelper;

    protected ShowCurrentImageBase(
      IApplicationDocument doc,
      T action,
      IActionExecution exec,
      ITypeInstantiator typeInstantiator,
      IInvocator invocator)
    {
      var helper = new ImageDrawWithIoCHelper(exec, invocator, action, doc);
      myHelper = new ActionExecutorProgressAdapter(helper, typeInstantiator);
      helper.Execution = myHelper.Execution;
    }

    Control IControlWithTitle.Control
    {
      get { return myHelper; }
    }

    string IControlWithTitle.Title
    {
      get { return ControlTitle; }
    }

    public abstract string SortOrder { get; }
    public abstract string ControlTitle { get; }
  }
}