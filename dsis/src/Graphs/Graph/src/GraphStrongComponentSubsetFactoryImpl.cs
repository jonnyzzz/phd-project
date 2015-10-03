using System.Collections.Generic;
using DSIS.Core.Coordinates;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.Graph
{
  [ComponentImplementation]
  public class GraphStrongComponentSubsetFactoryImpl : IGraphStrongComponentSubsetFactory
  {
    public IGraphStrongComponents SubComponents(IGraphStrongComponents components, IEnumerable<IStrongComponentInfo> subSet)
    {
      var w = new DoWith(this, subSet);
      components.DoGeneric(w);
      return w.Components;
    }

    private class DoWith : IGraphStrongComponentsWith
    {
      private readonly IGraphStrongComponentSubsetFactory myFactory;
      private readonly IEnumerable<IStrongComponentInfo> myEnum;

      public IGraphStrongComponents Components { get; private set; }

      public DoWith(IGraphStrongComponentSubsetFactory factory, IEnumerable<IStrongComponentInfo> @enum)
      {
        myFactory = factory;
        myEnum = @enum;
      }

      public void With<Q>(IGraphStrongComponents<Q> components) where Q : ICellCoordinate
      {
        Components = myFactory.SubComponents(components, myEnum);
      }
    }

    public IGraphStrongComponents<Q> SubComponents<Q>(IGraphStrongComponents<Q> components, IEnumerable<IStrongComponentInfo> subSet) where Q : ICellCoordinate
    {
      return new GraphStrongComponentsSubset<Q>(components, subSet);      
    }
  }
}