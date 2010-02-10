using System;
using System.Collections;
using System.Reflection;
using EugenePetrenko.Gui2.Kernell2.ActionFactory.ActionImpl;
using EugenePetrenko.Gui2.Kernell2.Actions;
using EugenePetrenko.Gui2.Logging;

namespace EugenePetrenko.Gui2.Kernell2.ActionFactory
{
  /// <summary>
  /// Summary description for ActionWrapperFactory.
  /// </summary>
  public class ActionWrapperFactory
  {
    private Hashtable mapping = new Hashtable(); //Type -> Typez

    public ActionWrapperFactory(Assembly[] assemblies)
    {
      foreach (Assembly assembly in assemblies)
      {
        foreach (Type type in assembly.GetTypes())
        {
          ActionMappingAttribute[] attributes =
            (ActionMappingAttribute[]) type.GetCustomAttributes(typeof (ActionMappingAttribute), false);
          if (attributes.Length > 1) throw new ActionWrapperFactoryException("Too much attributes for one class");

          foreach (ActionMappingAttribute attribute in attributes)
          {
            AddActionMapping(attribute, type);
          }
        }
      }
    }

    protected void AddActionMapping(ActionMappingAttribute attribute, Type type)
    {
      string name = attribute.ActionInterface.Name;
      if (mapping.ContainsKey(name))
        throw new ActionWrapperFactoryException("ActionWrapper was allready defined");

      mapping[name] = type;
      Logger.LogMessage("Found Action Mapping [interface = {0}, wrapper = {1}", name, type.Name);
    }

    protected Type GetWrapperType(string actionTypeName)
    {
      if (!mapping.ContainsKey(actionTypeName))
        throw new ActionWrapperFactoryException("No action Wrapper for " + actionTypeName);

      return (Type) mapping[actionTypeName];
    }


    public ActionWrapper CreateActionWrapper(string actionName, string actionCaption, bool isLeaf)
    {
      Type wrapperType = GetWrapperType(actionName);
      ConstructorInfo info = wrapperType.GetConstructor(new Type[] {typeof (string), typeof (bool)});
      return info.Invoke(new object[] {actionCaption, isLeaf}) as ActionWrapper;
    }

    private ActionWrapper CreateActionWrapper(Type actionType, string actionCaption, bool isLeaf)
    {
      return CreateActionWrapper(actionType.Name, actionCaption, isLeaf);
    }

    public ActionWrapper CreateDisabledAction(string caption, string detail)
    {
      IDisabledAction wrapper = (IDisabledAction) CreateActionWrapper(typeof (IDisabledActionInterface), caption, true);
      wrapper.SetComment(detail);
      return (ActionWrapper) wrapper;
    }

    public ActionWrapper CreateSeparator()
    {
      return CreateDisabledAction("--", null);
    }
  }
}