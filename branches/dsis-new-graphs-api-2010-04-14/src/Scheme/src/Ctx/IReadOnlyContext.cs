namespace DSIS.Scheme.Ctx
{
  public interface IReadOnlyContext
  {
    bool ContainsKey<Y>(Key<Y> key);
    Y Get<Y>(Key<Y> key);
  }
}