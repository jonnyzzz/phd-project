using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Ioc;

namespace DSIS.Graph
{
  [ComponentImplementation]
  public class GraphStrongComponentSubsetFactoryImpl : IGraphStrongComponentSubsetFactory
  {
    public IReadonlyGraphStrongComponents SubComponents(IReadonlyGraphStrongComponents components, IEnumerable<IStrongComponentInfo> subSet)
    {
      var w = new DoWith(this, subSet);
      components.DoGeneric(w);
      return w.Components;
    }

    private class DoWith : IReadonlyGraphStrongComponentsWith
    {
      private readonly IGraphStrongComponentSubsetFactory myFactory;
      private readonly IEnumerable<IStrongComponentInfo> myEnum;

      public IReadonlyGraphStrongComponents Components { get; private set; }

      public DoWith(IGraphStrongComponentSubsetFactory factory, IEnumerable<IStrongComponentInfo> @enum)
      {
        myFactory = factory;
        myEnum = @enum;
      }

      public void With<TCell, TNode>(IReadonlyGraphStrongComponents<TCell, TNode> components) where TCell : ICellCoordinate where TNode : class, INode<TCell>
      {
        Components = myFactory.SubComponents(components, myEnum).Upcast.Upcast;
      }
    }

    private class DoWith<TCell> : IReadonlyGraphStrongComponentsWith<TCell>
      where TCell : ICellCoordinate
    {
      private readonly IGraphStrongComponentSubsetFactory myFactory;
      private readonly IEnumerable<IStrongComponentInfo> myEnum;

      public IReadonlyGraphStrongComponents<TCell> Components { get; private set; }

      public DoWith(IGraphStrongComponentSubsetFactory factory, IEnumerable<IStrongComponentInfo> @enum)
      {
        myFactory = factory;
        myEnum = @enum;
      }

      public void With<TNode>(IReadonlyGraphStrongComponents<TCell, TNode> components) 
        where TNode : class, INode<TCell>
      {
        Components = myFactory.SubComponents(components, myEnum).Upcast;
      }
    }

    public IReadonlyGraphStrongComponents<Q> SubComponents<Q>(IReadonlyGraphStrongComponents<Q> components, IEnumerable<IStrongComponentInfo> subSet) 
      where Q : ICellCoordinate
    {
      var w = new DoWith<Q>(this, subSet);
      components.DoGeneric(w);
      return w.Components;
    }

    public IReadonlyGraphStrongComponents<Q,T> SubComponents<Q,T>(IReadonlyGraphStrongComponents<Q,T> components, IEnumerable<IStrongComponentInfo> subSet) 
      where Q : ICellCoordinate
      where T : class, INode<Q>
    {
      return new GraphStrongComponentsSubset<Q,T>(components, subSet);      
    }
  }
}