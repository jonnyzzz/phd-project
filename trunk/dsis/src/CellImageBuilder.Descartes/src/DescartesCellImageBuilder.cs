using System;
using System.Collections.Generic;
using System.Linq;
using Antlr.StringTemplate;
using DSIS.CodeCompiler;
using DSIS.Core.Builders;
using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;
using DSIS.Utils;

namespace DSIS.CellImageBuilder.Descartes
{
  [ComponentImplementation]
  public class DescartesCellImageBuilderFactory
  {
    private int myKeyCount;

    [Autowire]
    private ICodeCompiler CodeCompiler { get; set; }

    [Autowire]
    private GeneratedIntegerCoordinateFactory myIcsFactory { get; set; }

    [Autowire]
    private GeneratedIntegerCoordinateSystemManager IcsGenerator { get; set; }

    [Autowire]
    private ISystemSpaceFactory SystemSpaceFactory { get; set; }

    [Autowire]
    private ISubContainerFactory SubContainer { get; set; }

    private IEnumerable<Pair<IIntegerCoordinateFactoryEx, Descriptor>> AllocateSystems(ISystemSpace space,
                                                                                       IEnumerable<int> slices)
    {
      int from = 0;
      int id = 0;
      foreach (var slice in slices)
      {
        int to = from + slice;
        yield return CreateSystemSlice(id++, from, to);
        from += to;
      }
    }

    private Pair<IIntegerCoordinateFactoryEx, Descriptor> CreateSystemSlice(int id, int from, int to)
    {
      var len = to - from;

      var slice = IcsGenerator.CreateSystem(len);

      return Pair.Of(slice, BuildDescriptors(id, slice, from, to));
    }

    private static Descriptor BuildDescriptors(int idx, IIntegerCoordinateFactoryEx sys, int from, int to)
    {
      var keys = new List<Coord>();
      for (int i = from; i < to; i++)
      {
        keys.Add(new Coord {Index = i});
      }

      var descr = new Descriptor
                    {
                      Index = idx,
                      Coords = keys.ToArray(),
                      Type = GeneratorTypeUtil.GenerateFQTypeName(sys.System),
                      CellType = GeneratorTypeUtil.GenerateFQTypeName(sys.Coordinate),
                      BuilderType =
                        GeneratorTypeUtil.GenerateFQTypeInstance(typeof (ICellImageBuilder<>), sys.Coordinate),
                      FactoryType = GeneratorTypeUtil.GenerateFQTypeName(sys.GetType())
                    };

      return descr;
    }

    public ICellImageBuilder<Q> GenerateImageBuilder<T, Q>(T system, IEnumerable<int> slices)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
    {
      if (!system.IsGenerated)
      {
        throw new ArgumentException("Generated coordinate systems only", "system");
      }

      var spaces = AllocateSystems(system.SystemSpace, slices).ToArray();

      var g = new StringTemplateGroup("foo", new EmbeddedResourceTemplateLoader(GetType().Assembly,
                                                                                "DSIS.CellImageBuilder.Descartes.Template"));
      StringTemplate template = g.GetInstanceOf("Descartes");

      template.SetAttribute("Key", "gen_" + myKeyCount++ + "_" + slices.JoinString(x => "d" + x, "_"));
      template.SetAttribute("CellType", GeneratorTypeUtil.GenerateFQTypeName<Q>());
      template.SetAttribute("ICS", spaces.Select(x => x.Second).ToArray());
      template.SetAttribute("AttributeMarker", GeneratorTypeUtil.GenerateFQTypeName<TypeImpl>());

      var typeRefs = new List<Type>
                       {
                         typeof (Q),
                         typeof (T),
                         GetType(),
                         typeof (ICellImageBuilder<>)
                       };
      typeRefs.AddRange(spaces.Select(x => x.First.System));

      var assmbly = CodeCompiler.CompileCSharpCode(template.ToString(), typeRefs.ToArray());

        var scan = SubContainer.SubContainerNoScan<TypeImpl>(/*TODO*/);
      scan.ScanAssemblies(assmbly.Enum());
      return scan.GetComponent<ICellImageBuilder<Q>>();
    }

    [Used]
    public class Descriptor
    {
      [Used]
      public string Name
      {
        get { return "system_" + Index; }
      }

      [Used]
      public string FactoryType { get; set; }

      [Used]
      public string FactoryName
      {
        get { return "factory_" + Index; }
      }

      [Used]
      public string Type { get; set; }

      [Used]
      public string CellType { get; set; }

      [Used]
      public string BuilderType { get; set; }

      [Used]
      public string BuilderName
      {
        get { return "builder_" + Index; }
      }

      [Used]
      public int Index { get; set; }

      [Used]
      public Coord[] Coords { get; set; }

      [Used]
      public int Dimension
      {
        get { return Coords.Length; }
      }
    }

    [Used]
    public class Coord
    {
      [Used]
      public int Index { get; set; }

      [Used]
      public string BaseName
      {
        get { return "l" + Index; }
      }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class TypeImpl : ComponentImplementationAttributeBase
    {
    }
  }
}