using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Spring.Attributes;
using DSIS.Spring.Util;
using DSIS.Utils;
using Spring.Objects.Factory;

namespace DSIS.Spring.Lifecycle
{
  [SpringBean]
  public class InitializeBeanProcessor : IInitializingObject, ILifecycle
  {
    private readonly List<VoidDelegate> myInits = new List<VoidDelegate>();

    public InitializeBeanProcessor(IBeanManager namager)
    {
      namager.RegisterTypeProcessor(q =>
                                      {
                                        foreach (var info in q.GetType().GetMethods())
                                        {
                                          if (Attribute.IsDefined(info, typeof(InitializeBeanAttribute)))
                                          {
                                            RegisterHandler(q, info);
                                          }
                                        }
                                      });
    }

    private void RegisterHandler(object q, MethodInfo info)
    {
      myInits.Add(() => info.Invoke(q, new object[0]));
    }

    public void AfterPropertiesSet()
    {
      foreach (var d in myInits)
      {
        d();
      }
    }

    public event VoidDelegate OnInit
    {
      add { myInits.Add(value);}
      remove { myInits.Remove(value);}
    }
  }
}