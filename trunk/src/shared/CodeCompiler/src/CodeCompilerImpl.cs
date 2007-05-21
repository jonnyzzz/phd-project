using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Utils;

namespace DSIS.CodeCompiler
{
  internal class CodeCompilerImpl : ICodeCompiler
  {
    public Assembly CompileCSharpCode(string code, params Type[] referedTypes)
    {
      Hashset<string> assemblies = new Hashset<string>();
      foreach (Type type in referedTypes)
      {
        Assembly assembly = type.Assembly;
        assemblies.Add(assembly.Location);
        foreach (AssemblyName name in assembly.GetReferencedAssemblies())
        {
          assemblies.Add(Assembly.Load(name).Location);
        }
      }

      CompilerParameters ps = new CompilerParameters();
      ps.ReferencedAssemblies.AddRange(new List<string>(assemblies.Values).ToArray());
      ps.CompilerOptions = "/t:library";
      ps.GenerateInMemory = true;
      ps.GenerateExecutable = false;
      ps.IncludeDebugInformation = true;
      ps.OutputAssembly = "DSIS.Generated.Assembly." + Guid.NewGuid();

      using (CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp"))
      {        
        CompilerResults results = provider.CompileAssemblyFromSource(ps, code);

        if (results.Errors.Count != 0 || results.CompiledAssembly == null)
          throw new CodeCompilerException(results);

        return results.CompiledAssembly;
      }
    }
  }
}