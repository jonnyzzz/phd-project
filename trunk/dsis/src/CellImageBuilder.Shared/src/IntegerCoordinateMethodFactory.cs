using System;
using System.Reflection;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils;

namespace DSIS.CellImageBuilder.Shared
{
  public abstract class CellImageBuilderIntegerCoordinateFactory<T> : ICellImageBuilderFactory
    where T : ICellImageBuilderIntegerCoordinatesSettings
  {
    public Type OptionsObjectType
    {
      get { return typeof (T); }
    }

    public string FactoryName { get; protected set;}

    public ICellImageBuilder<Q> CreateSystem<Q>(ICellImageBuilderSettings settings) 
      where Q : ICellCoordinate
    {
      if (!typeof(IIntegerCoordinate).IsAssignableFrom(typeof(Q)))
      {
        throw new ArgumentException("Integer coordinates are expected");
      }
      var method = GetType().GetMethod("CreateSystem2", BindingFlags.Static | BindingFlags.NonPublic);
      return (ICellImageBuilder<Q>) method.Invoke(null, new object[]{settings});
    }

    [Used("Reflection")]
    private static ICellImageBuilder<Q> CreateSystem2<Q>(ICellImageBuilderSettings settings) 
      where Q : IIntegerCoordinate
    {
      if (!typeof(IIntegerCoordinate).IsAssignableFrom(typeof(Q)))
      {
        throw new ArgumentException("Integer coordinates are expected");
      }
      return ((T) settings).Create<Q>();
    }
  }
}