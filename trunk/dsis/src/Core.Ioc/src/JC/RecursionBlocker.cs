using System;
using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.Core.Ioc.JC
{
  public class RecursionBlocker<T>
  {
    private readonly Queue<T> myStack = new Queue<T>();

    public IDisposable Call(T o)
    {
      if (myStack.Contains(o))
      {
        throw new JContainerException("Cyclic dependency on: " + myStack.JoinString("->"));
      }
      return new CallD(o, this);
    }

    private class CallD : IDisposable {
      private readonly T myObj;
      private readonly RecursionBlocker<T> myHolder;

      public CallD(T obj, RecursionBlocker<T> holder)
      {
        myObj = obj;
        myHolder = holder;
      }

      public void Dispose()
      {
        if (myHolder.myStack.Peek().Equals(myObj))
          throw new JContainerException("Unexpected end of component " + myObj);
        myHolder.myStack.Dequeue();
      }
    }
  }
}