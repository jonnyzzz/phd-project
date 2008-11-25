using System;
using System.Collections.Generic;
using System.Reflection;
using Antlr.StringTemplate;
using DSIS.BoxIterators.Generator;
using DSIS.CodeCompiler;
using DSIS.Core.Ioc;
using DSIS.Spring;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates.Generated
{
  [UsedBySpring, ComponentImplementation]
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

      var dims = new List<int>();
      var dimAndPrime = new List<Pair<int, int>>();
      var dimAndNext = new List<Pair<int, int?>>();
      for (int i = 0; i < dim; i++)
      {
        dims.Add(i);
        dimAndPrime.Add(new Pair<int, int>(i, Primes.ByIndex(3*i)));
        dimAndNext.Add(new Pair<int, int?>(i, i + 1 < dim ? i + 1 : (int?) null));
      }


      var g = new StringTemplateGroup("foo",
                                      new EmbeddedResourceTemplateLoader(GetType().Assembly,
                                                                         "DSIS.IntegerCoordinates.src.Generated.Template"));
      StringTemplate template = g.GetInstanceOf("IntegerCoordinate");
      template.SetAttribute("Dimension", dim);
      template.SetAttribute("DimensionIt", dims);
      template.SetAttribute("DimensionItPair", dimAndPrime);
      template.SetAttribute("DimensionItNext", dimAndNext);
      template.SetAttribute("BoxIt", new ShennonFenoCodec(dim));

      return template.ToString();
    }


  }
}