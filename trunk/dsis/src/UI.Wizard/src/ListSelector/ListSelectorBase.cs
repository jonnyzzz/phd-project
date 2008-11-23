using System.Collections.Generic;
using System.Windows.Forms;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Wizard.ListSelector
{
  public abstract class ListSelectorBase<T> : UserControl, IErrorProvider<bool>
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
      var controls = new List<Control>();
      foreach (var factory in factories)
      {
        var bt = new RadioButton
                   {
                     Text = FactoryName(factory),
                     Dock = DockStyle.Top,
                     Padding = new Padding(5, 0, 0, 0),
                     AutoSize = true,
                     Enabled = IsFactoryEnabled(factory),
                     
                   };
        controls.Add(bt);
        var descr = FactoryDescription(factory);
        if (!string.IsNullOrEmpty(descr))
        {
          var lab = new Label
                      {
                        Text = descr,
                        Padding = new Padding(15, 0, 0, 0),
                        AutoSize = true,
                        Dock = DockStyle.Top,
                        Enabled = IsFactoryEnabled(factory)
                      };
          controls.Add(lab);
        }
        myFactories.Add(bt, factory);
      }

      controls.Reverse();
      foreach (var cnt in controls)
      {
        control.Controls.Add(cnt);
      }
    }

    protected virtual bool IsFactoryEnabled(T factory)
    {
      return true;
    }

    protected virtual string FactoryDescription(T factory)
    {
      return null;
    }

    protected abstract string FactoryName(T factory);

    bool IErrorProvider<bool>.Validate()
    {
      return SelectedFactory != null;
    }

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
      set
      {
        foreach (var pair in myFactories)
        {
          if (pair.Value == value)
          {
            pair.Key.Checked = true;
            return;
          }
        }
      }
    }
  }
}