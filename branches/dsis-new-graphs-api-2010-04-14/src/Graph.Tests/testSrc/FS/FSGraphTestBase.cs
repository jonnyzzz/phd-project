using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.FS;
using DSIS.Utils;

namespace DSIS.Graph.Tests.FS
{
  public class FSGraphTestBase : GenericGraphTestBase
  {
    public override IGraphBuilder<TCell> CreateBuilder<TCell>(ICellCoordinateSystem<TCell> system, ICellCoordinateSystemPersist<TCell> persist)
    {
      var res = new MemoryFSGraphResourceManagerImpl();

      res.OnStreamWritten += (s, n) => Console.Out.WriteLine("Stream({0}):\n{1}\n", n, s.ToArray().ToChunks(8).JoinString(b=>b.JoinString(bb=>bb< 10 ? "0" +bb : bb.ToString(), ","), "\n"));

      var obj = new FSGraphObjectManagerImpl(res);
      return new FSGraphBuilder<TCell>(persist, system, obj);
    }
  }
}