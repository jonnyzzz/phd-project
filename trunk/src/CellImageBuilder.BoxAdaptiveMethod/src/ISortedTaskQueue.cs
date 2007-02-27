using System.Collections.Generic;
using DSIS.Core.Util;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod
{
  public interface ISortedTaskQueue
  {
    Pair<Point, Point> NextTask();
    bool HasNextTask { get; }
    void AddTask(double[] len, Pair<Point, Point> pt);

    IEnumerable<double[]> Overlaped { get; }
    IEnumerable<Pair<double[], Point>> NonProcessed { get; }

    void Clear();
  }
}