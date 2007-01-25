namespace DSIS.Core.Src.Context
{
  public class CellImageBuilderKey<TBuilder, TValue> : ContextKey<TValue>
  {
    public CellImageBuilderKey(string key) : base(TypeName(typeof(TBuilder)) + ":" + key)
    {
    }
  }
}