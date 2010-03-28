namespace DSIS.Utils
{
  public static class LongConverter
  {
    public static long FromBytes(byte[] buff, int offset)
    {
      return buff[0 + offset]
             + (((long)buff[1 + offset]) << 8)
             + (((long)buff[2 + offset]) << 16)
             + (((long)buff[3 + offset]) << 24)
             + (((long)buff[4 + offset]) << 32)
             + (((long)buff[5 + offset]) << 40)
             + (((long)buff[6 + offset]) << 48)
             + (((long)buff[7 + offset]) << 56);
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