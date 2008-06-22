using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class InsertMeasureToSlotAction : IntegerCoordinateSystemActionBase2
  {
    private readonly ILoopAction myLoopAction;
    private readonly ILoopAction myProjAction;
    private readonly string myKey;

    public InsertMeasureToSlotAction(string key, ILoopAction loopAction, ILoopAction projAction)
    {
      myLoopAction = loopAction;
      myProjAction = projAction;
      myKey = key;
    }

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx),
                     Create(Keys.GraphMeasure<Q>()),
                     Create(myLoopAction.Key),
                     Create(myProjAction.Key)
                     );
    }


    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      IGraphMeasure<Q> measure = Keys.GraphMeasure<Q>().Get(input);
      SlotStore slot = SlotStore.Get(input);
      var idx = myLoopAction.Key.Get(input);
      var prj = myProjAction.Key.Get(input);

      MeasureSlot<Q>.Get(myKey, slot).RegisterResult(idx.Index, prj.Index, measure);

      output.AddAll(input);
    }
  }

  public class MeasureSlot<Q> where Q : ICellCoordinate
  {
    private readonly List<MeasureInfo<Q>> myMeasures = new List<MeasureInfo<Q>>();

    private struct C : IEquatable<C>
    {
      public readonly int Step;
      public readonly int Proj;

      public C(int step, int proj)
      {
        Step = step;
        Proj = proj;
      }

      public bool Equals(C obj)
      {
        return obj.Step == Step && obj.Proj == Proj;
      }

      public override bool Equals(object obj)
      {
        return obj.GetType() == typeof (C) && Equals((C) obj);
      }

      public override int GetHashCode()
      {
        unchecked
        {
          return (Step*397) ^ Proj;
        }
      }
    }

    public static MeasureSlot<Q> Get(string key, Context ctx)
    {
      if (ctx.ContainsKey(Key(key)))
      {
        return ctx.Get(Key(key));
      } else
      {
        var ms = new MeasureSlot<Q>();
        ctx.Set(Key(key), ms);
        return ms;
      }
    }

    private static Key<MeasureSlot<Q>> Key(string key)
    {
      return new Key<MeasureSlot<Q>>(key);
    }

    public void RegisterResult(int step, int proj, IGraphMeasure<Q> mes)
    {
      myMeasures.Add(new MeasureInfo<Q>(step, proj, mes));      
    }
  }

  public class MeasureInfo<Q> where Q : ICellCoordinate
  {
    public readonly int Proj;
    public readonly int Step;
    public readonly IGraphMeasure<Q> Measure;

    public MeasureInfo(int step, int proj, IGraphMeasure<Q> measure)
    {
      Step = step;
      Proj = proj;
      Measure = measure;
    }
  }
}