namespace DSIS.Utils
{
  public static class Log2Helper
  {
    public static int Nearest(int v)
    {
      if (v == 0)
        return 1;
      if (v < 0)
        return Nearest(-v);

      int r = 2;
      while ((v >>= 1) > 0) r++;

      return r;      
    }
  }
}