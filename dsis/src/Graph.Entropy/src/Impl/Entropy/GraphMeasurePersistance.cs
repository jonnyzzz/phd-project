using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Persistance;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Entropy
{
  public class GraphMeasurePersistance : IPersistance<IGraphMeasure>
  {
    private readonly IPersistance<ICellCoordinateSystem> myPersistanceManager;

    public GraphMeasurePersistance(IPersistance<ICellCoordinateSystem> persistanceManager)
    {
      myPersistanceManager = persistanceManager;
    }

    private static string Key()
    {
      return "GRAPH_MEASURE_PERSISTANCE";
    }

    public void Save(IGraphMeasure t, IBinaryWriter wr)
    {
      t.DoCallback(new SaveWith(myPersistanceManager, wr));
    }

    private class SaveWith : IGraphMeasureWith
    {
      private readonly IPersistance<ICellCoordinateSystem> myPersistanceManager;
      private readonly IBinaryWriter myReader;

      public SaveWith(IPersistance<ICellCoordinateSystem> persistanceManager, IBinaryWriter wr)
      {
        myPersistanceManager = persistanceManager;
        myReader = wr;
      }

      public void WithGraphMeasure<Q>(IGraphMeasure<Q> measure) where Q : ICellCoordinate
      {
        Save(measure, myReader);
      }

      public void Save<Q>(IGraphMeasure<Q> measure, IBinaryWriter writer)
        where Q : ICellCoordinate
      {
        writer.WriteString(Key());
        writer.WriteString(measure.Method);
        var cs = measure.CoordinateSystem;
        myPersistanceManager.Save(cs, writer);

        var list = new List<Pair<PairBase<Q>, double>>(measure.Measure);

        writer.WriteInt(list.Count);
        cs.Save(writer, list.Maps(x => new[] {x.First.From, x.First.To}));

        foreach (var pair in list)
        {
          writer.WriteDouble(pair.Second);
        }
      }
    }

    private class LoadWith : ICellCoordinateWith
    {
      private readonly IBinaryReader myReader;
      private readonly string myMethod;
      private IGraphMeasure myMeasure;

      public LoadWith(IBinaryReader reader, string method)
      {
        myReader = reader;
        myMethod = method;
      }

      public void With<Q>(ICellCoordinateSystem<Q> system) where Q : ICellCoordinate
      {
        var comparer = EqualityComparerFactory<NodePair<Q>>.GetComparer();
        var values = new Dictionary<NodePair<Q>, double>(comparer);
        foreach (var edge in new List<NodePair<Q>>(Join(system.Load(myReader))))
        {
          values.Add(edge, myReader.ReadDouble());
        }

        myMeasure = new GraphMeasure<Q, NodePair<Q>>(myMethod, values, EqualityComparerFactory<Q>.GetComparer(), 1,
                                                     system);
      }

      public IGraphMeasure Measure
      {
        get { return myMeasure; }
      }
    }


    private static IEnumerable<NodePair<Q>> Join<Q>(IEnumerable<Q> enu)
      where Q : ICellCoordinate
    {
      using (var e = enu.GetEnumerator())
      {
        while (true)
        {
          if (!e.MoveNext()) yield break;
          var from = e.Current;
          if (!e.MoveNext()) yield break;
          var to = e.Current;

          yield return new NodePair<Q>(from, to);
        }
      }
    }

    public IGraphMeasure Load(IBinaryReader reader)
    {
      if (Key() != reader.ReadString())
        throw new ArgumentException("Unexpected input string");

      var method = reader.ReadString();
      var cs = myPersistanceManager.Load(reader);
      
      reader.ReadInt();
      
      var with = new LoadWith(reader, method);
      cs.DoGeneric(with);

      return with.Measure;
    }
  }
}