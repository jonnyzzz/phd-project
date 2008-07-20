using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Exec;
using DSIS.Utils;

namespace DSIS.Scheme.Xml
{
  public class XsdGraphBuilder
  {
    public Dictionary<string, IAction> BuildActions(Graphs graph)
    {
      using (var fnd = new TypeFinder())
      {
        fnd.LoadAssembliesFromXml(graph.IncludeAssemblies);
        return CreateNodes<IAction, Graph>(graph.Graph, (g, c) => BuildAction(fnd, g, c), x => x.Id);
      }
    }
    
    private static NodeFactory<IAction> BuildAction(TypeFinder fnd, Graph graph, Converter<string, IAction> loadGraph)
    {
      fnd.LoadAssembliesFromXml(graph.IncludeAssemblies);
      var nodes = CreateNodes<IAction,Node>(graph.Nodes.Node, (x,c) => CreateNode(x, fnd, c, loadGraph), x=>x.Id);
      return new NodeFactory<IAction>(
        graph.GraphRequirements(),
        graph.Id,
        () => new AgregateAction(
                x =>
                  {
                    nodes["#input"] = x.Start;
                    nodes["#output"] = x.End;
                    LinkNodes(x, nodes, graph.Links);
                  }));
    }

    private static void LinkNodes(IActionGraphBuilder ag, IDictionary<string, IAction> nodes, GraphLinks links)
    {
      foreach (var link in links.Link)
      {
        var x = link.Nodes.GetFirst();
        foreach (var y in link.Nodes.Skip(1))
        {
          ag.AddEdge(nodes[x.noderef], nodes[y.noderef]);
          x = y;
        }
      }
    }

    private delegate NodeFactory<T> DCreateNode<T,Node>(Node node, Converter<string, T> load) where T : class;

    private static Dictionary<string, T> CreateNodes<T, Node>(IEnumerable<Node> nodes, DCreateNode<T, Node> factory, Converter<Node, string> id)
      where T : class
    {
      var data = new Dictionary<string, T>();
     
      var map = new Dictionary<string, NodeFactory<T>>();
      foreach (var node in nodes)
      {
        var n = factory(node, name => data[name]);

        if (n.NodePrerequisites.Count() == 0)
        {
          data[n.Id] = n.Create();
        } else
        {
          map.Add(id(node), n);
        }
      }

      for (bool working = true; working && map.Count > 0; )
      {
        working = false;
        foreach (var n in new List<NodeFactory<T>>(map.Values))
        {
          if (data.ContainsKeyRange(n.NodePrerequisites))
          {
            data[n.Id] = n.Create();
            working = true;
            map.Remove(n.Id);
          }
        }
      }

      if (map.Keys.Count() > 0)
      {
        throw new Exception("Recursive dependiencies. Failed to create " + string.Join(", ", map.Keys.ToArray()));
      }

      return data;
    }

    private class NodeFactory<T>
      where T : class 
    {
      public readonly Hashset<string> NodePrerequisites;
      public readonly string Id;
      private readonly Lazy<T> myFactory;
      private T myCachedAction;

      public NodeFactory(Hashset<string> nodeReq, string id, Lazy<T> factory)
      {
        NodePrerequisites = nodeReq;
        Id = id;
        myFactory = factory;
      }

      public T Create()
      {
        return myCachedAction ?? (myCachedAction = myFactory());
      }
    }

    private static T[] Safe<T>(T[] data)
    {
      return data ?? EmptyArray<T>.Instance;      
    }

    private static NodeFactory<IAction> CreateNode(Node node, TypeFinder finder, Converter<string, IAction> loadNode, Converter<string, IAction> loadGraph)
    {
      var clazz = node.Class;
      var type = finder.Find(clazz);
      if (type.GetConstructors().Length != 1)
        throw new ArgumentException("Failed to select constructor. Ambiguous.");
      var constructor = type.GetConstructors()[0];

      var argz = new List<Lazy<Object>>();
      var reqNodes = new Hashset<string>();
      var reqGraphs = new Hashset<string>();
      foreach (var p in CollectionUtil.Merge(constructor.GetParameters(), Safe(node.Args), (x,y)=>Pair.Create<ParameterInfo,NodeConstructorArgument>(x,y)))
      {
        var arg = p.Second;
        var parameterType = p.First.ParameterType;
        if (arg is NodeConstructorArgumentCode)
        {
          var code = ((NodeConstructorArgumentCode) arg).Code;

          var n = arg as NodeConstructorArgumentCode;
          if (typeof(string) == parameterType)
          {
            argz.Add(code.Trim);
          } else if (typeof(double) == parameterType)
          {
            argz.Add(()=>double.Parse(code.Trim()));
          } else if (typeof(int) == parameterType)
          {
            argz.Add(()=>int.Parse(code.Trim()));
          } else if (typeof(long) == parameterType)
          {
            argz.Add(()=>long.Parse(code.Trim()));
          }
          
          throw new NotImplementedException(arg.GetType().FullName);
        }
        else if (arg is NodeConstructorArgumentGraphReference)
        {
          var reference = (NodeConstructorArgumentGraphReference)arg;
          reqGraphs.Add(reference.refid);

          argz.Add(() => loadGraph(reference.refid));
        }
        else if (arg is NodeConstructorArgumentReference)
        {
          var reference = (NodeConstructorArgumentReference) arg;
          reqNodes.Add(reference.refid);

          argz.Add(() => loadNode(reference.refid));
        }
        else
        {
          throw new NotImplementedException(arg.GetType().FullName);
        }
      }

      return new NodeFactory<IAction>(
        reqNodes,
        node.Id,
        () =>
          {
            object[] args = argz.Map(x=>x()).ToArray();
            return (IAction) Activator.CreateInstance(type, args);
          });      
    }
  }
}