namespace EugenePetrenko.Gui2.Controls.Grid.Rows
{
  /// <summary>
  /// Summary description for IntPlusGridData.
  /// </summary>
  public class IntPlusGridData : IExGridRow
  {
    private int[] data;
    private string caption;

    public IntPlusGridData(string caption, int dimension) : this(caption, new int[dimension])
    {
      for (int i = 0; i < dimension; i++)
      {
        data[i] = 2;
      }
    }

    public IntPlusGridData(string caption, int[] data)
    {
      this.caption = caption;
      this.data = data;
    }

    public string this[int index]
    {
      get { return ExGridsParseUtil.IntToString(data[index]); }
      set
      {
        int v = ExGridsParseUtil.ParseInt(value, index);
        if (v < 0) throw new ExGridCellException(index, "Value should be positive at {0}.");

        data[index] = v;
      }
    }

    public string Caption
    {
      get { return caption; }
    }

    public int[] Data
    {
      get { return data; }
    }
  }
}