namespace DSIS.Spring.Util
{
  public delegate void ProcessBean<Q>(Q q);

  public interface IBeanManager
  {
    void RegisterBeanProcessor<Q>(ProcessBean<Q> process) where Q : class;
  }
}