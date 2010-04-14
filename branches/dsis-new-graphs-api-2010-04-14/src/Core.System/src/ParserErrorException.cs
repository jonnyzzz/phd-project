/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */

using System;

namespace DSIS.Core.System
{
  public class ParserErrorException : Exception
  {
    private int myLine;
    private int myCol;

    public ParserErrorException(string message, int myLine, int myCol) : base(message)
    {
      this.myLine = myLine;
      this.myCol = myCol;
    }

    public override string Message
    {
      get { return string.Format("{0}at line{1} col {2}", base.Message, myLine, myCol); }
    }
  }
}