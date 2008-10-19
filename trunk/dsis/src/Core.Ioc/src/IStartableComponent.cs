namespace DSIS.Core.Ioc
{
  [ComponentCollection, NoInheritContainer]
  public interface IStartableComponent
  {
    void Start();
  }
}