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

      for (int i = 0; i < Environment.ProcessorCount; i++)
      {
        var worker = new Thread(ThreadRun) {Name = ("SI construction thread " + (i + 1))};
        worker.Start(myContext);

        workers.Add(worker);
      }

      foreach (Thread worker in workers)
      {
        worker.Join();
      }
    }

    private void ThreadRun(object o)
    {
      using (var bld =
        new ThreadedCellConnectionBuilder<TTo>(myWriteMutex, myContext.CellImageBuilderContext.ConnectionBuilder, 8192))
      {
        ICellProcessorContext<TFrom, TTo> ctx = new CellProcessorContext<TFrom, TTo>(
          new CellCoordinateCollection<TFrom>(
            myContext.Converter.FromSystem,
            new BufferedThreadedCountEnumerable<TFrom>(
              myReadMutex,
              myContext.Cells,
              Math.Min(myContext.Cells.Count/Environment.ProcessorCount/4, 8192)
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