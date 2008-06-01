namespace DSIS.Utils
{
  public class LinkedList<T>
  {
    private Item myRoot;
    private Item myLast;

    public void AddFront(T data)
    {
      var item = new Item(myRoot, data);
      
      if (myRoot == null)
        myLast = item;

      myRoot = item;
    }

    public T RemoveFront()
    {
      T result = myRoot.Data;
      myRoot = myRoot.Next;
      if (myRoot == null)
        myLast = null;
      return result;
    }

    public void AddLast(T data)
    {
      if (myLast == null)
      {
        AddFront(data);
      } else
      {
        myLast = myLast.Next = new Item(null, data);
      }
    }

    public bool IsEmpty
    {
      get
      {
        return myRoot == null;
      }
    }
    
    private class Item
    {
      public Item Next;
      public readonly T Data;

      public Item(Item next, T data)
      {
        Next = next;
        Data = data;
      }
    }
  }
}