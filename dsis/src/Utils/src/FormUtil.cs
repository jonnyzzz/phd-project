using System;
using System.Windows.Forms;
using log4net;

namespace DSIS.Utils
{
  public static class FormUtil
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (FormUtil));

    //TODO: Add exception handler
    [Obsolete("Use IInvocator")]
    public static void InvokeAction(this Control control, Action action)
    {
      Action safeAction = delegate
                            {
                              try
                              {
                                action();
                              }
                              catch (Exception e)
                              {
                                LOG.Error(e.Message, e);
                              }
                            };
      control.BeginInvoke(safeAction);
    }
  }
}