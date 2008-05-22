namespace DSIS.Spring.Service
{
  public interface IServiceProvider
  {
    T GetService<T>();
  }
}