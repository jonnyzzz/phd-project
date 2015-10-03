using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Core.Processor
{
  public class SymbolicImageConstructionProcess<TFrom, TTo> : ICellProcessor<TFrom, TTo>
    where TFrom : ICellCoordinate
    where TTo : ICellCoordinate
  {
    private ICellProcessorContext<TFrom, TTo> myContext;

    public void Bind(ICellProcessorContext<TFrom, TTo> context)
    {
      myContext = context;

      context.CellImageBuilder.Bind(context.CellImageBuilderContext);
    }

    public void Execute(IProgressInfo info)
    {
      info.Maximum = myContext.Cells.Count;
      var builder = myContext.CellImageBuilder;
      var converter = myContext.Converter;

      foreach (TFrom cell in myContext.Cells)
      {
        info.Tick(1.0);
        if (info.IsInterrupted)
          throw new ProcessInterruptedException();
        
        foreach (TTo small in converter.Subdivide(cell))
        {
          builder.BuildImage(small);
        }
      }
    }
  }
}