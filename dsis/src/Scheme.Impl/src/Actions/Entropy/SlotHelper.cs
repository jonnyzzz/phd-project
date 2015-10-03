using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class SlotHelper<I, T> where T : I,new()
  {
    public static I Get(string key, SlotStore ctx)
    {
      if (ctx.ContainsKey(Key(key)))
        return ctx.Get(Key(key));

      var ms = new T();
      ctx.Set(Key(key), ms);
      return ms;
    }

    private static Key<T> Key(string key)
    {
      return new Key<T>(key);
    }    
  }
}