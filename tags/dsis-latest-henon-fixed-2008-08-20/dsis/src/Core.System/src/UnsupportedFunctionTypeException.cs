/*
 * Created by: Eugene Petrenko
 * Created: 18 ������ 2006 �.
 */

using System;

namespace DSIS.Core.System
{
  public class UnsupportedFunctionTypeException : Exception
  {
    public UnsupportedFunctionTypeException(string message) : base(message)
    {
    }
  }
}