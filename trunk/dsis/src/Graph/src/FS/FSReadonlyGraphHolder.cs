using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Persistance.Streams;
using DSIS.Utils;
using System.Linq;

namespace DSIS.Graph.FS
{
  public class FSReadonlyGraphHolder<TData, TCell> : IGraphDataHolder<TData, FSReadonlyNode<TCell>>
    where TCell : ICellCoordinate
  {
    private readonly BitSet myUsedMap = new BitSet();
    private readonly IInputOutputStream myStream;
    private readonly IFSObjectPersister<TData> myPersister;
    private readonly bool myCanDispose;
    private readonly Converter<FSReadonlyNode<TCell>, TData> myDef;
    private readonly FSReadonlyGraph<TCell> myReader;

    public FSReadonlyGraphHolder(IInputOutputStream stream, IFSObjectPersister<TData> persister, bool canDispose, Converter<FSReadonlyNode<TCell>, TData> def, FSReadonlyGraph<TCell> reader)
    {
      myStream = stream;
      myDef = def;
      myReader = reader;
      myPersister = persister;
      myCanDispose = canDispose;
    }

    public void Dispose()
    {
      if (myCanDispose)
        myStream.Dispose();
    }

    public TData GetData(FSReadonlyNode<TCell> node)
    {
      //Move pointer to right location
      if (!HasData(node))
        return myDef(node);
      return myPersister.LoadObject(myStream);
    }

    public void SetData(FSReadonlyNode<TCell> node, TData data)
    {
      Pos(node);
      myPersister.SaveObject(myStream, data);
    }

    private void Pos(FSReadonlyNode<TCell> node)
    {
      myStream.Position = node.Entry.EntryId*myPersister.Size;
    }

    public bool HasData(FSReadonlyNode<TCell> node)
    {
      return myUsedMap.IsSet(node.Entry.EntryId);
    }

    public IEnumerable<TData> Values
    {
      get
      {
        return myReader.NodesInternal.Where(HasData).Select(GetData);        
      }
    }
  }
}