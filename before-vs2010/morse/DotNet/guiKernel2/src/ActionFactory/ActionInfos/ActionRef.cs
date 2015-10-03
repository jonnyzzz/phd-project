using System.Collections;
using System.Text;
using EugenePetrenko.Gui2.Kernell2.Actions;
using EugenePetrenko.Gui2.Kernell2.Constraints;
using EugenePetrenko.Gui2.Kernell2.Container;

namespace EugenePetrenko.Gui2.Kernell2.ActionFactory.ActionInfos
{
  /// <summary>
  /// Summary description for ActionRef.
  /// </summary>
  public class ActionRef
  {
    private readonly string actionName;
    private readonly IConstraint constraint;
    private readonly bool isLeaf;
    private ArrayList actionRefs = new ArrayList();
    private ActionRef parent = null;

    private ActionWrapper[] actionPath = null;

    private string actionCaption = null;
    private string actionDetail = null;

    public ActionRef(ActionRef parent, string actionName, IConstraint constraint, bool isLeaf)
    {
      this.actionName = actionName;
      this.parent = parent;
      this.constraint = constraint;
      this.isLeaf = isLeaf;
    }

    public void SetActionCaption(string caption, string detail)
    {
      actionCaption = caption;
      actionDetail = detail;
    }

    private ActionWrapper myCachedActionWrapper = null;

    private void InitCaptions()
    {
      if (actionCaption == null)
        actionCaption = Core.Instance.ActionNamingFactory.FindActionCaption(ActionName);
      if (actionDetail == null)
        actionDetail = Core.Instance.ActionNamingFactory.FindActionComment(ActionName);
    }

    public ActionWrapper CreateInstance()
    {
      InitCaptions();

      if (myCachedActionWrapper == null)
      {
        myCachedActionWrapper =
          Core.Instance.ActionWrapperFactory.CreateActionWrapper(ActionName, ActionCaption, IsLeaf);
      }
      return myCachedActionWrapper;
    }

    public ActionWrapper[] GetActionPath()
    {
      if (actionPath == null)
      {
        ArrayList list = new ArrayList();
        ActionRef action = this;
        while (action != null)
        {
          list.Add(action.CreateInstance());
          action = action.Parent;
        }
        list.Reverse();
        actionPath = (ActionWrapper[]) list.ToArray(typeof (ActionWrapper));
      }
      return actionPath;
    }

    public IConstraint Constraint
    {
      get { return constraint; }
    }

    public string ActionName
    {
      get { return actionName; }
    }

    public bool IsLeaf
    {
      get { return isLeaf; }
    }

    public ActionRef Parent
    {
      get { return parent; }
    }

    public void AddActionRef(ActionRef action)
    {
      actionRefs.Add(action);
    }

    public ActionRef[] ActionRefs
    {
      get { return (ActionRef[]) actionRefs.ToArray(typeof (ActionRef)); }
    }

    public string ActionCaption
    {
      get { return actionCaption; }
    }

    public string ActionDetail
    {
      get { return actionDetail; }
    }

    public override string ToString()
    {
      return
        string.Format("ActionRef [name = {0}, constraint = {2},  isLeaf = {1}]", actionName, isLeaf,
                      constraint.ToString());
    }

    public string DumpTree()
    {
      StringBuilder sb = new StringBuilder();
      DumpContext(0, sb);
      return sb.ToString();
    }

    private void DumpContext(int depth, StringBuilder sb)
    {
      string tab = new string('\t', depth);

      sb.Append(tab);
      sb.Append(ToString());
      sb.Append("\n");
      foreach (ActionRef actionRef in ActionRefs)
      {
        actionRef.DumpContext(depth + 1, sb);
      }
    }
  }
}