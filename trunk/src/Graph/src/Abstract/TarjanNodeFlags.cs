using System;

namespace DSIS.Graph.Abstract
{
  [Flags]
  public enum TarjanNodeFlags : uint
  {
    IS_LOOP = 0x80000000,
    ROUTE =   0x40000000,
    STACK =   0x20000000,

    _MASK =   0x0FFFFFFF
  }
}