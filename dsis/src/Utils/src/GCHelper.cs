using System;

namespace DSIS.Utils
{
  public static class GCHelper
  {
    public static void Collect()
    {
      GC.Collect();
      GC.WaitForPendingFinalizers();
      GC.Collect();
      GC.WaitForPendingFinalizers();
    }    
  }
}