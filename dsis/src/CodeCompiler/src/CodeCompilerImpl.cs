using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using EugenePetrenko.Shared.Core.Ioc.Api;
using log4net;
using Microsoft.CSharp;

namespace DSIS.CodeCompiler
{
  [ComponentImplementation]
  public class CodeCompilerImpl : ICodeCompiler, IDisposable
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (CodeCompilerImpl));

    private static readonly object LOCK = new object();
    private readonly TypesToAssemblyCache myCache = new TypesToAssemblyCache();
    private readonly List<String> myFilesToRemove = new List<String>();

    private readonly CodeCompilerFilenameGenerator myGenerator;

    public CodeCompilerImpl(CodeCompilerFilenameGenerator generator)
    {
      myGenerator = generator;
    }

    public Assembly CompileCSharpCode(string code, params Type[] referedTypes)
    {
      lock (LOCK)
      {
        var ps = new CompilerParameters();
        var assemblies = myCache.CollectAssemblies(referedTypes);
        ps.ReferencedAssemblies.AddRange(assemblies);
        ps.CompilerOptions = "/t:library /debug:pdbonly /optimize+";
        ps.GenerateInMemory = false;
        ps.GenerateExecutable = false;
        ps.IncludeDebugInformation = true;
        ps.OutputAssembly = myGenerator.GenerateName();
        var codeFile = ps.OutputAssembly + ".cs";
        using (TextWriter tw = File.CreateText(codeFile))
        {
          tw.WriteLine(code);
        }
        try
        {
          var providerOptions = new Dictionary<string, string> {{"CompilerVersion", "v4.0"}};
          using (var provider = new CSharpCodeProvider(providerOptions))
          {
            var results = provider.CompileAssemblyFromFile(ps, codeFile);

            if (results.Errors.Count != 0 || results.CompiledAssembly == null)
              throw new CodeCompilerException(results, code, assemblies);

            return results.CompiledAssembly;
          }
        } finally
        {
          myFilesToRemove.Add(codeFile);
          var assembly = ps.OutputAssembly;
          myFilesToRemove.Add(assembly);
          var pdb =
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
    }
  }
}