using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DSIS.UI.Controls;
using DSIS.UI.UI;
using log4net;
using System.Linq;

namespace DSIS.UI.Wizard.ListSelector
{
  public abstract class ListSelectorBase<T> : UserControl, IErrorProvider<bool>
    where T : class
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (ListSelectorBase<T>));

    private readonly Dictionary<RadioButton, T> myFactories = new Dictionary<RadioButton, T>();

    public event EventHandler SelectionChanged;

    protected ListSelectorBase(IEnumerable<T> factories, IDockLayout layout)
    {
      RegisterRadio(factories, layout);
      myFactories.Keys.First().Checked = true;      
    }

    protected virtual void FireSelectionChanged()
    {
      if (SelectionChanged != null)
      {
        try
        {
          SelectionChanged(this, EventArgs.Empty);
        } catch(Exception e)
        {
          LOG.Error(e);
        }
      }
    }

    private void RegisterRadio(IEnumerable<T> factories, IDockLayout layout)
    {
      var controls = new List<Control>();
      foreach (var factory in factories)
      {
        var bt = new RadioButton
                   {
                     Text = FactoryName(factory),
                     Dock = DockStyle.Top,
                     Padding = new Padding(5, 0, 0, 0),
                     Enabled = IsFactoryEnabled(factory),                     
                   };        
        bt.CheckedChanged += delegate { if (bt.Checked) FireSelectionChanged(); };
        controls.Add(bt);
        var descr = FactoryDescription(factory);
        if (!string.IsNullOrEmpty(descr))
        {
          var lab = new Label
                      {
                        Text = descr,
                        Padding = new Padding(30, 0, 0, 0),
                        Dock = DockStyle.Top,
                        Enabled = IsFactoryEnabled(factory),
                        AutoSize = true
                      };
          controls.Add(lab);
        }
        myFactories.Add(bt, factory);
      }

      layout.Layout(this, DockStyle.Top, controls);
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