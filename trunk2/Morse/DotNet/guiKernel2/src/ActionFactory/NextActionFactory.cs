using System;
using System.Collections;
using System.Text;
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
        #region resovler

        public ActionWrapper[] NextAction(KernelNode node, ActionWrapper[] beforeActions)
        {
            return CreateInstances(FindActionInfosForPath(node, beforeActions));
        }

        public ActionWrapper[] NextAction(KernelNode node)
        {
            ActionStateRef[] infos = FindActionRefs(node);
            return CreateInstances(infos);
        }

        public ActionWrapper NextActionByName(KernelNode node, string name)
        {
            ActionRef info = this.actionResolver[name] as ActionRef;
            if (info == null) throw new ActionException("Action not found");

            if (!info.Constraint.Match(node.Results)) throw new ActionException("Action can not be applied here");

            return info.CreateInstance();
        }

        public ActionWrapper NextActionByName(KernelNode node, Type type)
        {
            return NextActionByName(node, type.Name);
        }


        private ActionStateRef[] FindActionRefs(KernelNode node)
        {
            ArrayList result = new ArrayList();
            foreach (ActionRef actionInfo in actions)
            {
                bool match = actionInfo.Constraint.Match(node.Results);
                ActionStateRef state = new ActionStateRef(actionInfo, match);
                if (match)
                {
                    Logger.LogMessage("Candidate Found: {0}", actionInfo);
                }
                result.Add(state);
            }
            return (ActionStateRef[]) result.ToArray(typeof (ActionStateRef));
        }

        public static void DumpInteraces(object o)
        {
            Type oType = o.GetType();
            Type resultType = typeof (IResult);

            Logger.LogMessage("Is IResult = {0}", o is IResult);

            Logger.LogMessage("CoreImplemets = {0}", Core.ImplemetsType(o, resultType));

            Logger.LogMessage("Has interface IResult = {0}", oType.GetInterface("IResult") != null);

            Logger.LogMessage("Supported interfaces of {0}:", oType.FullName);

            foreach (Type type in oType.GetInterfaces())
            {
                Logger.LogMessage("\t{0}", type.Name);
            }
            Logger.LogMessage("End intrface dump");
        }


        private ActionStateRef[] FindActionInfosForPath(KernelNode node, ActionWrapper[] beforeActions)
        {
            return FindActionInfosForPath(FindActionRefs(node), beforeActions);
        }

        private ActionStateRef[] FindActionInfosForPath(ActionStateRef[] acceptableActons, ActionWrapper[] selected)
        {
            if (selected.Length == 0) return acceptableActons;

            string nextActionName = selected[0].ActionMappingName;

            foreach (ActionStateRef actionStateInfo in acceptableActons)
            {
                if (!actionStateInfo.Enabled) continue;

                ActionRef actionInfo = actionStateInfo.ActionRef;
                if (string.Equals(actionInfo.ActionName, nextActionName))
                {
                    ActionWrapper[] dec = new ActionWrapper[selected.Length - 1];
                    for (int i = 1; i < selected.Length; i++)
                    {
                        dec[i - 1] = selected[i];
                    }
                    ArrayList refs = new ArrayList();
                    foreach (ActionRef rf in actionInfo.ActionRefs)
                    {
                        refs.Add(new ActionStateRef(rf, true));
                    }
                    return FindActionInfosForPath((ActionStateRef[]) refs.ToArray(typeof (ActionStateRef)) /*actionInfo.ActionRefs*/, dec);
                }
            }
            return new ActionStateRef[0];
        }

        public ActionWrapper[] CreateInstances(ActionStateRef[] infos)
        {
            ActionWrapper[] wrappers = new ActionWrapper[infos.Length];
            for (int i = 0; i < infos.Length; i++)
            {
                wrappers[i] = infos[i].CreateInstance();
            }
            return wrappers;
        }

        #endregion

        #region mapper

        private ArrayList actions = new ArrayList();
        private Hashtable actionResolver = new Hashtable();

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

        #endregion
    }
}