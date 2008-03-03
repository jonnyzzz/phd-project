using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Core.Processor
{
  public class UnsymmetricSymbolicImageProcess<T> : ICellProcessor<T>, ICellProcessor<T,T>
    where T: ICellCoordinate
  {
    private readonly ICellProcessor<T, T> myProcessor = new SymbolicImageConstructionProcess<T, T>();
    private ICellProcessorMultiplyContext<T> myContext;

    public void Bind(ICellProcessorContext<T, T> context)
    {
      Bind((ICellProcessorMultiplyContext<T>)context);
    }

    public void Bind(ICellProcessorMultiplyContext<T> context)
    {
      myContext = context;
    }

    public void Execute(IProgressInfo info)
    {
      List<long[]> steps = new List<long[]>(SubdividePart(myContext.Division));
      
//      SubdevideCellProcessorContext<T> ctx = new SubdevideCellProcessorContext<T>(myContext.);

    }

    private static IEnumerable<long[]> SubdividePart(long[] div)
    {
      for (int step = 0; step < div.Length; step++)
      {
        long d = div[step];
        if (d > 1)
        {
          long[] part = new long[div.Length];
          for (int i = 0; i < part.Length; i++)
          {
            part[i] = i == step ? d : 1;
          }
          yield return part;
        }
      }      
    }
  }
}