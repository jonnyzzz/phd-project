using System;
using DSIS.Core.Coordinates;
using DSIS.Persistance.Streams;
using DSIS.Utils;

namespace DSIS.Graph.FS
{
  public class FSReadonlyGraphHolder<TNode, TData, TCell> : IGraphDataHolder<TData, TNode>
    where TNode : FSReadonlyNode<TCell>
    where TCell : ICellCoordinate
  {
    private readonly BitSet myUsedMap = new BitSet();
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
      myPersister.SaveObject(myStream, data);
    }

    private void Pos(TNode node)
    {
      myStream.Position = node.Entry.EntryId*myPersister.Size;
    }

    public bool HasData(TNode node)
    {
      return myUsedMap.IsSet(node.Entry.EntryId);
    }
  }
}