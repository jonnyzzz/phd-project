using System;
using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.IntegerCoordinates;

namespace DSIS.SimpleRunner.imageEntropy
{
  internal class CoordinateConverter<QQ> : IIntegerCoordinateSystemWith
  {
    public Action<QQ, double[]> Convert { get; private set; }
    public Action<QQ, double[]> Convert2 { get; private set; }
    public Func<QQ, double, ImageColor> Convert3 { get; private set; }
    public Func<QQ, int[]> Cast{ get; private set; }

    public static CoordinateConverter<TCell> CreateCoordinatesConverter<TCell>(ICellCoordinateSystem<TCell> system)
      where TCell : ICellCoordinate
    {
      return new CoordinateConverter<TCell>().DoGeneric(system);
    }

    public static CoordinateConverter<TCell> CreateCoordinatesConverter<TCell>(IGraphMeasure<TCell> graphMeasure)
      where TCell : ICellCoordinate
    {
      return CreateCoordinatesConverter(graphMeasure.CoordinateSystem);
    }

    public static CoordinateConverter<TCell> CreateCoordinatesConverter<TCell>(IGraphStrongComponents<TCell> graphMeasure)
      where TCell : ICellCoordinate
    {
      return CreateCoordinatesConverter(graphMeasure.CoordinateSystem);
    }

    private CoordinateConverter<QQ> DoGeneric(ICellCoordinateSystem system)
    {
      ((IIntegerCoordinateSystem)system).DoGeneric(this);
      return this;
    }

    public void Do<T, Q>(T system)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
    {
      Convert = (q, p) => system.CenterPoint((Q) (object) q, p);
      Convert2 = (q, p) => system.TopLeftPoint((Q) (object) q, p);
      Cast = q =>
               {
                 var ds = new double[2];
                 system.TopLeftPoint((Q) (object) q, ds);
                 return new[] {(int) ds[0], (int) ds[1]};
               };
      Convert3 = (q, c) =>
                   {
                     var ds = new double[2];
                     system.TopLeftPoint((Q) (object) q, ds);
                     return new ImageColor((int) ds[0], (int) ds[1], c);
                   };
    }
  }
}