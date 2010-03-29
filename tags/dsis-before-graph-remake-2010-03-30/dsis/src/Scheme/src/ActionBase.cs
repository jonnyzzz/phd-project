using System;
using System.Collections.Generic;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
  
namespace DSIS.Scheme
{
  public abstract class ActionBase : DebugableAction, IAction
  {
    public abstract ICollection<ContextMissmatch> Compatible(Context ctx);
    public Context Apply(Context ctx)
    {
      var result = new Context();
      Apply(ctx, result);
      return result;
    }

    public IAction Clone()
    {
      var constructor = GetType().GetConstructor(new Type[0]);
      if (constructor == null)
        throw new NotImplementedException("Clone() does not implemented for " + GetType().FullName);

      try
      {
        return (IAction) Activator.CreateInstance(GetType());
      } catch (Exception e)
      {
        throw new Exception("Failed to Clone type " + GetType().FullName + ". " + e.Message, e);
      }
    }

    protected static ICollection<ContextMissmatch> CheckContext(Context ctx, ICollection<ContextMissmatch> data, params ContextMissmatchCheck[] data2)
    {
      var context = CheckContext(ctx, data2);
      context.AddRange(data);
      return context;
    }

    protected static List<ContextMissmatch> CheckContext(Context ctx, params ContextMissmatchCheck[] data)
    {
      var list = new List<ContextMissmatch>();
      foreach (var missmatch in data)
      {
        if (!missmatch.Check(ctx))
          list.Add(missmatch);
      }
      return list;
    }

    protected ContextMissmatchCheck Create<Y>(Key<Y> key)
    {
      return new ContextMissmatchCheckImpl<Y>(this, key, typeof(Y).Name + "@" + key.Name);
    }

    protected ContextMissmatchCheck Create<Y>(Key<Y> key, string message)
    {
      return new ContextMissmatchCheckImpl<Y>(this, key, string.Format("{0}@{1}: {2}", typeof(Y).Name, key.Name, message));
    }

    protected static ICollection<T> Col<T>(params T[] data)
    {
      return data;
    }

    protected static ICollection<ContextMissmatchCheck> ColBase(ICollection<ContextMissmatchCheck> bs, params ContextMissmatchCheck[] data)
    {
      var dta = new List<ContextMissmatchCheck>();
      dta.AddRange(bs);
      dta.AddRange(data);
      return dta;      
    }

    protected abstract void Apply(Context ctx, Context result);
  }
}