using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EugenePetrenko.Core.FormGenerator.ErrorProvider
{
  public delegate T Merge<T>(T t1, T t2);

  public class ErrorProviderHelper<T> : IDisposable, IErrorProvider<T>
  {
    private readonly List<IErrorProvider<T>> myErrorProviders = new List<IErrorProvider<T>>();
    private readonly List<Control> myRegistered = new List<Control>();
    private readonly Merge<T> myMerger;
    private readonly T myInitial;

    public ErrorProviderHelper(Control control, T initial, Merge<T> merger)
    {
      myInitial = initial;
      myMerger = merger;
      ControlAdded(control);
      control.Disposed += delegate { Dispose(); };
    }

    private void Register(Control control)
    {      
      control.ControlAdded += ControlAdded;
      control.ControlRemoved += ControlRemoved;
      myRegistered.Add(control);      
    }
    
    private void Unregister(Control control)
    {      
      control.ControlAdded -= ControlAdded;
      control.ControlRemoved -= ControlRemoved;
      myRegistered.Remove(control);
    }

    private void ControlRemoved(object sender, ControlEventArgs e)
    {
      var control = e.Control;
      ControlRemoved(control);
    }

    private void ControlRemoved(Control control)
    {
      var prov = control as IErrorProvider<T>;
      
      if (prov != null)
        myErrorProviders.Remove(prov);

      if (myRegistered.Contains(control))
        Unregister(control);

      foreach (var child in control.ControlsEnumerable())
      {
        ControlRemoved(child);
      }
    }

    private void ControlAdded(object sender, ControlEventArgs e)
    {
      Control control = e.Control;

      ControlAdded(control);
    }

    private void ControlAdded(Control control)
    {
      if (!ErrorProviderAttribute.HasAttribute(control, typeof(T)))
        Register(control);

      var prov = control as IErrorProvider<T>;
      if (prov != null)
        myErrorProviders.Add(prov);

      foreach (var child in control.ControlsEnumerable())
      {
        ControlAdded(child);
      }
    }

    public void Dispose()
    {
      foreach (var control in new List<Control>(myRegistered))
      {
        ControlRemoved(control);
      }
      myErrorProviders.Clear();
    }

    public T ValidateData()
    {
      T value = myInitial;
      foreach (var provider in myErrorProviders)
      {
        value = myMerger(value, provider.ValidateData());
      }
      return value;
    }
  }
}