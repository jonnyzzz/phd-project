using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Persistance;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class MeasureInfoPersistance : IPersistance<IMeasureInfo>
  {
    private readonly IPersistance<IGraphMeasure> myMeasurePersistance;

    public MeasureInfoPersistance(IPersistance<IGraphMeasure> measurePersistance)
    {
      myMeasurePersistance = measurePersistance;
    }

    public void Save(IMeasureInfo info, IBinaryWriter myWriter)
    {
      myWriter.WriteString(Key());
      myWriter.WriteInt(info.Step);
      myWriter.WriteInt(info.Proj);

      foreach (var measure in info.Measures())
      {
        myWriter.WriteInt(0);
        myMeasurePersistance.Save(measure, myWriter);
      }
      myWriter.WriteInt(1);
    }

    private static string Key() {
      return "MeasureInfo"; }

    public IMeasureInfo Load(IBinaryReader reader)
    {
      if (Key() != reader.ReadString())
        throw new ArgumentException("Wrong object key");

      var step = reader.ReadInt();
      var proj = reader.ReadInt();

      var infos = new List<IGraphMeasure>();

      while (reader.ReadInt() == 0)
      {
        infos.Add(myMeasurePersistance.Load(reader));
      }


      var lw = new LoadWith
                      {
                        Step = step,
                        Proj = proj
                      };
      infos.ForEach(x=>x.DoCallback(lw));
      return lw.Info;
    }

    private class LoadWith : IGraphMeasureWith
    {
      public IMeasureInfo Info { get; set; }
      public int Step { get; set; }
      public int Proj { get; set; }
     
      public void WithGraphMeasure<Q>(IGraphMeasure<Q> measure) where Q : ICellCoordinate
      {
        if (Info == null)
        {
          Info = new MeasureInfo<Q>(Step, Proj, measure);
        } else
        {
          Info.Join(measure);
        }
      }
    }
  }
}