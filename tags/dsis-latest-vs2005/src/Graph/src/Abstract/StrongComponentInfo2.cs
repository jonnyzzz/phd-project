using System;
using System.Collections.Generic;
using System.IO;

namespace DSIS.Graph.Abstract
{
  public class StrongComponentInfo2 : IStrongComponentInfoEx
  {
    private StrongComponentInfo2 myReference = null;
    private int myCount;
    private int myGeneration = 0;
    private StrongComponentHash myIns;
    private StrongComponentHash myOuts;

    public StrongComponentInfo2(Dictionary<int, long> events)
    {
      myIns = new StrongComponentHash(events);
      myOuts = new StrongComponentHash(events);
    }

    #region IStrongComponentInfoEx Members

    public void Dump(TextWriter tw, Dictionary<IStrongComponentInfo, int> comps, ref int cnt)
    {
      foreach (StrongComponentInfo2 info in myOuts.Elements)
      {
        int id;
        if (!comps.TryGetValue(info, out id))
        {
          id = ++cnt;
          comps[info] = id;
        }
        tw.Write(" {0}, ", id);
      }
    }

    public IEnumerable<IStrongComponentInfoEx> Ins
    {
      get { return myIns.Elements; }
    }

    public bool InsContains(IStrongComponentInfoEx comp)
    {
      return myIns.Contains((StrongComponentInfo2) comp);
    }

    public int NodesCount
    {
      get { return myCount; }
      set { myCount = value; }
    }

    public IEnumerable<IStrongComponentInfoEx> Outs
    {
      get { return myOuts.Elements; }
    }

    public IStrongComponentInfoEx Reference
    {
      get
      {
        if (myReference == null)
          return this;
        while (myReference.myReference != null)
        {
          myReference = myReference.myReference;
        }
        return myReference;
      }
      set
      {
        myReference = (StrongComponentInfo2) value;
        myIns = null;
        myOuts = null;
        myReference.myGeneration = Math.Max(myGeneration + 1, myReference.myGeneration);
      }
    }

    #endregion

    public int Generation
    {
      get { return myGeneration; }
    }

    internal StrongComponentHash InsInternal
    {
      get { return myIns; }
    }

    internal StrongComponentHash OutsInternal
    {
      get { return myOuts; }
    }
  }
}