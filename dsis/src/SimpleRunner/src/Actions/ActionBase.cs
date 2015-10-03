using System;
using System.Collections.Generic;
using System.Xml;
using DSIS.Core.Util;

namespace DSIS.SimpleRunner.Actions
{
  public abstract class ActionBase
  {
    private readonly List<ActionBase> myChildrenActions = new List<ActionBase>();
    private bool myCanAddAction = false;
    private XmlElement myElement = null;

    protected ActionBase()
    {
    }

    protected void SetElement(XmlElement element)
    {
      if (myCanAddAction)
        throw new ArgumentException("Unable to modify action collection during or after run");

      if (myElement != null)
        throw new ArgumentException("XmlElement has allready been set");

      myElement = element;
    }

    public void AddAction(ActionBase action)
    {
      if (myCanAddAction)
        throw new ArgumentException("Unable to modify action collection during or after run");

      if (myElement == null)
        throw new ArgumentException("Set XmlElement before adding actions");

      action.SetElement(AppendElement(myElement, action.Name));

      myChildrenActions.Add(action);
    }

    protected XmlElement Element
    {
      get { return myElement; }
    }


    public abstract string Name { get; }

    protected virtual void OnBeforeChildren(ActionBase children) {}
    protected virtual void OnAfterChildren(ActionBase children) {}

    protected virtual void OnBeforeRun() { }
    protected virtual void OnAfterRun() { }

    public void Run()
    {
      if (myCanAddAction)
        throw new ArgumentException("Unable to run again");
      
      if (myElement == null)
        throw new ArgumentException("Set XmlElement before adding actions");

      DateTime startTime = DateTime.Now;
      OnBeforeRun();
      try
      {
        for (int i = 0; i < myChildrenActions.Count; i++)
        {
          ActionBase action = myChildrenActions[i];
          OnBeforeChildren(action);
          try
          {
            action.Run();
          }
          finally
          {
            OnAfterChildren(action);
          }
        }
        myCanAddAction = true;
      }
      finally
      {
        OnAfterRun();

        TimeSpan time = DateTime.Now - startTime;

        AppendAttribute(Element, "total-time", time.TotalMilliseconds);
      }
    }


    private static void AppendAttribute(XmlNode element, string key, object value)
    {
      XmlAttribute attr = element.OwnerDocument.CreateAttribute(key);
      attr.Value = value.ToString();
      element.Attributes.Append(attr);
    }

    private static XmlElement AppendElement(XmlNode element, string name)
    {
      return (XmlElement)element.AppendChild(element.OwnerDocument.CreateElement(name));
    }
  }
}