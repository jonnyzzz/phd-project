namespace EugenePetrenko.Shared.Core.Ioc.Api
{
  [NoInheritContainer]
  public interface ISubContainerFactory
  {
    IComponentContainerBuilder SubContainer<TImplementation>(params object[] instances)
      where TImplementation : ComponentImplementationAttributeBase;

    IComponentContainerBuilder SubContainerNoScan<TImplementation>(params object[] instances)
      where TImplementation : ComponentImplementationAttributeBase;
  }
}