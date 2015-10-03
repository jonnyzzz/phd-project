using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl
{
  public abstract class IntegerCoordinateComponentsActionBase : IntegerCoordinateSystemActionBase2
  {
    protected sealed override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      var list = new List<ContextMissmatchCheck>();
      list.AddRange(base.Check<T, Q>(system, ctx));

      if (ctx.ContainsKey(StrongComponents<Q>()))
      {
        list.AddRange(new CheckWithComponents<T, Q>(system, ctx, this).Apply(
          w => StrongComponents<Q>().Get(ctx).DoGeneric(w),
          x => x.Checks)
          );
      }
      else
      {
        list.Add(new ContextMissmatchCheckImpl<IReadonlyGraphStrongComponents<Q>>(this, StrongComponents<Q>(), "Context should contain strong components"));
      }

      return list;
    }

    private class CheckWithComponents<T,Q> : IReadonlyGraphStrongComponentsWith<Q>
      where Q : IIntegerCoordinate
      where T : IIntegerCoordinateSystem<Q>
    {
      private readonly T mySystem;
      private readonly Context myContext;
      private readonly IntegerCoordinateComponentsActionBase myComponents;

      public CheckWithComponents(T system, Context context, IntegerCoordinateComponentsActionBase components)
      {
        mySystem = system;
        myComponents = components;
        myContext = context;
      }

      public IEnumerable<ContextMissmatchCheck> Checks { get; private set; }
      
      public void With<TNode>(IReadonlyGraphStrongComponents<Q, TNode> components) where TNode : class, INode<Q>
      {
        Checks = myComponents.Check(mySystem, myContext, components);
      }
    }

    private static Key<IReadonlyGraphStrongComponents<Q>> StrongComponents<Q>()
      where Q : ICellCoordinate
    {
      return Keys.GetGraphComponents<Q>();
    }

    protected sealed override void Apply<T, Q>(T system, Context input, Context output)
    {
      StrongComponents<Q>().Get(input).DoGeneric(new ApplyWithComponents<T, Q>(system, input, output, this));
    }

    private class ApplyWithComponents<T, Q> : IReadonlyGraphStrongComponentsWith<Q>
      where Q : IIntegerCoordinate
      where T : IIntegerCoordinateSystem<Q>
    {
      private readonly T mySystem;
      private readonly Context myInputContext;
      private readonly Context myOutputContext;
      private readonly IntegerCoordinateComponentsActionBase myComponents;

      public ApplyWithComponents(T system, Context inputContext, Context outputContext, IntegerCoordinateComponentsActionBase components)
      {
        mySystem = system;
        myInputContext = inputContext;
        myOutputContext = outputContext;
        myComponents = components;
      }

      public void With<TNode>(IReadonlyGraphStrongComponents<Q, TNode> components) where TNode : class, INode<Q>
      {
        myComponents.Apply(mySystem, myInputContext, myOutputContext, components);
      }
    }

    protected abstract void Apply<T, Q, TNode>(T system, Context input, Context output,
                                               IReadonlyGraphStrongComponents<Q, TNode> components)
      where Q : IIntegerCoordinate
      where T : IIntegerCoordinateSystem<Q>
      where TNode : class, INode<Q>;

    protected virtual IEnumerable<ContextMissmatchCheck> Check<T, Q, TNode>(T system,
                                                                         Context ctx,
                                                                         IReadonlyGraphStrongComponents<Q, TNode>
                                                                           comps)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
      where TNode : class, INode<Q>
    {
      yield break;
    }
  }
}