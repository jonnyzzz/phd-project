using System.Collections.Generic;
using DSIS.Core.Util;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod
{
  public interface ISortedTaskQueue
  {
    Pair<Point, Point> NextTask();
    bool HasNextTask { get; }
    void AddTask(double weight, Pair<Point, Point> pt);

    IEnumerable<Pair<double, Point>> NonProcessed { get; }

    void Clear();
  }
}