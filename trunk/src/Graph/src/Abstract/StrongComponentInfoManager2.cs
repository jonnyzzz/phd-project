using System;
using System.Collections.Generic;
using DSIS.Core.Util;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  internal class StrongComponentInfoManager2 : StrongComponentInfoManagerBase<StrongComponentInfo2>
  {
    private long myChangeId = 0;
    private Dictionary<int, long> myEvents = new Dictionary<int, long>();

    protected override void AddEdgeInternal(StrongComponentInfo2 from, StrongComponentInfo2 to)
    {
      from.OutsInternal.Add(to);
      to.InsInternal.Add(from);
    }

    protected override void MakeOneComponent(StrongComponentInfo2 info, IEnumerable<StrongComponentInfo2> set)
    {
      Hashset<int> changes = new Hashset<int>();
      foreach (StrongComponentInfo2 info2 in set)
      {
        myComponents.Remove(info2);
        changes.Add(info2.Generation);
        info2.Reference = info;
      }
      foreach (int change in changes)
      {
        myEvents[change] = myChangeId;
      }
      myChangeId++;
    }

    private static void AddExtension(StrongComponentHash to,
                                     StrongComponentHash from,
                                     Predicate<StrongComponentInfo2> minus)
    {
      foreach (StrongComponentInfo2 info in from.Elements)
      {
        if (!minus(info))
          to.Add(info);
      }
    }

    protected override void AddInsOutsExcept(StrongComponentInfo2 to, StrongComponentInfo2 from,
                                             Predicate<StrongComponentInfo2> except)
    {
      AddExtension(to.InsInternal, from.InsInternal, except);
      AddExtension(to.OutsInternal, from.OutsInternal, except);
    }


    protected override StrongComponentInfo2 CreateComponentInfo()
    {
      return new StrongComponentInfo2(myEvents);
    }

    protected override Pair<IEnumerable<StrongComponentInfo2>, Predicate<StrongComponentInfo2>> IntersectInOutAndThis(
      StrongComponentInfo2 fromIns, StrongComponentInfo2 toOuts)
    {
      Hashset<StrongComponentInfo2> hashset = StrongComponentHash.Intersect(fromIns.InsInternal, toOuts.OutsInternal);
      hashset.Add(fromIns);
      hashset.Add(toOuts);
      return new Pair<IEnumerable<StrongComponentInfo2>, Predicate<StrongComponentInfo2>>(hashset, hashset.Contains);
    }
  }
}