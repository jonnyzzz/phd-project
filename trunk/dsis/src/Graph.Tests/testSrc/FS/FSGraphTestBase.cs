using System;
using System.IO;
using DSIS.Core.Coordinates;
using DSIS.Graph.FS;

namespace DSIS.Graph.Tests.FS
{
  public class FSGraphTestBase : GenericGraphTestBase
  {
    public override IGraphBuilder<TCell> CreateBuilder<TCell>(ICellCoordinateSystem<TCell> system, ICellCoordinateSystemPersist<TCell> persist)
    {
      var stream = new MemoryStream();
      var index = new IndexOutputStream(new MemoryStream());
      return new FSGraphBuilder<TCell>(persist, stream, index, system);
    }
  }
}