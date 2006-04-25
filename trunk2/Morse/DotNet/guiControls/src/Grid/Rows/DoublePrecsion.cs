namespace EugenePetrenko.Gui2.Controls.Grid.Rows
{
  /// <summary>
  /// Summary description for DoublePrecsion.
  /// </summary>
  public class DoublePrecsion : IExGridRow
  {
    private double[] data;
    private string caption;

    public DoublePrecsion(double[] data, string caption)
    {
      this.data = data;
      this.caption = caption;
    }

    public void SetValue(int index, double val)
    {
      data[index] = val;
    }

    public string this[int index]
    {
      get { return ExGridsParseUtil.DoubleToString(data[index]); }
      set
      {
        double v = ExGridsParseUtil.ParseDouble(value, index);
        if (v < 0) throw new ExGridCellException(index, "Value should be positive at {0}.");

        data[index] = v;
      }
    }

    public string Caption
    {
      get { return caption; }
    }

    public double[] Data
    {
      get { return data; }
    }
  }
}