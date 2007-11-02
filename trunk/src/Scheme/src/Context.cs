using System.Collections.Generic;

namespace DSIS.Scheme
{
  public interface IContext
  {
    bool HasKey<Y>(Key<Y> key);
    Y Get<Y>(Key<Y> key);
  }

  public interface IWriteableContext : IContext
  {
    void Set<Y>(Key<Y> key, Y value);
    void Remove<Y>(Key<Y> key);
  }
}