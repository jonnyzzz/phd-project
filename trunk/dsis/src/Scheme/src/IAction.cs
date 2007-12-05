using System.Collections.Generic;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme
{
  public interface IAction
  {
    ICollection<ContextMissmatch> Compatible(Context ctx);
    Context Apply(Context ctx);
  }

  public abstract class ActionBase : IAction
  {
    public abstract ICollection<ContextMissmatch> Compatible(Context ctx);
    public Context Apply(Context ctx)
    {
      Context result = new Context();
      Apply(ctx, result);
      return result;
    }

    protected static ICollection<ContextMissmatch> CheckContext(Context ctx, params ContextMissmatchCheck[] data)
    {
      List<ContextMissmatch> list = new List<ContextMissmatch>();
      foreach (ContextMissmatchCheck missmatch in data)
      {
        if (!missmatch.Check(ctx))
          list.Add(missmatch);
      }
      return list;
    }

    protected static ContextMissmatchCheck Create<Y>(Key<Y> key)
    {
      return new ContextMissmatchCheckImpl<Y>(key, "None");
    }

    protected static ICollection<T> Col<T>(params T[] data)
    {
      return data;
    }

    protected static ICollection<ContextMissmatchCheck> ColBase(ICollection<ContextMissmatchCheck> bs, params ContextMissmatchCheck[] data)
    {
      List<ContextMissmatchCheck> dta = new List<ContextMissmatchCheck>();
      dta.AddRange(bs);
      dta.AddRange(data);
      return dta;      
    }

    protected abstract void Apply(Context ctx, Context result);
  }
}