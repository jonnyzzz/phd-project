using System.Collections.Generic;
using System.Linq;

namespace DSIS.UI.Controls
{
  public class CellData<Q> where Q : IControlWithLayout
  {
    private static readonly List<Layout> Y = new List<Layout> { Layout.TOP, Layout.CENTER, Layout.BOTTON };
    private static readonly List<Layout> X = new List<Layout> { Layout.LEFT, Layout.CENTER, Layout.RIGHT };

    private readonly Dictionary<Layout, IControlWithLayout> myControls;

    public CellData(IEnumerable<Q> controls)
    {
      myControls = new Dictionary<Layout, IControlWithLayout>();
      foreach (var q in controls)
      {
        myControls.Add(q.Float, q);
      }
    }

    public int Cols
    {
      get { return Count(X); }
    }

    public int Rows
    {
      get { return Count(Y); }
    }

    public int Col(Layout l)
    {
      return Count2(X, l);
    }

    public int Row(Layout l)
    {
      return Count2(Y, l);
    }

    private int Count2(IEnumerable<Layout> all, Layout v)
    {
      int cnt = 0;

      foreach (var layout in all)
      {
        cnt += myControls.ContainsKey(layout) ? 1 : 0;
        if (layout == v)
          break;
      }
      return cnt - 1;
    }

    private int Count(IEnumerable<Layout> ls)
    {
      return myControls.Keys.Count(new HashSet<Layout>(ls).Contains);
    }
  }
}