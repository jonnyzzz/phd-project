namespace DSIS.Persistance
{
  public interface IPersistance<T>
  {
    void Save(T t, IBinaryWriter wr);
    T Load(IBinaryReader reader);
  }
}