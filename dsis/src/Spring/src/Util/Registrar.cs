using System;

namespace DSIS.Spring.Util
{
  [Obsolete("Use IServiceProvider.GetServices`1")]
  public abstract class Registrar<T,F> 
    where T : class
    where F : AbstractRegistry<T>    
  {
    protected Registrar(F factory)
    {
      factory.Register((T)(object)this);
    }
  }
}