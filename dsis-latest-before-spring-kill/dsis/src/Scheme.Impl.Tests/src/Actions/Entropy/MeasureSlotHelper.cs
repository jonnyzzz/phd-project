using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public static class MeasureSlotHelper
  {
    public static IMeasureSlot Get(string key, Context ctx)
    {
      if (ctx.ContainsKey(Key(key)))
      {
        return ctx.Get(Key(key));
      }
      else
      {
        var ms = new MeasureSlot();
        ctx.Set(Key(key), ms);
        return ms;
      }
    }

    private static Key<MeasureSlot> Key(string key)
    {
      return new Key<MeasureSlot>(key);
    }
  }
}