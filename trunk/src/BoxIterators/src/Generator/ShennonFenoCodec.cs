using System;
using System.Collections;
using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.BoxIterators.Generator
{
  public class ShennonFenoCodec : IEnumerator<Pair<int, bool>>, IEnumerable<Pair<int,bool>>
  {
    private readonly int myDim;
    private BitArray myBits;
    private int[] myIs;
    private Pair<int, bool> myCurrent = new Pair<int, bool>(-1, false);

    public ShennonFenoCodec(int dim)
    {
      myDim = dim;
      Reset();
    }

    public void Reset()
    {
      myIs = new int[myDim + 1];
      myBits = new BitArray(myDim);
    }

    Pair<int, bool> IEnumerator<Pair<int, bool>>.Current
    {
      get { return myCurrent; }
    }

    object IEnumerator.Current
    {
      get { return myCurrent; }
    }

    bool IEnumerator.MoveNext()
    {
      if (myIs[myDim] != 0)
        return false;

      int current = 0;
      myIs[0]++; 

      for(int i=0; i<myDim; i++)
      {
        if (myIs[i] > 1)
        {
          myIs[current = i + 1]++;
          myIs[i] = 0;
        }
        else
          break;
      }

      if (myIs[myDim] == 0)
      {
        bool b = myBits[current] = !myBits[current];
        myCurrent = new Pair<int, bool>(current, b);
        return true;
      }
      return false;
    }

    void IDisposable.Dispose()
    {      
    }

    IEnumerator<Pair<int,bool>> IEnumerable<Pair<int,bool>>.GetEnumerator()
    {
      return new ShennonFenoCodec(myDim);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return new ShennonFenoCodec(myDim);
    }
  }
}