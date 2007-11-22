using System;
using System.Collections;
using System.Text;
using EugenePetrenko.Gui2.Kernell2.ActionFactory.ActionImpl;
using EugenePetrenko.Gui2.Kernell2.ActionFactory.ActionInfos;
using EugenePetrenko.Gui2.Kernell2.Actions;
using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.Logging;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Kernell2.ActionFactory
{
  /// <summary>
  /// Summary description for NextActionFactory.
  /// </summary>
  public class NextActionFactory
  {
    #region Action By Name

    public ActionWrapper NextActionByName(KernelNode node, Type type)
    {
      return NextActionByName(node, type.Name);
    }

    private ActionWrapper NextActionByName(KernelNode node, string name)
    {
      ActionRef info = actionResolver[name] as ActionRef;
      if (info == null) throw new ActionException("Action not found");

      if (!info.Constraint.Match(node.Results))
        throw new ActionException("Action can not be applied here");

      return info.CreateInstance();
    }

    #endregion

    public void CreateActionInstances()
    {
      foreach (ActionRef actionRef in actions)
      {
        CreateActionInstances(actionRef);
      }
    }

    private static void CreateActionInstances(ActionRef actionRef)
    {
      actionRef.CreateInstance();
      foreach (ActionRef ar in actionRef.ActionRefs)
      {
        CreateActionInstances(ar);
      }
    }

    public ActionRef[] GetActions()
    {
      return (ActionRef[]) actions.ToArray(typeof (ActionRef));
    }

    #region mapper

    private ArrayList actions = new ArrayList();
    private Hashtable actionResolver = new Hashtable();

    public static readonly string SEPARATOR_ACTION = typeof (ISeparatorAction).Name;

    public void RegisterAction(ActionRef info)
    {
      actions.Add(info);
      actionResolver[info.ActionName] = info;
    }

    #endregion

    #region toStrings+ debugging

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("NextActionFactory :\n");

      foreach (ActionRef actionRef in actions)
      {
        sb.AppendFormat("\tRegistered Action : {0} \n", actionRef.ToString());
      }

      return sb.ToString();
    }

    public static void DumpInteraces(object o)
    {
      Type oType = o.GetType();
      Type resultType = typeof (IResult);

      Logger.LogMessage("Is IResult = {0}", o is IResult);

      Logger.LogMessage("CoreImplemets = {0}", Core.Instance.TypeFinder.ImplementsType(o, resultType));

      Logger.LogMessage("Has interface IResult = {0}", oType.GetInterface("IResult") != null);

      Logger.LogMessage("Supported interfaces of {0}:", oType.FullName);

      foreach (Type type in oType.GetInterfaces())
      {
        Logger.LogMessage("\t{0}", type.Name);
      }
      Logger.LogMessage("End intrface dump");
    }

    #endregion
  }
}