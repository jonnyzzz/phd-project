namespace DSIS.Function.UserDefined
{
  public class CodeError
  {
    public int Col { get; private set; }
    public int Row { get; private set; }
    public string Message { get; private set; }

    public CodeError(int col, int row, string message)
    {
      Col = col;
      Row = row;
      Message = message;
    }
  }
}