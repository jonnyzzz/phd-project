using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;

namespace DSIS.CodeCompiler
{
  //todo: Cleanup generated assemblies/sources
  internal class CodeCompilerImpl : ICodeCompiler
  {
    private static readonly object LOCK = new object();
    private readonly TypesToAssemblyCache myCache = new TypesToAssemblyCache();

    public Assembly CompileCSharpCode(string code, params Type[] referedTypes)
    {
      lock (LOCK)
      {
        CompilerParameters ps = new CompilerParameters();
        string[] assemblies = myCache.CollectAssemblies(referedTypes);
        ps.ReferencedAssemblies.AddRange(assemblies);
        ps.CompilerOptions = "/t:library /debug:pdbonly /optimize+";
        ps.GenerateInMemory = false ;
        ps.GenerateExecutable = false;
        ps.IncludeDebugInformation = true;
        ps.OutputAssembly = "DSIS.Generated.Assembly." + Guid.NewGuid() + ".dll";
        string codeFile = ps.OutputAssembly + ".cs";
        using(TextWriter tw = File.CreateText(codeFile))
        {
          tw.WriteLine(code);
        }

        using (CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp"))
        {
          CompilerResults results = provider.CompileAssemblyFromFile(ps, codeFile);

          if (results.Errors.Count != 0 || results.CompiledAssembly == null)
            throw new CodeCompilerException(results, code, assemblies);

          return results.CompiledAssembly;
        }
      }
    }
  }
}