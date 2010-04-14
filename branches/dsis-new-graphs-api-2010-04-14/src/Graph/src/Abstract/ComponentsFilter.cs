using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Graph.Tarjan;
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
        return new ExactFilter(infos.First().ComponentId);
      }
      if (count <= 10)
      {
        return new ArrayFilter(infos.Map(x => x.ComponentId).ToArray());
      }
      return new HashSetFilter(new HashSet<uint>(infos.Map(x=>x.ComponentId)));
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
        return value > 0 && myData.Any(t => value == t);
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
      private readonly HashSet<uint> mySet;

      public HashSetFilter(HashSet<uint> set)
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

    public static IEnumerable<TNode> FilterUpper<TCell, TNode>(this IFilter filter, IEnumerable<TNode> nodes)
      where TNode : INode<TCell>
      where TCell : ICellCoordinate      
    {      
      //TODO: Return enumerable as is iff filter is AllFilter
      return nodes.Where(x => filter.Accept(x.ComponentId));
    }
  }
}