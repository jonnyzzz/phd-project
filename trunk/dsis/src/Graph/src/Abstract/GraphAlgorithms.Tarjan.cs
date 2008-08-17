using System;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Graph.Abstract
{
  public static partial class GraphAlgorithms
  {
    public static IGraphStrongComponents<TCell> ComputeStrongComponents<TCell>(this IGraph<TCell> graph, IProgressInfo info) 
      where TCell : ICellCoordinate
    {
      var wg = new WithGraph<TCell> {Info = info};
      graph.DoGeneric(wg);
      return wg.Componentes;      
    }

    private class WithGraph<TCell> : IGraphWith<TCell> 
      where TCell : ICellCoordinate
    {
      public IGraphStrongComponents<TCell> Componentes { get; private set; }
      public IProgressInfo Info { get; set; }

      public void With<TNode>(IGraph<TCell, TNode> graph) where TNode : Node<TNode, TCell>
      {
        Componentes = graph.ComputeStrongComponents(Info);
      }
    }

    public static IGraphStrongComponents<TCell> ComputeStrongComponents<TCell, TNode>(this IGraph<TCell, TNode> graph, IProgressInfo info)
      where TNode : Node<TNode, TCell>
      where TCell : ICellCoordinate
    {
      info.Minimum = 0;
      info.Maximum = graph.EdgesCount;

      using (var holder = graph.CreateDataHolder(x => new TarjanNodeData<TCell,TNode>(x)))
      using(var stack = new TarjanNodeStack<TCell, TNode>(graph.CreateNodeFlagsHolder("STACK")))
      using(var route = new TarjanNodeStack<TCell, TNode>(graph.CreateNodeFlagsHolder("ROUTE")))
      {
        long state = 2;
        long cnt = 1;

        TNode w = null;
        TarjanNodeData<TCell, TNode> wData = null;

        var comps = new TarjanComponentInfoManager();
        
        foreach (TNode node in graph.NodesInternal)
        {
          var nodeData = holder.GetData(node);
          if (nodeData.Label != 0)
            continue;

          TNode v = node;
          TarjanNodeData<TCell,TNode> vData = nodeData;
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
                  wData = holder.GetData(w);

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
                vData = holder.GetData(v);

                w = route.Peek();
                wData = holder.GetData(w);
                wData.Label = Math.Min(wData.Label, vData.Label);
                v = w;
                vData = wData;
                state = 3;
                break;
              case 6:
                if (v == stack.Peek())
                {
                  stack.Pop();
                  if (graph.IsSelfLoop(v))
                    comps.NextComponent().SetNodeComponent<TCell, TNode>(v);
                }
                else
                {
                  var ic = comps.NextComponent();
                  do
                  {
                    w = stack.Pop();
                    wData = holder.GetData(w);
                    ic.SetNodeComponent<TCell, TNode>(w);
                  } while (w != v);
                }
                route.Pop();

                if (route.IsEmpty())
                {
                  state = 1;
                }
                else
                {
                  v = route.Peek();
                  vData = holder.GetData(v);
                  state = 3;
                }
                break;
            }
          }
          state = 2;
        }

        return new TarjanStrongComponentImpl<TCell, TNode>(graph, comps);
      }
    }
  }
}