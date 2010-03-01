using System;
using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  internal class StrongComponentHash
  {
    public delegate int GenerationDelegate(StrongComponentInfo2 info);

    private readonly MultiHashDictionary<int, StrongComponentInfo2> myInfos =
      new MultiHashDictionary<int, StrongComponentInfo2>();

    private readonly OrderedList<int> myGenerations = new OrderedList<int>();
    private readonly Dictionary<int, long> myGenerationEvents;
    private readonly Dictionary<int, long> myProcessedEvents = new Dictionary<int, long>();

    public StrongComponentHash(Dictionary<int, long> generationEvents)
    {
      myGenerationEvents = generationEvents;
    }

    private UpdateCookie ShouldUpdate(int generation)
    {
      long id;
      if (myGenerationEvents.TryGetValue(generation, out id))
      {
        long pid;
        if (!myProcessedEvents.TryGetValue(generation, out pid) || pid < id)
        {
          return new UpdateCookie(this, generation, id);
        }
      }
      return null;
    }

    public void Add(StrongComponentInfo2 info)
    {
      if (!myInfos.ContainsKey(info.Generation))
        myGenerations.Add(info.Generation);

      myInfos.AddValue(info.Generation, info);
    }

    private bool UpdateComponents(IEnumerable<int> gens, ProcessComponent onUpdate, ProcessComponents onNoUpdate)
    {
      foreach (int g in gens)
      {
        UpdateCookie cookie = ShouldUpdate(g);
        if (cookie != null)
        {
          using (cookie)
          {
            var set = new HashSet<StrongComponentInfo2>();
            HashSet<StrongComponentInfo2> list = myInfos[g];
            bool found = false;
            foreach (StrongComponentInfo2 info2 in list)
            {
              var ex = (StrongComponentInfo2) info2.Reference;
              found |= onUpdate(g, ex);
              if (ex.Generation == g)
                set.Add(ex);
              else
                myInfos.AddValue(ex.Generation, ex);
            }
            if (set.Count > 0)
            {
              list.Clear();
              list.UnionWith(set);
            }
            else
            {
              myGenerations.Remove(g);
            }
            if (found)
              return true;
          }
        }
        else
        {
          if (onNoUpdate(g, myInfos[g]))
          {
            return true;
          }
        }
      }
      return false;
    }

    private static IEnumerable<StrongComponentInfo2> Intersect(HashSet<StrongComponentInfo2> i1,
                                                               HashSet<StrongComponentInfo2> i2)
    {
      var result = new List<StrongComponentInfo2>();
      if (i1.Count > i2.Count)
      {
        HashSet<StrongComponentInfo2> t = i1;
        i1 = i2;
        i2 = t;
      }

      foreach (StrongComponentInfo2 info2 in i1)
      {
        if (i2.Contains(info2))
          result.Add(info2);
      }
      return result;
    }

    public static HashSet<StrongComponentInfo2> Intersect(StrongComponentHash h1, StrongComponentHash h2)
    {
      h1.UpdateComponents(h1.myGenerations.Elements, delegate { return false; }, delegate { return false; });
      h2.UpdateComponents(h2.myGenerations.Elements, delegate { return false; }, delegate { return false; });

      IEnumerator<int> s1 = h1.myGenerations.Elements.GetEnumerator();
      IEnumerator<int> s2 = h1.myGenerations.Elements.GetEnumerator();
      bool hasElements = s1.MoveNext();
      hasElements &= s2.MoveNext();

      var set = new HashSet<StrongComponentInfo2>();

      if (!hasElements)
        return set;

      while (true)
      {
        if (s1.Current < s2.Current && !s1.MoveNext()) break;
        if (s1.Current > s2.Current && !s2.MoveNext()) break;

        IEnumerable<StrongComponentInfo2> @int = Intersect(h1.myInfos[s1.Current], h2.myInfos[s2.Current]);
        set.UnionWith(@int);

        if (!(s1.MoveNext() && s2.MoveNext()))
          break;
      }

      return set;
    }

    public bool Contains(StrongComponentInfo2 info)
    {
      if (myGenerations.IsLess(info.Generation))
        return false;

      IEnumerable<int> gens = myGenerations.Find(info.Generation);

      return UpdateComponents(gens,
                              (generation, comp) => comp == info,
                              delegate(int generation, HashSet<StrongComponentInfo2> comp)
                                {
                                  if (generation != info.Generation)
                                    return false;
                                  return comp.Contains(info);
                                });
    }

    public IEnumerable<IStrongComponentInfoEx> Elements
    {
      get
      {
        foreach (KeyValuePair<int, HashSet<StrongComponentInfo2>> info in myInfos)
        {
          foreach (StrongComponentInfo2 info2 in info.Value)
          {
            yield return info2;
          }
        }
      }
    }

    private delegate bool ProcessComponent(int generation, StrongComponentInfo2 comp);

    private delegate bool ProcessComponents(int generation, HashSet<StrongComponentInfo2> comp);

    private class UpdateCookie : IDisposable
    {
      private readonly StrongComponentHash myHash;
      private readonly long myChangeId;
      private readonly int myGeneration;

      public UpdateCookie(StrongComponentHash hash, int generation, long changeId)
      {
        myHash = hash;
        myChangeId = changeId;
        myGeneration = generation;
      }

      public void Dispose()
      {
        myHash.myProcessedEvents[myGeneration] = myChangeId;
      }
    }
  }
}