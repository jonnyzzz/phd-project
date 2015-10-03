using System;
using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.SimpleRunner.Actions
{
  public class OperationStack<T>
  {
    private readonly Stack<Pair<T, OperationData>> myOperations = new Stack<Pair<T, OperationData>>();

    public void Push(T t, string name)
    {
      myOperations.Push(new Pair<T, OperationData>(t, new OperationData(name)));
    }

    public Pair<T, OperationData> Pop(string name)
    {
      if (myOperations.Peek().Second.Operation != name)
        throw new ArgumentException("unexpected name");
      
      return myOperations.Pop();      
    }

    public T Peek()
    {
      return myOperations.Peek().First;
    }
  }
}