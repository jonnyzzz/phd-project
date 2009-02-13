using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.Graph;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.UI.Application.Progress;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc
{
  [TypeInstanciable]
  public class StandaloneImageDrawWithIcCHelper : ImageDrawingControl, ISymbolicImageDrawControl
  {
    private readonly IoCDrawSimbolicImage myHelper;
    private readonly IGraphStrongComponents myComponents;

    private readonly HashSet<IStrongComponentInfo> myComponent = new HashSet<IStrongComponentInfo>();

    private readonly ActionExecutorProgressAdapter myWrapper;

    [Autowire]
    private IGraphStrongComponentSubsetFactory Factory { get; set; }

    //TODO: Fix IInvocator
    //TODO: Fix ActionExecution
    public StandaloneImageDrawWithIcCHelper(IInvocator invocator, 
      IoCDrawSimbolicImage helper,
      ITypeInstantiator instance,
                                            IEnumerable<IStrongComponentInfo> component, 
      IGraphStrongComponents components)
      : base(invocator)
    {      
      myHelper = helper;
      myComponent.UnionWith(component);
      myComponents = components;

      myWrapper = new ActionExecutorProgressAdapter(this, instance);
      Execution = myWrapper.Execution;
    }

    protected override string DrawImage(Size sz)
    {
      var ctx = new Context();
      ctx.ReplaceTypedGraphComponents(Factory.SubComponents(myComponents, myComponent));
      ctx.ReplaceTypedIntegerCoordinateSystem((IIntegerCoordinateSystem) myComponents.CoordinateSystem);

      return myHelper.DrawImage(ctx, sz);
    }

    public IEnumerable<IStrongComponentInfo> Components
    {
      get { return myComponent; }
      set
      {
        if (!myComponent.SetEquals(value))
        {
          myComponent.Clear();
          myComponent.UnionWith(value);
          ScheduleUpdate();
        }
      }
    }

    public Control Control
    {
      get { return myWrapper; }
    }
  }
}