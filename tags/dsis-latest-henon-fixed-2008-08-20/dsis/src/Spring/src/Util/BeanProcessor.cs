using System.Collections.Generic;
using Spring.Objects.Factory;
using Spring.Objects.Factory.Config;

namespace DSIS.Spring.Util
{
  [UsedBySpring]
  public class BeanProcessor : IObjectPostProcessor, IBeanManager, IInitializingObject
  {
    private readonly List<object> myLoadedObjects = new List<object>();
    private readonly List<IKey> myHandlers = new List<IKey>();

    public object PostProcessBeforeInitialization(object instance, string name)
    {
      return instance;
    }

    public object PostProcessAfterInitialization(object instance, string objectName)
    {
      myLoadedObjects.Add(instance);

      foreach (IKey key in myHandlers)
      {
        key.Process(instance);
      }
      return instance;
    }

    private interface IKey
    {
      void Process(object o);
    }

    private class Key<Q> : IKey
      where Q : class
    {
      private readonly ProcessBean<Q> myProc;

      public Key(ProcessBean<Q> myProc)
      {
        this.myProc = myProc;
      }

      public void Process(object o)
      {
        var q = o as Q;
        if (q != null)
          myProc(q);
      }
    }

    public void RegisterBeanProcessor<Q>(ProcessBean<Q> process) where Q : class
    {
      var item = new Key<Q>(process);
      new List<object>(myLoadedObjects).ForEach(item.Process);
      myHandlers.Add(item);
    }

    public void RegisterTypeProcessor(ProcessBean<object> process)
    {
      RegisterBeanProcessor(process);
    }

    public void AfterPropertiesSet()
    {
    } 
  }
}