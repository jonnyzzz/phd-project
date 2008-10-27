using System;
using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application
{
  [ComponentImplementation]
  public class Invocator : IInvocator
  {
    private readonly Form myPumpForm;

    public Invocator()
    {
      myPumpForm = new Form
                     {
                       Width = 1,
                       Height = 1,
                       Top = 10000,
                       Left = 10000,
                       Visible = false,
                       Text = "DSIS Invocator Form",
                       ShowInTaskbar = false
                     };
      myPumpForm.Show();
    }

    public void InvokeOrQueue(string name, Action action)
    {
      myPumpForm.InvokeAction(action);
    }
  }
}