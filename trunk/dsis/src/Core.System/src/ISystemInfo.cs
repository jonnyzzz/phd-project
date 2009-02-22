/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */

using System;
using DSIS.Utils.Bean;

namespace DSIS.Core.System
{
  public enum SystemType
  {
    [IncludeValueAttribute(Title = "Continious")]
    Continious,
    [IncludeValueAttribute(Title = "Descrete")]
    Discrete
  }


  public interface ISystemInfoBase
  {
    SystemType Type { get; }

    Type[] SupportedFunctionTypes { get; }    
    
    string PresentableName { get; }

    int Dimension { get; }
  }

  [Obsolete("Remove It")]
  public interface ISystemInfoAndSpaceProvider : ISystemInfo
  {    
    ISystemSpace SystemSpace { get; }    
  }

  /// <summary>
  /// Represents descrete system's function of right hand
  /// </summary>
  public interface ISystemInfo : ISystemInfoBase
  {
    IFunction<T> GetFunction<T>(T[] precision);
  }

  public interface ISplittableSystemInfo
  {
    /// <summary>
    /// Returns projection of the system to coordinates range.
    /// That is applicable for projective space system.
    /// </summary>
    /// <returns>systen for coordinates [from, to] inclusive</returns>
    ISystemInfo ForRange(int from, int to);
  }
}