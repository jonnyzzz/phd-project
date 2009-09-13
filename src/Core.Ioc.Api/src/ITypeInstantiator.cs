namespace EugenePetrenko.Shared.Core.Ioc.Api
{
  [NoInheritContainer]
  public interface ITypeInstantiator
  {
    /// <summary>
    /// Create instance of type T using specified parameters and 
    /// current component container. 
    /// All autowirings are done.
    /// 
    /// Type T must be marked with <see cref="TypeInstanciableAttribute"/>
    /// </summary>
    /// <typeparam name="T">instance to create</typeparam>
    /// <param name="instances">additional components</param>
    /// <returns>create instace</returns>
    T Instanciate<T>(params object[] instances);
  }
}