/*
 * Created by: 
 * Created: 6 ÿםגאנÿ 2007 ד.
 */

namespace DSIS.Core.Src.Context
{
  public interface IContext
  {
    T GetValue<T>(ContextKey<T> key);
    T GetValue<T>(ContextKey<T> key, T def);
  }

  public interface IWritableContext : IContext
  {
    void Add<T>(ContextKey<T> key, T value);
    void Remove<T>(ContextKey<T> key);
  }
}