using System;
using DSIS.Core.Coordinates;
using DSIS.Persistance.Streams;

namespace DSIS.Graph.FS
{
  public class FSReadonlyGraphHolder<TNode, TData, TCell> : IGraphDataHolder<TData, TNode>
    where TNode : FSReadonlyNode<TCell>
    where TCell : ICellCoordinate
  {
    private readonly byte[] OBJECT_MARKER = new[] {(byte) 42};
    private readonly IInputOutputStream myStream;
    private readonly IFSObjectPersister<TData> myPersister;
    private readonly bool myCanDispose;
    private readonly Converter<TNode, TData> myDef;

    public FSReadonlyGraphHolder(IInputOutputStream stream, IFSObjectPersister<TData> persister, bool canDispose, Converter<TNode, TData> def)
    {
      myStream = stream;
      myDef = def;
      myPersister = persister;
      myCanDispose = canDispose;
    }

    public void Dispose()
    {
      if (myCanDispose)
        myStream.Dispose();
    }

    public TData GetData(TNode node)
    {
      //Move pointer to right location
      if (!HasData(node))
        return myDef(node);
      return myPersister.LoadObject(myStream);
    }

    public void SetData(TNode node, TData data)
    {
      Pos(node);
      myStream.Write(OBJECT_MARKER, 0, OBJECT_MARKER.Length);
      myPersister.SaveObject(myStream, data);
    }

    private void Pos(TNode node)
    {
      myStream.Position = node.Entry.EntryId*myPersister.Size;
    }

    public bool HasData(TNode node)
    {
      //Use bitset in-memory
      Pos(node);

      var b = new byte[OBJECT_MARKER.Length];
      myStream.Read(b, 0, b.Length);
      
      for (int i = 0; i < b.Length; i++)
      {
        if (b[i] != OBJECT_MARKER[i]) return false;
      }
      return true;
    }
  }
}