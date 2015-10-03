using DSIS.Spring.Util;

namespace DSIS.Spring.Util
{
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