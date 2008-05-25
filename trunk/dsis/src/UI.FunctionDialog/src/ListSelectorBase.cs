using System.Collections.Generic;
using System.Windows.Forms;
using DSIS.Utils;

namespace DSIS.UI.FunctionDialog
{
  public abstract class ListSelectorBase<T> : UserControl
    where T : class
  {
    private readonly Dictionary<RadioButton, T> myFactories = new Dictionary<RadioButton, T>();

    protected ListSelectorBase(IEnumerable<T> factories)
    {
      RegisterRadio(this, factories);
      myFactories.Keys.GetFirst().Checked = true;
    }

    private void RegisterRadio(Control control, IEnumerable<T> factories)
    {
      foreach (var factory in factories)
      {
        var bt = new RadioButton
                   {
                     Text = FactoryName(factory),
                     Dock = DockStyle.Top,
                     Padding = new Padding(5, 0, 0, 0),
                     AutoSize = true
                   };
        control.Controls.Add(bt);
        myFactories.Add(bt, factory);
      }
    }

    protected abstract string FactoryName(T factory);

    public T SelectedFactory
    {
      get
      {
        foreach (var pair in myFactories)
        {
          if (pair.Key.Checked)
          {
            return pair.Value;
          }
        }
        return null;
      }
    }
  }
}