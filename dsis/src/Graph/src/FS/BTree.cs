using System;
using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.Graph.FS
{
  public class BTree<TK, TV>
  {
    private readonly IComparer<TK> myKeyComparer;
    private readonly int myNodeSize;
    private BNode myRoot;

    public BTree(IComparer<TK> myKeyComparer, int myNodeSize)
    {
      this.myKeyComparer = myKeyComparer;
      this.myNodeSize = myNodeSize;
    }

    public void Add(TK key, TV value)
    {
      var d = new Data(key, value);
      if (myRoot == null)
      {
        myRoot = new BNode(d, myNodeSize);
      } else
      {
        myRoot.Insert(myKeyComparer, d);
      }
    }

    public IEnumerable<TK> Keys()
    {
      return myRoot == null ? EmptyArray<TK>.Instance : myRoot.Keys();
    }

    private class BNode
    {
      private readonly BNode[] myChildren;
      private readonly Data[] myKeys;

      public BNode(Data data, int size)
      {
        myKeys = new Data[size - 1];
        myChildren = new BNode[size];
        myKeys[0] = data;
      }

      private static void Shift<T>(T[] array, int startIndex)
      {
        for (int i = array.Length - 2; i >= startIndex; i--)
        {
          array[i + 1] = array[i];
        }
      }

      public IEnumerable<TK> Keys()
      {
        for(int i =0; i < myChildren.Length; i++)
        {
          if (myChildren[i] != null)
          {
            foreach (var k in myChildren[i].Keys())
            {
              yield return k;
            }
          }
          if (i < myKeys.Length && myKeys[i] != null)
          {
            yield return myKeys[i].Key;
          }
        }
      }

      public void Insert(IComparer<TK> comparer, Data data)
      {
        for (int i = 0; i < myKeys.Length; i++)
        {
          int cmp = myKeys[i] == null ? 1 : comparer.Compare(myKeys[i].Key, data.Key);
          if (cmp < 0)
          {
            //continue
          }

          if (cmp == 0)
          {
            //eq
          }

          if (cmp > 0)
          {
            if (myChildren[i] != null)
            {
              myChildren[i].Insert(comparer, data);
              return;
            }

            if (myKeys[myKeys.Length - 1] != null)
            {
              var node = new BNode(data, myChildren.Length);
              //Insert before i
              myChildren[i] = node;
              return;
            }
         
            Shift(myKeys, i);
            Shift(myChildren, i + 1);
            myChildren[i + 1] = null;
            myKeys[i] = data;
            return;
          }
        }
      }
    }

    private class Data
    {
      public readonly TK Key;
      public readonly TV Value;

      public Data(TK key, TV value)
      {
        Key = key;
        Value = value;
      }
    }
  }
}