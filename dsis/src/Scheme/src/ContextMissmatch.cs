using DSIS.Scheme.Ctx;

namespace DSIS.Scheme
{
  public class ContextMissmatch
  {
    public readonly IKey Key;
    private readonly string myMessage;
    private readonly IAction myAction;

    public ContextMissmatch(IKey key, string message, IAction action)
    {
      Key = key;
      myAction = action;
      myMessage = message;
    }

    public IAction Action
    {
      get { return myAction; }
    }

    public string Message
    {
      get { return string.Format("Action: {0}\r\nContext: {1}", myAction.GetType().Name, myMessage); }
    }
  }

  public abstract class ContextMissmatchCheck : ContextMissmatch
  {
    protected ContextMissmatchCheck(IKey key, string message, IAction action) : base(key, message, action)
    {      
    }

    public abstract bool Check(Context ctx);
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