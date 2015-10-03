/*
 * Created by: Eugene Petrenko
 * Created: 18 ������ 2006 �.
 */

using System;

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
}