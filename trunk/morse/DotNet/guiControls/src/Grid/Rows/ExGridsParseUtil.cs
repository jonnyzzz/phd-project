using System;

namespace EugenePetrenko.Gui2.Controls.Grid.Rows
{
  /// <summary>
  /// Summary description for ExGridsParseUtil.
  /// </summary>
  public class ExGridsParseUtil
  {
    public static double ParseDouble(string value, int index)
    {
      try
      {
        return Double.Parse(value);
      }
      catch (FormatException)
      {
        throw new ExGridCellException(index, "Number is in incorect format at {0}.");
      }
      catch (OverflowException)
      {
        throw new ExGridCellException(index, "Number is too much at {0}.");
      }
    }

    public static string DoubleToString(double v)
    {
      return v.ToString();
    }

    public static int ParseInt(string value, int index)
    {
      try
      {
        return Int32.Parse(value);
      }
      catch (FormatException)
      {
        throw new ExGridCellException(index, "Number is in  incorect format at {0}.");
      }
      catch (OverflowException)
      {
        throw new ExGridCellException(index, "Number is too much at {0}.");
      }
    }

    public static string IntToString(int v)
    {
      return v.ToString();
    }
  }
}