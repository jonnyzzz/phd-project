using System;
using System.Collections.Generic;
using System.Threading;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Core.Processor
{
  public class ThreadedSymbolicImageConstructionProcess<TFrom, TTo> : ICellProcessor<TFrom, TTo>
    where TFrom : ICellCoordinate<TFrom>
    where TTo : ICellCoordinate<TTo>
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
      List<Thread> workers = new List<Thread>();

      for(int i = 0; i < Environment.ProcessorCount; i++)
      {
        Thread worker = new Thread(ThreadRun);
        worker.Name = "SI construction thread " + (i + 1);
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
      using (ThreadedCellConnectionBuilder<TTo> bld =
        new ThreadedCellConnectionBuilder<TTo>(myWriteMutex, myContext.CellImageBuilderContext.ConnectionBuilder))
      {
        ICellProcessorContext<TFrom, TTo> ctx = new CellProcessorContext<TFrom, TTo>(
          new BufferedThreadedCountEnumerable<TFrom>(myReadMutex, myContext.Cells, Math.Min(myContext.Cells.Count / Environment.ProcessorCount / 4, 8192)),
          myContext.Converter.Clone(),
          myContext.CellImageBuilder.Clone(),
          new CellImageBuilderContext<TTo>(
            myContext.CellImageBuilderContext.Function,
            myContext.CellImageBuilderContext.Settings,
            myContext.CellImageBuilderContext.System,
            bld
            )
          );

        SymbolicImageConstructionProcess<TFrom, TTo> ps = new SymbolicImageConstructionProcess<TFrom, TTo>();
        ps.Bind(ctx);

        ps.Execute(NullProgressInfo.INSTANCE);
      }
    }
  }
}