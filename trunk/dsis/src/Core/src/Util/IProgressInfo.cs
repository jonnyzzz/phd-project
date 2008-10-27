/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */

namespace DSIS.Core.Util
{
  public interface IProgressInfoLight
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