namespace DSIS.Persistance
{
  public interface IPersistanceManager
  {
    IPersistance<Q> Persistance<Q>();
  }
}