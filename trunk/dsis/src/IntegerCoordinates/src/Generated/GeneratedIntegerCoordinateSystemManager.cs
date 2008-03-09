using System;
using System.Collections.Generic;
using System.Reflection;
using Antlr.StringTemplate;
using DSIS.CodeCompiler;
using DSIS.Spring;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates.Generated
{
  [UsedBySpring]
  public class GeneratedIntegerCoordinateSystemManager
  {
    private static GeneratedIntegerCoordinateSystemManager myInstance;
    private readonly Dictionary<int, Type> myCachedIcs = new Dictionary<int, Type>();
    private readonly ICodeCompiler myCompiler;

    [Obsolete("Use spring")]
    public static GeneratedIntegerCoordinateSystemManager Instance
    {
      get
      {
        if (myInstance == null)
        {
          myInstance = new GeneratedIntegerCoordinateSystemManager(CodeCompiler.CodeCompiler.CreateCompiler());
        }
        return myInstance;
      }
    }

    public GeneratedIntegerCoordinateSystemManager(ICodeCompiler compiler)
    {
      myCompiler = compiler;
    }

    public IIntegerCoordinateFactoryEx CreateSystem(int dim)
    {
      lock (myCachedIcs)
      {
        Type t;
        if (!myCachedIcs.TryGetValue(dim, out t))
        {
          myCachedIcs[dim] = t = CreateType(dim);
        }
        return (IIntegerCoordinateFactoryEx) Activator.CreateInstance(t, new object[] {});
      }
    }

    private Type CreateType(int dim)
    {
      Assembly assembly = myCompiler.CompileCSharpCode(GenerateCoordinate(dim), typeof (IIntegerCoordinate),
                                                     typeof (EqualityComparerAttribute),
                                                     typeof (IIntegerCoordinateFactoryEx),
                                                     typeof (IIntegerCoordinateCallback));

      if (assembly == null)
      {
        throw new Exception("Failed to compile code. ");
      }

      return assembly.GetType("DSIS.Generated.IntegerCoordinateSystemFactory");
    }

    private string GenerateCoordinate(int dim)
    {
      if (dim <= 0)
        throw new ArgumentOutOfRangeException("dim");

      List<int> dims = new List<int>();
      List<Pair<int, int>> dimAndPrime = new List<Pair<int, int>>();
      for (int i = 0; i < dim; i++)
      {
        dims.Add(i);
        dimAndPrime.Add(new Pair<int, int>(i, Primes.ByIndex(3*i)));
      }


      StringTemplateGroup g =
        new StringTemplateGroup("foo",
                                new EmbeddedResourceTemplateLoader(GetType().Assembly,
                                                                   "DSIS.IntegerCoordinates.src.Generated.Template"));
      StringTemplate template = g.GetInstanceOf("IntegerCoordinate");
      template.SetAttribute("Dimension", dim);
      template.SetAttribute("DimensionIt", dims);
      template.SetAttribute("DimensionItPair", dimAndPrime);

      return template.ToString();
    }
  }
}