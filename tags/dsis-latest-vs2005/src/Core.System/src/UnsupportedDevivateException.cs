/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
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