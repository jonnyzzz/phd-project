/*
 * Created by: Eugene Petrenko
 * Created: 18 ������ 2006 �.
 */

using System;

namespace DSIS.Core.System
{
  public class UnsupportedDevivateException : Exception
  {
    public UnsupportedDevivateException(string message) : base(message)
    {
    }
  }
}