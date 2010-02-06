using System.Text;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates.Impl
{
  //todo: Why class? struct is cheaper for memory
  [EqualityComparer(typeof (IntegerCoordinateEqualityComparer))]
  public struct IntegerCoordinate : IIntegerCoordinate
  {
    public readonly long[] myCoordinate;

    public IntegerCoordinate(params long[] coordinare)
    {
      myCoordinate = coordinare;
    }
    
    public long GetCoordinate(int index)
    {
      return myCoordinate[index];
    }

    public int Dimension
    {
      get { return myCoordinate.Length; }
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      foreach (var l in myCoordinate)
      {
        sb.AppendFormat("{0}, ", l);
      }
      return "[" + sb + "]";
    }
  }
}