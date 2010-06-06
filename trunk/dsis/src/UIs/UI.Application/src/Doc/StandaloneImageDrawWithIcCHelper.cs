using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DSIS.Graph;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.UI.Application.Progress;
using DSIS.UI.UI;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.Application.Doc
{
  [TypeInstanciable]
  public class StandaloneImageDrawWithIcCHelper : ImageDrawingControl, ISymbolicImageDrawControl
  {
    private readonly IoCDrawSimbolicImage myHelper;
    private readonly IGraphStrongComponents myComponents;
    private readonly HashSet<IStrongComponentInfo> mySelection = new HashSet<IStrongComponentInfo>();
    private readonly ActionExecutorProgressAdapter myWrapper;
    private readonly Dictionary<ComponentKey, string> myCachedFiles = new Dictionary<ComponentKey, string>();
    private Size myCurrentSize;

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
      mySelection.UnionWith(component);
      myComponents = components;

      myWrapper = new ActionExecutorProgressAdapter(this, instance);
      Execution = myWrapper.Execution;
    }

    protected override string DrawImage(Size sz)
    {
      if (myCurrentSize != sz)
      {
        myCurrentSize = sz;
        lock (myCachedFiles)
        {
          myCachedFiles.Clear();
        }
      }

      string file;
      var key = new ComponentKey(mySelection);
      lock (myCachedFiles)
      {
        if (myCachedFiles.TryGetValue(key, out file))
        {
          return file;
        }
      }

      var ctx = new Context();
      ctx.ReplaceTypedGraphComponents(Factory.SubComponents(myComponents, mySelection));
      ctx.ReplaceTypedIntegerCoordinateSystem((IIntegerCoordinateSystem) myComponents.CoordinateSystem);

      file = myHelper.DrawImage(ctx, sz);
      lock (myCachedFiles)
      {
        return myCachedFiles[key] = file;
      }
    }

    public IEnumerable<IStrongComponentInfo> Components
    {
      get { return mySelection; }
      set
      {
        if (!mySelection.SetEquals(value))
        {
          mySelection.Clear();
          mySelection.UnionWith(value);
          ScheduleUpdate();
        }
      }
    }

    public Control Control
    {
      get { return myWrapper; }
    }

    private class ComponentKey : IEquatable<ComponentKey>
    {
      private readonly HashSet<IStrongComponentInfo> myComponents;

      public ComponentKey(IEnumerable<IStrongComponentInfo> components)
      {
        myComponents = new HashSet<IStrongComponentInfo>(components);
      }

      public bool Equals(ComponentKey obj)
      {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.myComponents.SetEquals(myComponents);
      }

      public override bool Equals(object obj)
      {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != typeof (ComponentKey)) return false;
        return Equals((ComponentKey) obj);
      }

      public override int GetHashCode()
      {
        return (myComponents != null ? myComponents.Count : 0);
      }

      public static bool operator ==(ComponentKey left, ComponentKey right)
      {
        return Equals(left, right);
      }

      public static bool operator !=(ComponentKey left, ComponentKey right)
      {
        return !Equals(left, right);
      }
    }
  }
}