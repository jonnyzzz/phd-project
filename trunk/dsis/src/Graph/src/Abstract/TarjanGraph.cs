using System;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  public class TarjanGraph<TCell> :
    AbstractGraph<TarjanGraph<TCell>, TCell, TarjanNode<TCell>>, IGraphWithStrongComponent<TCell>,
    IGraphExtension<TarjanNode<TCell>, TCell>
    where TCell : ICellCoordinate
  {
    private bool myWasComponents = false;
    private readonly NodeFlag STACK;
    private readonly NodeFlag ROUTE;

    public TarjanGraph(ICellCoordinateSystem<TCell> coordinateSystem) : base(coordinateSystem)
    {
      STACK = NodeFlags.NextFlag("STACK");
      ROUTE = NodeFlags.NextFlag("ROUTE");
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

      var stack = new TarjanNodeStack<TCell>(STACK);
      var route = new TarjanNodeStack<TCell>(ROUTE);

      long state = 2;
      long cnt = 1;

      TarjanNode<TCell> w = null;
      TarjanNodeData<TCell> wData = null;

      var comps = new TarjanComponentInfoManager();

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
                if (v.IsSelfLoop)
                {
                  comps.NextComponent().SetNodeComponent(v);
                }
              }
              else
              {
                var ic = comps.NextComponent();
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

      //clean up all useless data.
      foreach (var node in NodesInternal)
      {
        node.ClearNodeData();
      }

      GCHelper.Collect();

      return new TarjanStrongComponentImpl<TCell>(this, comps);
    }

    TarjanNode<TCell> IGraphNodeFactory<TarjanNode<TCell>, TCell>.CreateNode(TCell coordinate)
    {
      return new TarjanNode<TCell>(coordinate);
    }

    void IGraphExtension<TarjanNode<TCell>, TCell>.EdgeAdded(TarjanNode<TCell> from, TarjanNode<TCell> to)
    {
      if (ReferenceEquals(from, to))
      {
        ((Node) from).SetFlag(NodeFlags.IS_LOOP, true);
      }
    }

    public bool HasArcToItself(TarjanNode<TCell> node)
    {
      return node.IsSelfLoop;
    }

    void IGraphExtension<TarjanNode<TCell>, TCell>.NodeAdded(TarjanNode<TCell> node)
    {
    }

    protected override TarjanGraph<TCell> CreateGraph(ICellCoordinateSystem<TCell> system)
    {
      return new TarjanGraph<TCell>(system);
    }
  }
}