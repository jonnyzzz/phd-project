using System.IO;
using DSIS.Core.System;

namespace DSIS.LineIterator
{
  public interface ILinePoint<Impl> where Impl : ILinePoint<Impl>
  {
    /// <summary>
    /// Computes image of that point
    /// </summary>
    /// <param name="function"></param>
    /// <returns></returns>
    Impl Compute(IFunction<double> function);

    Impl Middle(Impl point);

    double Distance(Impl point);

    double EuclidDistance(Impl point);

    void Save(TextWriter tw);

    int Dimension { get; }

    bool IsContained(ISystemSpace space);
  }
}