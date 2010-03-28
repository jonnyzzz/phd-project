using DSIS.Core.Coordinates;
using DSIS.Graph.FS;

namespace DSIS.Graph.Tests.FS
{
  public class FSGraphTestBase : GenericGraphTestBase
  {
    public override IGraphBuilder<TCell> CreateBuilder<TCell>(ICellCoordinateSystem<TCell> system, ICellCoordinateSystemPersist<TCell> persist)
    {
      var res = new MemoryFSGraphResourceManagerImpl();
      var obj = new FSGraphObjectManagerImpl(res);
      return new FSGraphBuilder<TCell>(persist, system, obj);
    }
  }
}