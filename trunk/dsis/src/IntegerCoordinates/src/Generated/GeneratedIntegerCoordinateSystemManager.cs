using System;
using System.Collections.Generic;
using System.Reflection;
using Antlr.StringTemplate;
using DSIS.CodeCompiler;
using DSIS.Core.System;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates.Generated
{
  public delegate T CreateSystem<T>(ISystemSpace ss, long[] subd);

  public interface IIntegerCoordinateCallback
  {
    void Do<T, Q>(CreateSystem<T> createSystem)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate;
  }

  public interface IIntegerCoordinateFactory
  {
    [Obsolete("Use IIntegerCoordinateSystem.DoWith")]
    void WithIntegerCoordinateSystem(IIntegerCoordinateCallback cb);

    Type System { get; }
    Type Coordinate { get; }
    IIntegerCoordinateSystemInfo Create(ISystemSpace space, long[] subd);
  }

  public class GeneratedIntegerCoordinateSystemManager
  {
    private static GeneratedIntegerCoordinateSystemManager myInstance;
    private readonly Dictionary<int, Type> myCachedIcs = new Dictionary<int, Type>();

    public static GeneratedIntegerCoordinateSystemManager Instance
    {
      get
      {
        if (myInstance == null)
        {
          myInstance = new GeneratedIntegerCoordinateSystemManager();
        }
        return myInstance;
      }
    }    

    public IIntegerCoordinateFactory CreateSystem(int dim)
    {
      lock (myCachedIcs)
      {
        Type t;
        if (!myCachedIcs.TryGetValue(dim, out t))
        {
          myCachedIcs[dim] = t = CreateType(dim);
        }
        return (IIntegerCoordinateFactory) Activator.CreateInstance(t, new object[] {});
      }
    }

    private Type CreateType(int dim)
    {
      ICodeCompiler compiler = CodeCompiler.CodeCompiler.CreateCompiler();
      Assembly assembly = compiler.CompileCSharpCode(GenerateCoordinate(dim), typeof (IIntegerCoordinate),
                                                     typeof (EqualityComparerAttribute),
                                                     typeof (IIntegerCoordinateFactory),
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