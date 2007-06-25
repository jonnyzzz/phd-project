using System;
using System.CodeDom.Compiler;
using System.Reflection;

namespace DSIS.CodeCompiler
{
  internal class CodeCompilerImpl : ICodeCompiler
  {
    private static readonly object LOCK = new object();
    private readonly TypesToAssemblyCache myCache = new TypesToAssemblyCache();

    public Assembly CompileCSharpCode(string code, params Type[] referedTypes)
    {
      lock (LOCK)
      {
        CompilerParameters ps = new CompilerParameters();
        ps.ReferencedAssemblies.AddRange(myCache.CollectAssemblies(referedTypes));
        ps.CompilerOptions = "/t:library /debug:pdbonly /optimize+";
        ps.GenerateInMemory = true;
        ps.GenerateExecutable = false;
        ps.IncludeDebugInformation = true;
        ps.OutputAssembly = "DSIS.Generated.Assembly." + Guid.NewGuid();

        using (CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp"))
        {
          CompilerResults results = provider.CompileAssemblyFromSource(ps, code);

          if (results.Errors.Count != 0 || results.CompiledAssembly == null)
            throw new CodeCompilerException(results, code);

          return results.CompiledAssembly;
        }
      }
    }
  }
}