using System;
using DSIS.Core.Builders;
using DSIS.Core.Concurrent;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Core.Processor
{
  public class ThreadedSymbolicImageConstructionProcess<TFrom, TTo> : ICellProcessor<TFrom, TTo>
    where TFrom : ICellCoordinate<TFrom>
    where TTo : ICellCoordinate<TTo>
  {
    private CellProcessorContext<TFrom, TTo> myContext;


    public void Bind(CellProcessorContext<TFrom, TTo> context)
    {
      throw new NotImplementedException();
    }

    public void Execute(IProgressInfo info)
    {
      
      throw new NotImplementedException();
    }


    private void ThreadRun(object o)
    {
      SynchQueue<TTo> queue = (SynchQueue<TTo>) o;

      ICellImageBuilder<TTo> builder = myContext.CellImageBuilder.Clone();

      while(true)
      {
        queue.WaitData();
        TTo to = queue.Dequeue();

      }

    }
  }
}