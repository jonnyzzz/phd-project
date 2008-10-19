using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DSIS.Utils;

namespace DSIS.UI.Controls
{
  public class SmartLayoutManager
  {
    private readonly LayoutManager myManager = new LayoutManager();

    public Control LayoutControls(IEnumerable<IControlWithLayout2> _controls)
    {
      var controls = new List<IControlWithLayout2>(_controls);

      var myLayouts = new MultiDictionary<Layout, IControlWithLayout2>(EqualityComparerFactory<Layout>.GetComparer());

      foreach (var control in controls)
      {
        myLayouts.AddValue(control.Float[0], control);
      }

      var simpleLayouts = new List<IControlWithLayout>();
      foreach (var pair in myLayouts)
      {
        string ancor = pair.Value.GetFirst().Ancor;
        if (CheckSubLayout(pair.Value))
        {
          var recur = new List<IControlWithLayout2>();
          foreach (var child in pair.Value)
          {
            recur.Add(new Proxy(child));
          }
          simpleLayouts.Add(new SimpleLayout(pair.Key, ancor, LayoutControls(recur)));
        }
        else if (CheckSingleLayout(pair.Value))
        {
          simpleLayouts.Add(new SimpleLayout(pair.Key, ancor, pair.Value.GetFirst().Control));
        }
        else if (CheckSingleLayoutMulti(pair.Value))
        {
//          var data = new List<IControlWithLayout>();
          foreach (var child in pair.Value)
          {
            simpleLayouts.Add(new ControlWithLayout(child.Control, child.Ancor, pair.Key));
          }
//          simpleLayouts.Add(new SimpleLayout(pair.Key, ancor, myManager.LayoutControls(data)));
        }         
        else
        {
          throw new LayoutException("Failed to layout: " + Dump(pair.Value));
        }
      }

      return myManager.LayoutControls(simpleLayouts);
    }

    private static bool CheckSubLayout(IEnumerable<IControlWithLayout2> controls)
    {
      foreach (var c in controls)
      {
        if (c.Float.Length > 1)
          return true;
      }
      return false;
    }

    private static bool CheckSingleLayoutMulti(IEnumerable<IControlWithLayout2> controls)
    {
      foreach (var c in controls)
      {
        if (c.Float.Length != 1)
          return false;
      }
      return true;
    }

    private static bool CheckSingleLayout(ICollection<IControlWithLayout2> controls)
    {
      return controls.Count == 1 && controls.GetFirst().Float.Length == 1;
    }

    private static string Dump(IEnumerable<IControlWithLayout2> controls)
    {
      var sb = new StringBuilder();
      foreach (var c in controls)
      {
        sb.AppendFormat("Control {0} {1}", c.GetType(), c.Float.JoinString("->"));
      }
      return sb.ToString();
    }

    private class SimpleLayout : IControlWithLayout
    {
      public SimpleLayout(Layout @float, string ancor, Control control)
      {
        Float = @float;
        Ancor = ancor;
        Control = control;
      }

      public Layout Float { get; private set;}
      public string Ancor { get; private set;}

      public Control Control { get; private set;}
    }


    private class Proxy : IControlWithLayout2
    {
      private readonly IControlWithLayout2 myHost;

      public Proxy(IControlWithLayout2 host)
      {
        myHost = host;
      }

      public string Ancor
      {
        get { return myHost.Ancor; }
      }

      public Layout[] Float
      {
        get
        {
          var list = new List<Layout>(myHost.Float);
          list.RemoveAt(0);
          return list.ToArray();
        }
      }

      public Control Control
      {
        get { return myHost.Control; }
      }
    }
  }
}