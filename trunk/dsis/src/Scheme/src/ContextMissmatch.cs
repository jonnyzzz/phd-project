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

  public abstract class ContextMissmatchCheck : ContextMissmatch
  {
    private readonly IAction myAction;

    protected ContextMissmatchCheck(IKey key, string message, IAction action) : base(key, message)
    {
      myAction = action;
    }

    public abstract bool Check(Context ctx);

    public IAction Action
    {
      get { return myAction; }
    }
  }

  public class ContextMissmatchCheckImpl<Y> : ContextMissmatchCheck
  {
    public readonly Key<Y> TKey;

    public ContextMissmatchCheckImpl(IAction action, Key<Y> key, string message) : base(key, message, action)
    {
      TKey = key;
    }

    public override bool Check(Context ctx)
    {
      return ctx.ContainsKey(TKey);
    }
  }
}