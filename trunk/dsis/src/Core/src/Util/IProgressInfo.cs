/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */

using System;
using DSIS.Utils;

namespace DSIS.Core.Util
{
  public interface IProgressInfoLight : IDisposable
  {
    double Maximum { get; set; }

    void Tick(double step);

    bool IsInterrupted { get; }

    string Text { get; set; }    
  }

  /// <summary>
  /// Asynchroniuse interface for progress callback.
  /// </summary>
  public interface IProgressInfo : IProgressInfoLight
  {
    IProgressInfo SubProgress(double value);
  }

  public static class ProgressInfoHelpers
  {
    public static void CheckInterrupted(this IProgressInfoLight pi)
    {
      if (pi.IsInterrupted)
      {
        throw new ProcessInterruptedException();
      }
    }
  }
}