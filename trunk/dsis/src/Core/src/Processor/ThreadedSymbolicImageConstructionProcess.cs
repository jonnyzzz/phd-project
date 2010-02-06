using System;
using System.Collections.Generic;
using System.Threading;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Core.Processor
{
  public class ThreadedSymbolicImageConstructionProcess<TFrom, TTo> : ICellProcessor<TFrom, TTo>
    where TFrom : ICellCoordinate
    where TTo : ICellCoordinate
  {
    private readonly Mutex myReadMutex = new Mutex();
    private readonly Mutex myWriteMutex = new Mutex();
    private ICellProcessorContext<TFrom, TTo> myContext;

    public void Bind(ICellProcessorContext<TFrom, TTo> context)
    {
      myContext = context;
    }

    public void Execute(IProgressInfo info)
    {
      var workers = new List<Thread>();
      var cells = myContext.Cells.GetEnumerator();

      for (int i = 0; i < Math.Max(1,Environment.ProcessorCount); i++)
      {
        var worker = new Thread(()=>ThreadRun(cells)) {Name = ("SI construction thread " + (i + 1))};
        
        workers.Add(worker);
        worker.Start();
      }

      foreach (var worker in workers)
      {
        worker.Join();
      }
    }

    private void ThreadRun(IEnumerator<TFrom> cells)
    {
      const int cacheSize = 8192;

      using (var bld =
        new ThreadedCellConnectionBuilder<TTo>(myWriteMutex, myContext.CellImageBuilderContext.ConnectionBuilder, cacheSize))
      {
        ICellProcessorContext<TFrom, TTo> ctx = new CellProcessorContext<TFrom, TTo>(
          new CellCoordinateCollection<TFrom>(
            myContext.Converter.FromSystem,
            new BufferedThreadedCountEnumerable<TFrom>(
              myReadMutex,
              cells,
              Math.Max(1000, Math.Min(myContext.Cells.Count/Environment.ProcessorCount/4, cacheSize))
              )
            ),
          myContext.Converter.Clone(),
          myContext.CellImageBuilder.Clone(),
          new CellImageBuilderContext<TTo>(
            myContext.CellImageBuilderContext.Function,
            myContext.CellImageBuilderContext.Settings,
            myContext.CellImageBuilderContext.System,
            bld
            )
          );

        var ps = new SymbolicImageConstructionProcess<TFrom, TTo>();
        ps.Bind(ctx);

        ps.Execute(NullProgressInfo.INSTANCE);
      }
    }
  }
}