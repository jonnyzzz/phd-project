using System;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Graph.Abstract
{
  public class TarjanGraph<TCell> :
    AbstractGraph<TarjanGraph<TCell>, TCell, TarjanNode<TCell>>, IGraphWithStrongComponent<TCell>,
    IGraphExtension<TarjanNode<TCell>, TCell>
    where TCell : ICellCoordinate<TCell>
  {
    private bool myWasComponents = false;

    public TarjanGraph(ICellCoordinateSystem<TCell> coordinateSystem) : base(coordinateSystem)
    {
    }

    #region IGraphWithStrongComponent<TCell> Members

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
      TarjanNodeData<TCell> wData = null;

      TarjanComponentInfoManager comps = new TarjanComponentInfoManager();

      foreach (TarjanNode<TCell> node in NodesInternal)
      {
        if (node.Data.Label != 0)
          continue;

        TarjanNode<TCell> v = node;
        TarjanNodeData<TCell> vData = v.Data;
        while (state > 1)
        {
          switch (state)
          {
            case 2:
              stack.Push(v);
              route.Push(v);
              cnt++;
              vData.Label = cnt;
              vData.Number = cnt;
              state = 3;
              break;
            case 3:
              if (vData.MoveNext())
              {
                info.Tick(1.0);
                w = vData.Current;
                wData = w.Data;

                if (wData.Label == 0)
                {
                  v = w;
                  vData = wData;
                  state = 2;
                }
                else
                {
                  state = 4;
                }
              }
              else
              {
                if (vData.Label < vData.Number)
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
              if (wData.Number < vData.Number && stack.Contains(w))
              {
                vData.Label = Math.Min(vData.Label, wData.Label);
              }
              state = 3;
              break;
            case 5:
              v = route.Pop();
              vData = v.Data;

              w = route.Peek();
              wData = w.Data;
              wData.Label = Math.Min(wData.Label, vData.Label);
              v = w;
              vData = wData;
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
                  wData = w.Data;
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
                vData = v.Data;
                state = 3;
              }
              break;
          }
        }
        state = 2;
      }
      return new TarjanStrongComponentImpl<TCell>(this, comps);
    }

    #endregion

    #region IGraphExtension<TarjanNode<TCell>,TCell> Members

    TarjanNode<TCell> IGraphExtension<TarjanNode<TCell>, TCell>.CreateNode(TCell coordinate)
    {
      return new TarjanNode<TCell>(coordinate);
    }

    void IGraphExtension<TarjanNode<TCell>, TCell>.EdgeAdded(TarjanNode<TCell> from, TarjanNode<TCell> to)
    {
      if (ReferenceEquals(from, to))
      {
        from.SetFlag(TarjanNodeFlags.IS_LOOP, true);
      }
    }

    void IGraphExtension<TarjanNode<TCell>, TCell>.NodeAdded(TarjanNode<TCell> node)
    {
    }

    #endregion
  }
}