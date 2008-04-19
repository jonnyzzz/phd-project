namespace DSIS.Core.System
{
  /// <summary>
  /// Provide parameters of the system space. Only data 
  /// to be provided. 
  /// </summary>
  public interface ISystemSpace
  {
    int Dimension { get; }
    double[] AreaLeftPoint { get; }
    double[] AreaRightPoint { get; }
    long[] InitialSubdivision { get; }

    /// <summary>
    /// Checks if the point is contained in the investigation space, 
    /// proveded by ISystemSpace
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    bool Contains(double[] point);

    bool ContainsRect(double[] left, double[] right);
  }
}