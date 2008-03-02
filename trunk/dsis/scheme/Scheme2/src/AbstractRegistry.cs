using System.Collections.Generic;

namespace DSIS.Scheme2
{
  public abstract class AbstractRegistry<T>
  {
    private readonly List<T> myElements = new List<T>();


    public void Register(T instance)
    {
      myElements.Add(instance);
    }

    protected delegate Q Apply<Q>(T instance);

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
  }
}