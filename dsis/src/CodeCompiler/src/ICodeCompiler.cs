using System;
using System.Reflection;

namespace DSIS.CodeCompiler
{
  public interface ICodeCompiler
  {    
    /// <summary>
    /// Compiles code written in <paramref name="code"/> with reference to 
    /// assemblies containing <paramref name="referedTypes"/>
    /// </summary>
    /// <param name="code">c# source code</param>
    /// <param name="referedTypes">types refered by generated code</param>
    /// <returns>built assebly from code and loaded to runtime</returns>
    Assembly CompileCSharpCode(string code, params Type[] referedTypes);
  }
}
