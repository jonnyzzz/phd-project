/*
 * Created by: Eugene Petrenko
 * Created: 18 ������ 2006 �.
 */

using System;

namespace DSIS.Core.Util
{
  /// <summary>
  /// Asynchroniuse interface for progress callback.
  /// </summary>
  public interface IProgressInfo
  {
    double Minimum { get; set; }
    double Maximum { get; set; }
    double Value { get; set; }

    void Tick(double step);

    /// <summary>
    /// Indicates wether progress is supported by the method.
    /// By default the value if false.
    /// true if Stepping is supported.
    /// </summary>
    bool SupportsSteppingProgres { get; }

    bool IsInterrupted { get; }
  }
}