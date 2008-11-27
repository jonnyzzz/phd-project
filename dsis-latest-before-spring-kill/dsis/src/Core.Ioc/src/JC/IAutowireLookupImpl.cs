using System.Collections.Generic;

namespace DSIS.Core.Ioc.JC
{
  public interface IAutowireLookupImpl
  {
    IEnumerable<Autowiring> GetAutowings(object obj);
  }
}