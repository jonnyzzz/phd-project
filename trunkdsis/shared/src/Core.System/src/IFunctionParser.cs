/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */

namespace DSIS.Core.System
{
  public interface IFunctionParser
  {
    /// <summary>
    /// Parses system definition. In case of parse error throws <see cref="ParserErrorException"/>
    /// </summary>
    /// <param name="input"></param>
    /// <returns> System information object as the result of parse</returns>
    /// <exception cref="ParserErrorException">Parse error ocured</exception>
    ISystemInfo ParseUserInput(string input);
  }
}