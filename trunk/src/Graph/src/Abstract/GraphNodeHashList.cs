using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Persistance;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  internal class GraphNodeHashList<TNode, TCell>
    where TCell : ICellCoordinate<TCell>
    where TNode : Node<TNode, TCell>
  {
    private static readonly IEqualityComparer<TCell> COMPARER = EqualityComparerFactory<TCell>.GetComparer();
    private readonly Item[] myItems;
    private readonly int myHashMax;

    public GraphNodeHashList(int capacity)
    {
      myHashMax = capacity;
      myItems = new Item[myHashMax];
    }

    public bool AddIfNotReplace(ref TNode t)
    {
      int index = t.HashCodeInternal%myHashMax;

      Item it = myItems[index];
      while (it != null)
      {
        if (it.Value.HashCodeInternal == t.HashCodeInternal && COMPARER.Equals(it.Value.Coordinate, t.Coordinate))
        {
          t = it.Value;
          return false;
        }
        it = it.NextItem;
      }

      it = new Item(t);
      it.NextItem = myItems[index];
      myItems[index] = it;

      return true;
    }

    public IEnumerable<TNode> Values
    {
      get
      {
        for (int i = 0; i < myItems.Length; i++)
        {
          Item t = myItems[i];
          while (t != null)
          {
            yield return t.Value;
            t = t.NextItem;
          }
        }
      }
    }

    private sealed class Item
    {
      public readonly TNode Value;
      public Item NextItem = null;

      public Item(TNode value)
      {
        Value = value;
      }
    }

    public void Save(ICellCoordinateSystem<TCell> ics, IBinaryWriter writer)
    {
      writer.WriteInt(myHashMax);
      foreach (Item item in myItems)
      {
        writer.WriteByte(1);
//        ics.SaveCoordinate(item.Value., writer);

      }
    }
  }
}