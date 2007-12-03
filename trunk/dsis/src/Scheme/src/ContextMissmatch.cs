using DSIS.Scheme.Ctx;

namespace DSIS.Scheme
{
  public class ContextMissmatch
  {
    public readonly IKey Key;
    public readonly string Message;

    public ContextMissmatch(IKey key, string message)
    {
      Key = key;
      Message = message;
    }
  }

  public abstract class ContextMissmatchChech : ContextMissmatch
  {
    protected ContextMissmatchChech(IKey key, string message) : base(key, message)
    {
    }

    public abstract bool Check(Context ctx);

    public static ContextMissmatchChech Create<Y>(Key<Y> data, string msg)
    {
      return new ContextMissmatchCheckImpl<Y>(data, msg);
    }
  }

  public class ContextMissmatchCheckImpl<Y> : ContextMissmatchChech
  {
    public readonly Key<Y> TKey;

    public ContextMissmatchCheckImpl(Key<Y> key, string message) : base(key, message)
    {
      TKey = key;
    }

    public override bool Check(Context ctx)
    {
      return ctx.ContainsKey(TKey);
    }
  }
}