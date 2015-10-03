using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace reportGenerator
{
  class Program
  {
    public static Results LoadData(string file)
    {
      var f = new XmlSerializerFactory();
      using (TextReader tr = File.OpenText(file))
      {
        return (Results)f.CreateSerializer(typeof(Results)).Deserialize(tr);
      }
    }

    public class RowData
    {
      public RowData(Graph graph)
      {
        Nodes = graph.Nodes;
        Edges = graph.Edges;
      }

      public int Nodes { get; private set; }
      public int Edges { get; private set; }

      public bool Equals(RowData other)
      {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return other.Nodes == Nodes;
      }

      public override bool Equals(object obj)
      {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != typeof (RowData)) return false;
        return Equals((RowData) obj);
      }

      public override int GetHashCode()
      {
        return Nodes;
      }
    }

    public class ComputationResult { public double Time { get; set; } }

    private static Dictionary<RowData, List<ComputationResult>> JoinData(Func<Method, bool> check, Results results)
    {
      var data = new Dictionary<RowData, List<ComputationResult>>();
      foreach (var graph in results
        .Systems
        .SelectMany(x=>x.Methods)
        .Where(check)
        .SelectMany(x=>x.Graphs)
        .Where(x=>x.Nodes > 0)
        .Where(x=>x.Edges > 0)
        ) 
      {
        var rd = new RowData(graph);
        List<ComputationResult> cr;
        if (!data.TryGetValue(rd, out cr)) { cr = new List<ComputationResult>();}
        cr.Add(new ComputationResult{Time = graph.Time});
        data[rd] = cr;
      }
      return data;
    }
    
    private static Dictionary<RowData, ComputationResult> Mean(Dictionary<RowData, List<ComputationResult>> data)
    {
      var result = new Dictionary<RowData, ComputationResult>();
      foreach (var res in data)
      {
        double mean = res.Value.Select(x => x.Time).Sum() / res.Value.Count;
        result[res.Key] = new ComputationResult {Time = mean};
      }
      return result;
    }

    public class MethodResults { public double JVR_Time { get; set; } public double HWR_Time { get; set; } }
    
    private static Dictionary<RowData, MethodResults> Zip(Dictionary<RowData, ComputationResult> jvr, Dictionary<RowData, ComputationResult> hwr)
    {
      var result = new Dictionary<RowData, MethodResults>();
      foreach (var j in jvr)
      {
        ComputationResult cr;
        if (!hwr.TryGetValue(j.Key, out cr)) continue;
        result[j.Key] = new MethodResults {HWR_Time = cr.Time, JVR_Time = j.Value.Time};
      }
      return result;
    }

    public static void Main(string[] args)
    {
      var loadData = LoadData(args[0]);

      var joined = Zip(
        Mean(JoinData(m => m.Name == "JVR", loadData)),
        Mean(JoinData(m => m.Name == "Howard", loadData))
        );

      using (var tw = File.CreateText(args[1] + ".csv"))
      {
        tw.WriteLine("Nodes; Edges; JVR_Time; HWR_Time");
        foreach (var key in joined.Keys.OrderBy(x=>x.Nodes))
        {
          var value = joined[key];
          tw.WriteLine("{0}; {1}; {2}; {3}", key.Nodes, key.Edges, value.JVR_Time, value.HWR_Time);
        }
      }
    }
  }

  public class EmptyArray<T>
  {
    public static readonly T[] Instance = new T[0];
  }

  public static class Util
  {
    public static T[] Attach<T>(this T[] t, T oth)
    {
      if (t == null) return new[] {oth};
      var list = new List<T>(t);
      list.Add(oth);
      return list.ToArray();
    }
  }

  [Serializable]
  public class Results
  {
    public System[] Systems { get; set; }

    public void Attach(System system)
    {
      foreach (var sys in Systems ?? EmptyArray<System>.Instance)
      {
        if (sys.Name == system.Name)
        {
          sys.Merge(system);
          return;
        }
      }
      Systems = Systems.Attach(system);
    }
  }

  [Serializable]
  public class System
  {
    [XmlAttribute]
    public string Name { get; set; }
    public Method[] Methods { get; set; }

    public void Merge(System system)
    {
      foreach (var method in system.Methods)
      {
        bool merged = false;
        foreach (var meth in Methods ?? EmptyArray<Method>.Instance)
        {
          if (method.Name == meth.Name)
          {
            meth.Merge(method);
            merged = true;
            break;
          }
        }
        if (!merged)
        {
          Methods = Methods.Attach(method);
        }
      }
    }
  }

  [Serializable]
  public class Method
  {
    [XmlAttribute]
    public String Name { get; set; }
    public Graph[] Graphs { get; set; }

    public void Merge(Method method)
    {
      var t = new List<Graph>();
      t.AddRange(Graphs);
      t.AddRange(method.Graphs);
      Graphs = t.ToArray();
    }
  }

  [Serializable]
  public class Graph
  {
    [XmlAttribute]
    public double Time { get; set; }
    [XmlAttribute]
    public string Date { get; set; }
    [XmlAttribute]
    public int Nodes { get; set; }
    [XmlAttribute]
    public int Edges { get; set; }
    public Component[] Components { get; set; }
  }

  [Serializable]
  public class Component
  {
    [XmlAttribute]
    public int Nodes { get; set; }
    [XmlAttribute]
    public int Edges { get; set; }
    [XmlAttribute]
    public double Minimum { get; set; }
    [XmlAttribute]
    public int MinimumLength { get; set; }
    [XmlAttribute]
    public double Maximum { get; set; }
    [XmlAttribute]
    public int MaximumLength { get; set; }
  }
}
