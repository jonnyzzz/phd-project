using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  internal abstract class StrongComponentInfoManagerBase<TCI> : IStrongComponentInfoManager
    where TCI : class, IStrongComponentInfoEx
  {
    protected Hashset<TCI, IStrongComponentInfo> myComponents = new Hashset<TCI, IStrongComponentInfo>();

    #region IStrongComponentInfoManager Members

    public void AddComponent(IStrongComponentInfo info)
    {
      myComponents.Add((TCI) info);
    }

    public IEnumerable<IStrongComponentInfo> Components
    {
      get { return myComponents.ValuesUpcasted; }
    }

    public int Count
    {
      get { return myComponents.Count; }
    }

    public IEnumerable<INode<TCellCoordinate>> FilterNodes<TCellCoordinate>(IEnumerable<IStrongComponentInfo> infos,
                                                                            IEnumerable
                                                                              <StrongComponentNode<TCellCoordinate>>
                                                                              nodes)
      where TCellCoordinate : ICellCoordinate<TCellCoordinate>
    {
      Predicate<IStrongComponentInfoEx> set = GetComponentFilter(infos);
      foreach (StrongComponentNode<TCellCoordinate> node in nodes)
      {
        if (set(node.StrongComponent))
          yield return node;
      }
    }

    IStrongComponentInfo IStrongComponentInfoManager.CreateComponentInfo()
    {
      return CreateComponentInfo();
    }

    public void OnConnection(IStrongComponentInfo from, IStrongComponentInfo to)
    {
      TCI toCast = (TCI) to;
      TCI fromCast = (TCI) from;

      if (HasArc(toCast, fromCast))
      {
        OnCircle(fromCast, toCast);
      }
      else
      {
        AddEdge(fromCast, toCast);
      }
    }

    #endregion

    protected abstract void AddEdgeInternal(TCI from, TCI to);
    protected abstract void MakeOneComponent(TCI info, IEnumerable<TCI> set);
    protected abstract void AddInsOutsExcept(TCI to, TCI from, Predicate<TCI> except);
    protected abstract TCI CreateComponentInfo();

    /// <summary>
    /// (From.Ins \cap To.Outs) \cup From \cup To
    /// </summary>
    /// <param name="fromIns"></param>
    /// <param name="toOuts"></param>
    /// <returns></returns>
    protected abstract Pair<IEnumerable<TCI>, Predicate<TCI>> IntersectInOutAndThis(TCI fromIns, TCI toOuts);

    protected static bool HasArc(TCI from, TCI to)
    {
      if (ReferenceEquals(from, to))
        return true;

      return to.InsContains(from);
    }

    protected void AddEdge(TCI from, TCI to)
    {
      if (ReferenceEquals(from, to))
        return;

      AddEdgeInternal(from, to);

      List<IStrongComponentInfoEx> fromIns = new List<IStrongComponentInfoEx>(from.Ins);
      List<IStrongComponentInfoEx> toOuts = new List<IStrongComponentInfoEx>(to.Outs);

      foreach (TCI infoFrom in fromIns)
      {
        foreach (TCI infoTo in toOuts)
        {
          AddEdgeInternal(infoFrom, infoTo);
        }
      }

      foreach (TCI info in fromIns)
      {
        AddEdgeInternal(info, to);
      }

      foreach (TCI info in toOuts)
      {
        AddEdgeInternal(from, info);
      }
    }

    protected void OnCircle(TCI from, TCI to)
    {
      TCI info = CreateComponentInfo();
      Pair<IEnumerable<TCI>, Predicate<TCI>> intersect = IntersectInOutAndThis(from, to);


      Hashset<TCI> tins = new Hashset<TCI>();
      Hashset<TCI> touts = new Hashset<TCI>();

      foreach (TCI si in intersect.First)
      {
        AddInsOutsExcept(info, si, intersect.Second);
        info.NodesCount += si.NodesCount;

        foreach (IStrongComponentInfoEx ex in si.Ins)
        {
          if (!intersect.Second((TCI) ex))
            tins.Add((TCI) ex);
        }

        foreach (IStrongComponentInfoEx ex in si.Outs)
        {
          if (!intersect.Second((TCI) ex))
            touts.Add((TCI) ex);
        }
      }

      foreach (TCI tin in tins)
      {
        foreach (TCI tout in touts)
        {
          AddEdgeInternal(tin, tout);
        }
      }

      MakeOneComponent(info, intersect.First);

      myComponents.Add(info);
    }

    protected static Predicate<IStrongComponentInfoEx> GetComponentFilter(IEnumerable<IStrongComponentInfo> infos)
    {
      Hashset<IStrongComponentInfoEx> set = new Hashset<IStrongComponentInfoEx>();
      foreach (TCI id in infos)
      {
        set.Add(id);
      }
      return set.Contains;
    }
  }
}