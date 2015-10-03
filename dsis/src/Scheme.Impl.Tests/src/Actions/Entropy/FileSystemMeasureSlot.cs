using System;
using System.IO;
using DSIS.Core.System.Impl;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.IntegerCoordinates.Generated;
using DSIS.Persistance;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  //todo: Use Spring or something
  public class FileSystemMeasureSlot : MeasureSlotBase
  {
    private readonly IPersistance<IMeasureInfo> myPersistance;

    private readonly DiskCache<Key, IMeasureInfo> myData;

    public FileSystemMeasureSlot()
    {
      var myPath = Path.Combine(Path.GetTempPath(), "MeasureInfoCache");
      Directory.CreateDirectory(myPath);

      myPersistance = new MeasureInfoPersistance(
        new GraphMeasurePersistance(
          new IntegerCoordinatePersistanceProxy(
            new IntegerCoordinatePersistance(
              new DefaultSystemSpacePersistance(),
              GeneratedIntegerCoordinateSystemManager.Instance))
          )
        );
      var myPresistanceFactory = new PersistanceFactory();

      myData = new DiskCache<Key, IMeasureInfo>(myPersistance, myPresistanceFactory, myPath);
    }

    private struct Key : IEquatable<Key>
    {
      public int Step { get; private set; }
      public int Proj { get; private set; }

      public Key(int step, int proj) : this()
      {
        Step = step;
        Proj = proj;
      }

      public bool Equals(Key obj)
      {
        return obj.Step == Step && obj.Proj == Proj;
      }

      public override bool Equals(object obj)
      {
        if (obj.GetType() != typeof (Key)) return false;
        return Equals((Key) obj);
      }

      public override int GetHashCode()
      {
        unchecked
        {
          return (Step*397) ^ Proj;
        }
      }
    }

    protected override void Add(IMeasureInfo mes)
    {
      var key = new Key(mes.Step, mes.Proj);
      myData.AddItem(key, mes);
    }

    protected override IMeasureInfo Get(int step, int proj)
    {
      return myData.GetItem(new Key(step, proj));
    }
  }
}