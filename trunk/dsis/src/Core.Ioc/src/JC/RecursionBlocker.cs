using System;
using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.Core.Ioc.JC
{
  public class RecursionBlocker<T>
  {
    private readonly HashSet<T> myStack = new HashSet<T>();
    private int myDepth = 0;

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
      private readonly int myDepth;

      public CallD(T obj, RecursionBlocker<T> holder)
      {
        myObj = obj;
        myHolder = holder;
        myDepth = myHolder.myDepth++;
        myHolder.myStack.Add(obj);
      }

      public void Dispose()
      {
        if (!myHolder.myStack.Contains(myObj) || myDepth != myHolder.myDepth - 1)
          throw new JContainerException("Unexpected end of component " + myObj);
        myHolder.myStack.Remove(myObj);
        myHolder.myDepth--;
      }
    }
  }
}