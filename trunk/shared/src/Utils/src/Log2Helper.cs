namespace DSIS.Utils
{
  public static class Log2Helper
  {
    private static readonly int[] POWS;

    static Log2Helper()
    {
      POWS = new int[32];
      for (int i = 0; i < POWS.Length; i++)
      {
        POWS[i] = 1 << i;
      }
    }

    public static int Nearest(int v)
    {
      if (v == 0)
        return 1;
      if (v < 0)
        return Nearest(-v);

      int l = 0;
      int r = POWS.Length - 2;

      while (r - l > 1)
      {
        int c = (l + r) >> 1;
        if (POWS[c] < v)
        {
          l = c;
        }
        else
        {
          r = c;
        }
      }
      return r+1;
    }
  }
}