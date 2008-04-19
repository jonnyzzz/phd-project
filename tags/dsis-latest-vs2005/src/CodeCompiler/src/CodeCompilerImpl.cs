using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using log4net;

namespace DSIS.CodeCompiler
{
  //todo: Cleanup generated assemblies/sources
  internal class CodeCompilerImpl : ICodeCompiler, IDisposable
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (CodeCompilerImpl));

    private static readonly object LOCK = new object();
    private readonly TypesToAssemblyCache myCache = new TypesToAssemblyCache();
    private readonly List<String> myFilesToRemove = new List<String>();

    public Assembly CompileCSharpCode(string code, params Type[] referedTypes)
    {
      lock (LOCK)
      {
        CompilerParameters ps = new CompilerParameters();
        string[] assemblies = myCache.CollectAssemblies(referedTypes);
        ps.ReferencedAssemblies.AddRange(assemblies);
        ps.CompilerOptions = "/t:library /debug:pdbonly /optimize+";
        ps.GenerateInMemory = false;
        ps.GenerateExecutable = false;
        ps.IncludeDebugInformation = true;
        string basePath = Path.GetDirectoryName(new Uri(GetType().Assembly.CodeBase).LocalPath);
        ps.OutputAssembly = Path.Combine(basePath, "DSIS.Generated.Assembly." + Guid.NewGuid() + ".dll");
        string codeFile = Path.Combine(basePath, ps.OutputAssembly + ".cs");
        using (TextWriter tw = File.CreateText(codeFile))
        {
          tw.WriteLine(code);
        }
        try
        {
          using (CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp"))
          {
            CompilerResults results = provider.CompileAssemblyFromFile(ps, codeFile);

            if (results.Errors.Count != 0 || results.CompiledAssembly == null)
              throw new CodeCompilerException(results, code, assemblies);

            return results.CompiledAssembly;
          }
        } finally
        {
          myFilesToRemove.Add(codeFile);
          string assembly = ps.OutputAssembly;
          myFilesToRemove.Add(assembly);
          string pdb =
            Path.Combine(Path.GetDirectoryName(assembly), Path.GetFileNameWithoutExtension(assembly) + ".pdb");
          if (File.Exists(pdb))
          {
            myFilesToRemove.Add(pdb);
          }
        }
      }
    }

    //todo: Register assembly resolver for newly created assembly.
    private void RegisterAssemblyResolver(string assemblyPath, string assemblyName)
    {
    }

    public void Dispose()
    {
      foreach (string file in myFilesToRemove)
      {
        try
        {
          File.SetAttributes(file, FileAttributes.Normal);
          File.Delete(file);
        } catch(Exception e)
        {
          LOG.Warn(e.Message, e);
        }
      }
    }
  }
}