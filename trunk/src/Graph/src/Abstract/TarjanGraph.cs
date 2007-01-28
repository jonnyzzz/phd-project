using System;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Graph.Abstract
{
  public class TarjanGraph<TCell> :
    AbstractGraph<TCell, TarjanNode<TCell>>,
    IGraphWithStrongComponent<TCell>
    where TCell : ICellCoordinate<TCell>
  {
    private bool myWasComponents = false;

    public TarjanGraph(ICellCoordinateSystem<TCell> coordinateSystem) : base(coordinateSystem)
    {
    }

    protected override TarjanNode<TCell> CreateNode(TCell coordinate)
    {
      return new TarjanNode<TCell>(coordinate);
    }

    protected override void EdgeAdded(TarjanNode<TCell> from, TarjanNode<TCell> to)
    {
      base.EdgeAdded(from, to);
      if (ReferenceEquals(from, to))
      {
        from.SetFlag(TarjanNodeFlags.IS_LOOP, true);
      }
    }

    public IGraphStrongComponents<TCell> ComputeStrongComponents(IProgressInfo info)
    {
      if (myWasComponents)
      {
        throw new ArgumentException("This method was called allready.");
      }

      myWasComponents = true;

      info.Minimum = 0;
      info.Maximum = EdgesCount;

      TarjanNodeStack<TCell> stack = new TarjanNodeStack<TCell>(TarjanNodeFlags.STACK);
      TarjanNodeStack<TCell> route = new TarjanNodeStack<TCell>(TarjanNodeFlags.ROUTE);

      int state = 2;
      int cnt = 1;

      TarjanNode<TCell> w = null;

      TarjanComponentInfoManager comps = new TarjanComponentInfoManager();

      foreach (TarjanNode<TCell> node in NodesInternal)
      {
        if (node.Data.Label != 0)
          continue;

        TarjanNode<TCell> v = node;
        while (state > 1)
        {
          switch (state)
          {
            case 2:
              stack.Push(v);
              route.Push(v);
              cnt++;
              v.Data.Label = cnt;
              v.Data.Number = cnt;
              state = 3;
              break;
            case 3:
              if (v.Data.MoveNext())
              {
                info.Tick(1.0);
                w = v.Data.Current;

                if (w.Data.Label == 0)
                {
                  v = w;
                  state = 2;
                }
                else
                {
                  state = 4;
                }
              }
              else
              {
                if (v.Data.Label < v.Data.Number)
                {
                  state = 5;
                }
                else
                {
                  state = 6;
                }
              }
              break;

            case 4:
              if (w.Data.Number < v.Data.Number && stack.Contains(w))
              {
                v.Data.Label = Math.Min(v.Data.Label, w.Data.Label);
              }
              state = 3;
              break;
            case 5:
              v = route.Pop();
              w = route.Peek();
              w.Data.Label = Math.Min(w.Data.Label, v.Data.Label);
              v = w;
              state = 3;
              break;
            case 6:
              if (v == stack.Peek())
              {
                stack.Pop();
                if (v.GetFlag(TarjanNodeFlags.IS_LOOP))
                {
                  TarjanComponentInfo ic = comps.NextComponent();
                  ic.SetNodeComponent(v);
                }
              }
              else
              {
                TarjanComponentInfo ic = comps.NextComponent();
                do
                {
                  w = stack.Pop();
                  ic.SetNodeComponent(w);
                } while (!ReferenceEquals(v, w));
              }
              route.Pop();

              if (route.IsEmpty())
              {
                state = 1;
              }
              else
              {
                v = route.Peek();
                state = 3;
              }
              break;
          }
        }
        state = 2;
      }
      return new TarjanStrongComponentImpl<TCell>(this, comps);
    }
  }
}