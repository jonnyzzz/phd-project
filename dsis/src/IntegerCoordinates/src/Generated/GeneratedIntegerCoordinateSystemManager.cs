using System;
using System.Collections.Generic;
using System.Reflection;
using Antlr.StringTemplate;
using DSIS.BoxIterators.Generator;
using DSIS.CodeCompiler;
using DSIS.Core.Ioc;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates.Generated
{
  [ComponentImplementation]
  public class GeneratedIntegerCoordinateSystemManager
  {
    private static int ourGeneragedInstanceCount;
    private static GeneratedIntegerCoordinateSystemManager myInstance;
    private readonly Dictionary<string, Type> myCachedIcs = new Dictionary<string, Type>();
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

    public IIntegerCoordinateFactoryEx CreateSystem(int dim, string type)
    {
      string key = string.Format("<{0}>!{1}", dim, type);
      lock (myCachedIcs)
      {
        Type t;
        if (!myCachedIcs.TryGetValue(key, out t))
        {
          myCachedIcs[key] = t = CreateType(dim, type);
        }
        return (IIntegerCoordinateFactoryEx) Activator.CreateInstance(t, new object[] {});
      }
    }

    private Type CreateType(int dim, string type)
    {
      string key;
      Assembly assembly = myCompiler.CompileCSharpCode(GenerateCoordinate(dim, type, out key), typeof (IIntegerCoordinate),
                                                     typeof (EqualityComparerAttribute),
                                                     typeof (IIntegerCoordinateFactoryEx),
                                                     typeof (IIntegerCoordinateCallback));

      if (assembly == null)
      {
        throw new Exception("Failed to compile code. ");
      }

      return assembly.GetType("DSIS.Generated.IntegerCoordinateSystemFactory" + key);
    }

    private string GenerateCoordinate(int dim, string type, out string key)
    {
      if (dim <= 0)
        throw new ArgumentOutOfRangeException("dim");

      var dims = new List<int>();
      var dimAndPrime = new List<Pair<int, int>>();
      var dimAndNext = new List<Pair<int, int?>>();
      for (int i = 0; i < dim; i++)
      {
        dims.Add(i);
        dimAndPrime.Add(new Pair<int, int>(i, Primes.ByIndex(33*i + i)));
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
      template.SetAttribute("Key", key = "_d" + dim + "_" + ++ourGeneragedInstanceCount + "_" + type);
      template.SetAttribute("JInt", type);

      return template.ToString();
    }


  }
}