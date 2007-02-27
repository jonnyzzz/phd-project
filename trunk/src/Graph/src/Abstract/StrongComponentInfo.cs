using System.Collections.Generic;
using System.IO;
using DSIS.Core.Util;
using DSIS.Graph.Util;
using DSIS.Util;

namespace DSIS.Graph.Abstract
{
  internal class StrongComponentInfo : IStrongComponentInfoEx, IStrongComponentInfoConnectivity
  {
    private StrongComponentInfo myReference = null;
    private Hashset<StrongComponentInfo, IStrongComponentInfo> myOuts;
    private Hashset<StrongComponentInfo, IStrongComponentInfo> myIns;
    private int myNodesCount = 0;

    public StrongComponentInfo()
    {
      myOuts = new Hashset<StrongComponentInfo, IStrongComponentInfo>();
      myIns = new Hashset<StrongComponentInfo, IStrongComponentInfo>();
    }

    public int NodesCount
    {
      get { return myNodesCount; }
      set { myNodesCount = value; }
    }

    public bool InsContains(IStrongComponentInfoEx comp)
    {
      return myIns.Contains((StrongComponentInfo) comp);
    }

    public IEnumerable<IStrongComponentInfo> Out
    {
      get { return myOuts.ValuesUpcasted; }
    }

    public IEnumerable<IStrongComponentInfo> In
    {
      get { return myIns.ValuesUpcasted; }
    }

    public IStrongComponentInfoEx Reference
    {
      get
      {
        if (myReference == null)
          return this;

        while (myReference.IsReference)
          myReference = myReference.myReference;
        return myReference;
      }
      set
      {
        myReference = (StrongComponentInfo) value.Reference;
        foreach (StrongComponentInfo info in myOuts)
        {
          info.myIns.Remove(this);
          info.myIns.Add(myReference);
        }
        foreach (StrongComponentInfo info in myIns)
        {
          info.myOuts.Remove(this);
          info.myOuts.Add(myReference);
        }
        myOuts = null;
        myIns = null;
      }
    }
    
    public bool IsReference
    {
      get { return myReference != null; }
    }

    public Hashset<StrongComponentInfo, IStrongComponentInfo> Outs
    {
      get { return myOuts; }
    }

    public Hashset<StrongComponentInfo, IStrongComponentInfo> Ins
    {
      get { return myIns; }
    }


    IEnumerable<IStrongComponentInfoEx> IStrongComponentInfoEx.Ins
    {
      get { return new ConvertEnumerator<StrongComponentInfo, IStrongComponentInfoEx>(Ins.Values); }
    }

    IEnumerable<IStrongComponentInfoEx> IStrongComponentInfoEx.Outs
    {
      get { return new ConvertEnumerator<StrongComponentInfo, IStrongComponentInfoEx>(Outs.Values); }
    }

    public void Dump(TextWriter tw, Dictionary<IStrongComponentInfo, int> comps, ref int cnt)
    {
      foreach (StrongComponentInfo info in myOuts)
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
  }
}