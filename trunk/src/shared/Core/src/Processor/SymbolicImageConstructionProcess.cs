using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Core.Processor
{
  public class SymbolicImageConstructionProcess<TFrom, TTo> : ICellProcessor<TFrom, TTo>
    where TFrom : ICellCoordinate<TFrom>
    where TTo : ICellCoordinate<TTo>
  {
    private CellProcessorContext<TFrom, TTo> myContext;

    public void Bind(CellProcessorContext<TFrom, TTo> context)
    {
      myContext = context;

      context.CellImageBuilder.Bind(context.CellImageBuilderContext);
    }

    public void Execute(IProgressInfo info)
    {
      info.Minimum = 0;
      info.Maximum = myContext.Cells.Count;

      foreach (TFrom cell in myContext.Cells)
      {
        info.Tick(1.0);
        if (info.IsInterrupted)
          throw new ProcessInterruptedException();

        foreach (TTo small in myContext.Converter.Subdivide(cell))
        {
          myContext.CellImageBuilder.BuildImage(small);
        }
      }
    }
  }
}