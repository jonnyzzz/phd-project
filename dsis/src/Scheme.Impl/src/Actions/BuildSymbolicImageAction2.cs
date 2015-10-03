using DSIS.CellImageBuilder.Shared;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions
{
  public class BuildSymbolicImageAction2 : BuildSymbolicImageActionBase
  {
    private readonly long[] mySubdivision;
    private readonly ICellImageBuilderIntegerCoordinatesSettings myCellImageBuilder;

    public BuildSymbolicImageAction2(long[] subdivision, ICellImageBuilderIntegerCoordinatesSettings cellImageBuilder)
    {
      mySubdivision = subdivision;
      myCellImageBuilder = cellImageBuilder;
    }

    protected override ICellImageBuilderIntegerCoordinatesSettings GetCellImageBuilderSettings(Context input)
    {
      return myCellImageBuilder;
    }

    protected override long[] GetSubdivision(Context input)
    {
      return mySubdivision;
    }
  }
}