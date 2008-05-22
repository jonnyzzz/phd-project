using System.Collections.Generic;

namespace DSIS.Spring.Util
{
  public abstract class AbstractRegistry<T>
  {
    private readonly List<T> myElements = new List<T>();

    public void Register(T instance)
    {
      myElements.Add(instance);
    }

    protected delegate Q Apply<Q>(T instance);
    protected delegate void ApplyVoid(T instance);

    protected Q ForEach<Q>(Apply<Q> del) where Q : class
    {
      foreach (T element in myElements)
      {
        Q q = del(element);
        if (q != null)
          return q;
      }
      return null;
    }

    protected void ForEach(ApplyVoid del)
    {
      foreach (T element in myElements)
      {
        del(element);
      }
    }

    protected IEnumerable<Q> ForCollect<Q>(Apply<IEnumerable<Q>> appl)
    {
      foreach (var el in myElements)
      {
        foreach (var q in appl(el))
        {
          yield return q;
        }
      }
    }
  }
}