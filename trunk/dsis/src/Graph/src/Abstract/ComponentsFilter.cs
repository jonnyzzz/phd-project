using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  internal static class ComponentsFilter
  {
    private static readonly IFilter ALL_FILTER = new AllFilter();
    private static readonly IFilter DROP = new DropAllFilter();

    public static IFilter CreateFilter(IEnumerable<IStrongComponentInfo> componentIds, int allComponents)
    {
      var infos = new HashSet<TarjanComponentInfo>(componentIds.Cast<TarjanComponentInfo>());
      var count = infos.Count;
      if (count == 0)
      {
        return DROP;
      }
      if (count == allComponents)
      {
        return ALL_FILTER;
      }
      if (count == 1)
      {
        return new ExactFilter(infos.GetFirst().ComponentId);
      }
      if (count > 10)
      {
        var ids = new Hashset<uint>();
        foreach (TarjanComponentInfo id in infos)
        {
          ids.Add(id.ComponentId);
        }
        return new HashSetFilter(ids);
      }
      var data = new uint[count];
      int cnt = 0;
      foreach (TarjanComponentInfo id in infos)
      {
        data[cnt++] = id.ComponentId;
      }
      return new ArrayFilter(infos.Map(x=>x.ComponentId).ToArray());
    }

    private class AllFilter : IFilter
    {
      public bool Accept(uint value)
      {
        return value > 0;
      }
    }

    private class ArrayFilter : IFilter
    {
      private readonly uint[] myData;

      public ArrayFilter(uint[] data)
      {
        myData = data;
      }

      public bool Accept(uint value)
      {
        if (value <= 0)
          return false;

        for (int i = 0; i < myData.Length; i++)
        {
          if (value == myData[i])
            return true;
        }
        return false;
      }
    }

    private class DropAllFilter : IFilter
    {
      public bool Accept(uint value)
      {
        return false;
      }
    }

    private class ExactFilter : IFilter
    {
      private readonly uint myValue;

      public ExactFilter(uint value)
      {
        myValue = value;
      }

      public bool Accept(uint value)
      {
        return value == myValue;
      }
    }

    private class HashSetFilter : IFilter
    {
      private readonly Hashset<uint> mySet;

      public HashSetFilter(Hashset<uint> set)
      {
        mySet = set;
      }

      public bool Accept(uint value)
      {
        return mySet.Contains(value);
      }
    }

    public interface IFilter
    {
      bool Accept(uint value);
    }

    public static IEnumerable<INode<TCell>> FilterUpper<TCell>(this IFilter filter, IEnumerable<INode<TCell>> nodes)
      where TCell : ICellCoordinate      
    {      
      return nodes.Filter(x => filter.Accept(x.ComponentId));
    }
  }
}