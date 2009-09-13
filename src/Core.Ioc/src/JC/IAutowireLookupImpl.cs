using System.Collections.Generic;

namespace EugenePetrenko.Shared.Core.Ioc.JC
{
  public interface IAutowireLookupImpl
  {
    IEnumerable<Autowiring> GetAutowings(object obj);
  }
}