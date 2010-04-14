namespace DSIS.Scheme.Ctx
{
  public interface IWriteOnlyContext
  {
    void Set<Y>(Key<Y> key, Y value);
  }
}