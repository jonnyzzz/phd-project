using System;

namespace DSIS.Scheme.Impl.Exec
{
  internal class ActionWrapper : IEquatable<ActionWrapper>
  {
    public readonly IAction Action;

    public ActionWrapper(IAction action)
    {
      Action = action;
    }

    public bool Equals(ActionWrapper actionWrapper)
    {
      if (actionWrapper == null) return false;
      return Equals(Action, actionWrapper.Action);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(this, obj)) return true;
      return Equals(obj as ActionWrapper);
    }

    public override int GetHashCode()
    {
      return Action.GetHashCode();
    }
  }
}