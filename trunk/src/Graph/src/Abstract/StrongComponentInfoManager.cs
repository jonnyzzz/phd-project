using System;
using System.Collections.Generic;
using DSIS.Core.Util;

namespace DSIS.Graph.Abstract
{
  internal class StrongComponentInfoManager : StrongComponentInfoManagerBase<StrongComponentInfo>,
                                              IStrongComponentInfoManager
  {
    protected override void AddEdgeInternal(StrongComponentInfo from, StrongComponentInfo to)
    {
      from.Outs.Add(to);
      to.Ins.Add(from);
    }


    protected override void AddInsOutsExcept(StrongComponentInfo to, StrongComponentInfo from,
                                             Predicate<StrongComponentInfo> except)
    {
      AddExtension(to.Ins, from.Ins, except);
      AddExtension(to.Outs, from.Outs, except);
    }


    protected override Pair<IEnumerable<StrongComponentInfo>, Predicate<StrongComponentInfo>> IntersectInOutAndThis(
      StrongComponentInfo fromIns, StrongComponentInfo toOuts)
    {
      Hashset<StrongComponentInfo, IStrongComponentInfo> s1 = fromIns.Ins;
      Hashset<StrongComponentInfo, IStrongComponentInfo> s2 = toOuts.Outs;

      Hashset<StrongComponentInfo, IStrongComponentInfo> infos =
        new Hashset<StrongComponentInfo, IStrongComponentInfo>();
      if (s1.Count > s2.Count)
      {
        Hashset<StrongComponentInfo, IStrongComponentInfo> t = s1;
        s1 = s2;
        s2 = t;
      }

      foreach (StrongComponentInfo info in s1)
      {
        if (s2.Contains(info))
          infos.Add(info);
      }
      infos.Add(fromIns);
      infos.Add(toOuts);
      return new Pair<IEnumerable<StrongComponentInfo>, Predicate<StrongComponentInfo>>(infos, infos.Contains);
    }

    private static void AddExtension(Hashset<StrongComponentInfo, IStrongComponentInfo> to,
                                     Hashset<StrongComponentInfo, IStrongComponentInfo> from,
                                     Predicate<StrongComponentInfo> minus)
    {
      foreach (StrongComponentInfo info in from)
      {
        if (!minus(info))
          to.Add(info);
      }
    }


    protected override void MakeOneComponent(StrongComponentInfo info, IEnumerable<StrongComponentInfo> set)
    {
      foreach (StrongComponentInfo sinfo in set)
      {
        myComponents.Remove(sinfo);
        sinfo.Reference = info;
      }
    }

    protected override StrongComponentInfo CreateComponentInfo()
    {
      return new StrongComponentInfo();
    }
  }
}