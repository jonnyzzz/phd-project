namespace DSIS.Utils
{
  public static class LongConverter
  {
    public static long FromBytes(byte[] buff)
    {
      return buff[0]
             + ((long)buff[1] << 8)
             + ((long)buff[2] << 16)
             + ((long)buff[3] << 24)
             + ((long)buff[4] << 32)
             + ((long)buff[5] << 40)
             + ((long)buff[6] << 48)
             + ((long)buff[7] << 56);
    }

    public static int Size
    {
      get { return 8; }
    }

    public static byte[] ToBytes(long position)
    {
      return new[]
               {
                 (byte)position, 
                 (byte)(position >> 8), 
                 (byte)(position >> 16), 
                 (byte)(position >> 24),
                 (byte)(position >> 32),
                 (byte)(position >> 40),
                 (byte)(position >> 48),
                 (byte)(position >> 56),
               };
    }

  }
}