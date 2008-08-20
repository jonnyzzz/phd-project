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

    private class NodeAndData<TNode,TCell> : IEquatable<NodeAndData<TNode, TCell>> where TNode : Node<TNode,TCell>
      where TCell : ICellCoordinate
    {
      public readonly TNode Node;
      public readonly TarjanNodeData<TCell, TNode> Data;

      public NodeAndData(TNode node, IGraphDataHoler<TarjanNodeData<TCell, TNode>, TNode> holder)
      {
        Node = node;
        Data = holder.GetData(node);
      }

      public bool Equals(NodeAndData<TNode, TCell> obj)
      {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.Node == Node;
      }

      public override bool Equals(object obj)
      {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != typeof (NodeAndData<TNode, TCell>)) return false;
        return Equals((NodeAndData<TNode, TCell>) obj);
      }

      public override int GetHashCode()
      {
        return (Node != null ? Node.GetHashCode() : 0);
      }

      public static bool operator ==(NodeAndData<TNode, TCell> left, NodeAndData<TNode, TCell> right)
      {
        return Equals(left, right);
      }

      public static bool operator !=(NodeAndData<TNode, TCell> left, NodeAndData<TNode, TCell> right)
      {
        return !Equals(left, right);
      }
    }

    public static IGraphStrongComponents<TCell> ComputeStrongComponents<TCell, TNode>(this IGraph<TCell, TNode> graph, IProgressInfo info)
      where TNode : Node<TNode, TCell>
      where TCell : ICellCoordinate
    {
      info.Minimum = 0;
      info.Maximum = graph.EdgesCount;

      using (IGraphDataHoler<TarjanNodeData<TCell, TNode>, TNode> holder = graph.CreateDataHolder(x => new TarjanNodeData<TCell,TNode>(x)))
      using(var stack = new TarjanNodeStack<TCell, TNode>(graph.CreateNodeFlagsHolder("STACK")))
      using(var route = new TarjanNodeStack<TCell, TNode>(graph.CreateNodeFlagsHolder("ROUTE")))
      {
        long state = 2;
        long cnt = 1;

        NodeAndData<TNode,TCell> w = null;
        var comps = new TarjanComponentInfoManager();
        
        foreach (TNode node in graph.NodesInternal)
        {
          var v = new NodeAndData<TNode, TCell>(node, holder);
          if (v.Data.Label != 0)
            continue;
          
          while (state > 1)
          {
            switch (state)
            {
              case 2:
                stack.Push(v.Node);
                route.Push(v.Node);
                cnt++;
                v.Data.Label = cnt;
                v.Data.Number = cnt;
                state = 3;
                break;
              case 3:
                if (v.Data.MoveNext())
                {
                  info.Tick(1.0);
                  w = new NodeAndData<TNode, TCell>(v.Data.Current, holder);
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
                  state = v.Data.Label < v.Data.Number ? 5 : 6;
                }
                break;

              case 4:
                if (w.Data.Number < v.Data.Number && stack.Contains(w.Node))
                {
                  v.Data.Label = Math.Min(v.Data.Label, w.Data.Label);
                }
                state = 3;
                break;
              case 5:
                v = new NodeAndData<TNode, TCell>(route.Pop(), holder);
                w = new NodeAndData<TNode, TCell>(route.Peek(), holder);
                w.Data.Label = Math.Min(w.Data.Label, v.Data.Label);
                v = w;
                state = 3;
                break;
              case 6:
                if (v.Node == stack.Peek())
                {
                  stack.Pop();
                  if (graph.IsSelfLoop(v.Node))
                    comps.NextComponent().SetNodeComponent<TCell, TNode>(v.Node);
                }
                else
                {
                  var ic = comps.NextComponent();
                  TNode ww;
                  do
                  {                      
                    ww = stack.Pop();
                    ic.SetNodeComponent<TCell, TNode>(ww);
                  } while (ww != v.Node);
                  w = new NodeAndData<TNode, TCell>(ww, holder);
                }
                route.Pop();

                if (route.IsEmpty())
                {
                  state = 1;
                }
                else
                {
                  v = new NodeAndData<TNode, TCell>(route.Peek(), holder);
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