using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.Graph.Morse;
using DSIS.Graph.Morse.Howard;
using DSIS.Graph.Morse.JVR;
using DSIS.Scheme;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl;
using DSIS.Scheme.Impl.Actions.Entropy;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Scheme.Impl.Actions.Performance;
using DSIS.SimpleRunner.Builder;
using DSIS.SimpleRunner.Computation;
using DSIS.SimpleRunner.Data;
using DSIS.Utils;

namespace DSIS.SimpleRunner.Entropy
{
  public class JVRDetMorseBuild : SIBuild
  {
    protected override IEnumerable<IEnumerable<ComputationData>> GetSystemsToRun2()
    {
      var data = new List<ComputationData>();
      for(int rep = 3; rep < 16; rep++)
      {
        data.AddRange(new []        {
                       new ComputationData {system = SystemInfoFactory.DoubleLogistic(), repeat = rep},
                       new ComputationData {system = SystemInfoFactory.Henon1_4(), repeat = rep},
                       new ComputationData {system = SystemInfoFactory.Ikeda(), repeat = rep},
                       new ComputationData {system = SystemInfoFactory.Delayed(2.27), repeat = rep},
                       new ComputationData {system = SystemInfoFactory.Logistic(3.569), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.Duffing2x2Runge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.Duffing1_5x1_5Runge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.Duffing1_4x1_4Runge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.Duffing1_3x1_3Runge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.Duffing1_2x1_2Runge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.DuffingRunge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.VanDerPolRunge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.LorentzRunge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.RosslerRunge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.BrusselatorRunge(), repeat = rep},
//                       new ComputationData {system = SystemInfoFactory.ChuaRunge(), repeat = rep},
                                    }.ForBuilders( new[] {
//                                      Builder.Adaptive,
                                      ComputationDataBuilder.Box
                                    }));
      }
      yield return data;
    }

    protected override IActionEdgesBuilder CreateActionsAfterSI(AfterSIParams<ComputationData> afterSIParams)
    {
      if (afterSIParams.IsLast)
      {
        //BuildJVRCall(afterSIParams.Logger, afterSIParams.SiConstructionAction, afterSIParams.System, 1e-3);
        //BuildHowardCall(afterSIParams.Logger, afterSIParams.SiConstructionAction, afterSIParams.System, 1e-3);

        BuildJustDumpCall(afterSIParams.Logger, afterSIParams.SiConstructionAction, afterSIParams.System);
        
        //BuildJVRCall(siConstructionAction, system, 1e-4);
        //BuildJVRCall(siConstructionAction, system, 1e-5);
        //BuildJVRCall(siConstructionAction, system, 1e-8);
      }
      return base.CreateActionsAfterSI(afterSIParams);
    }

    private static void BuildJustDumpCall(IAction logger, IActionEdgesBuilder siConstructionAction, IAction system)
    {
      var opts = new JustDumpMorseAction.JustDumpMorseOptions();
      var jvrMorseAction = new JustDumpMorseAction(opts) {PersitGraph = true};
      BuildJVRCall(logger, siConstructionAction, system, jvrMorseAction);
    }

    private static void BuildJVRCall(IAction logger, IActionEdgesBuilder siConstructionAction, IAction system, double eps)
    {
      var opts = new JVREvaluatorOptions {Eps = eps};
      var jvrMorseAction = new JVRMorseAction(opts);
      BuildJVRCall(logger, siConstructionAction, system, jvrMorseAction);
    }

    private static void BuildHowardCall(IAction logger, IActionEdgesBuilder siConstructionAction, IAction system, double eps)
    {
      var opts = new HowardEvaluatorOptions {Eps = eps};
      var jvrMorseAction = new HowardMorseAction(opts);
      BuildJVRCall(logger, siConstructionAction, system, jvrMorseAction);
    }

    private static void BuildJVRCall(IAction logger, IActionEdgesBuilder siConstructionAction, IAction system, IMorseAction morse)
    {

    var key = new RecordTimeAction(morse, "XxX" + morse.Options.MethodName + " " + morse.Options.Eps);
      siConstructionAction
        .Edge(key).With(x=>x.Back(system))
        .Edge(new DumpJVR(morse.Options, key.Key))
          .With(x => x.Back(siConstructionAction))
          .With(x => x.Back(system))
          .With(x=>x.Back(logger))
        ;
    }

    private class DumpJVR : IntegerCoordinateSystemActionBase3
    {
      private readonly IMorseOptions myOpt;
      private readonly Key<TimeSpan> myTime;

      public DumpJVR(IMorseOptions opt, Key<TimeSpan> time)
      {
        myOpt = opt;
        myTime = time;
      }

      protected override void Apply<T, Q>(Context input, Context output)
      {
        var graph = Keys.Graph<Q>().Get(input);
        var comps = Keys.GetGraphComponents<Q>().Get(input);
        var system = Keys.SystemInfoKey.Get(input);
        var logger = Logger.Instance(input);

        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");

        var sb = new StringBuilder();
        var time = myTime.Get(input).TotalMilliseconds;
        sb.AppendFormat(
          @"{6}: system:{0}, nodes:{1}, edges:{2}, components:{3}, time:{4}, eps:{5}",
          system.PresentableName,
          graph.NodesCount,
          graph.EdgesCount,
          comps.ComponentCount,
          time,
          myOpt.Eps,
          myOpt.MethodName
          ).AppendLine();

        var result = Keys.Morse<Q>().Get(input);

        foreach (var comp in comps.Components)
        {
          sb.Append("  ");
          sb.AppendFormat("nodes:{0}, edges:{1} ", comp.NodesCount, EdgesCount(comp, comps));

          var val = result.Get(comp);

          sb.AppendFormat("min: v={0}, length={1} ", val.Min.Value, val.Min.Contour.Count);
          sb.AppendFormat("max: v={0}, length={1} ", val.Max.Value, val.Max.Contour.Count);
          sb.AppendLine();
        }
        sb.AppendLine();

        logger.Write(sb.ToString());

        File.AppendAllText(@"e:\jvr_morse.log", sb.ToString());

        UpdateXmlLog(
          @"e:\xml-log.xml",
          new System
            {
              Name = system.PresentableName,
              Methods = new []
                          {
                            new Method
                              {
                                Name = myOpt.MethodName,
                                Graphs = new []
                                           {
                                             new Graph
                                               {
                                                 Date = DateTime.Now.ToString(),
                                                 Nodes = graph.NodesCount,
                                                 Edges = graph.EdgesCount,
                                                 Time = time,
                                                 Components = comps.Components.Select(
                                                   comp =>
                                                     {
                                                       var val = result.Get(comp);
                                                       return new Component
                                                                {
                                                                  Nodes = comp.NodesCount,
                                                                  Edges = EdgesCount(comp, comps),
                                                                  Maximum = val.Max.Value,
                                                                  Minimum = val.Min.Value,
                                                                  MaximumLength = val.Max.Count,
                                                                  MinimumLength = val.Min.Count
                                                                };
                                                     }).ToArray()
                                               }
                                           }
                              }
                          }
            });
      }

      private void UpdateXmlLog(string file, System result)
      {
        try
        {
          var f = new XmlSerializerFactory();
          var fileResults = new Results();
          if (File.Exists(file))
          {
            using (TextReader tr = File.OpenText(file))
            {
              fileResults = (Results) f.CreateSerializer(typeof (Results)).Deserialize(tr);
            }
          }
          fileResults.Attach(result);

          using (var tr = File.CreateText(file))
          {
            f.CreateSerializer(typeof (Results)).Serialize(tr, fileResults);
          }
        } catch(Exception e)
        {
          Console.Out.WriteLine(e);
        }
      }

      private static int EdgesCount<Q>(IStrongComponentInfo info, IGraphStrongComponents<Q> cms) 
        where Q : ICellCoordinate
      {
        return cms.GetNodes(new[] {info}).Sum(x=>cms.GetEdgesWithFilteredEdges(x, new[]{info}).Count());          
      }
    }

    [Serializable]
    public class Results
    {
      public System[] Systems { get; set; }

      public void Attach(System system)
      {
        foreach (var sys in Systems??EmptyArray<System>.Instance)
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
        Graphs = Graphs.Join(method.Graphs).ToArray();
      }
    }

    [Serializable]
    public class Graph
    {
      [XmlAttribute] public double Time { get; set; }
      [XmlAttribute] public string Date { get; set; }
      [XmlAttribute] public int Nodes { get; set; }
      [XmlAttribute] public int Edges { get; set; }
      public Component[] Components { get; set; }   
    }

    [Serializable]
    public class Component
    {
      [XmlAttribute] public int Nodes { get; set; }
      [XmlAttribute] public int Edges { get; set; }
      [XmlAttribute] public double Minimum { get; set; }
      [XmlAttribute] public int MinimumLength { get; set; }
      [XmlAttribute] public double Maximum { get; set; }
      [XmlAttribute] public int MaximumLength { get; set; }
    }
  }
}