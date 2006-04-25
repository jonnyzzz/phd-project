using System.Collections;
using EugenePetrenko.Gui2.Kernell2.Node;

namespace EugenePetrenko.Gui2.Kernell2.Actions
{
  /// <summary>
  /// Summary description for ComputationChain.
  /// </summary>
  public class ActionChain
  {
    private ArrayList actions = new ArrayList();

    public ActionChain()
    {
    }

    public void AddAction(ActionWrapper action)
    {
      actions.Add(action);
    }

    public void AddActionRange(ActionWrapper[] actions)
    {
      this.actions.AddRange(actions);
    }

    public ActionWrapper[] Actions
    {
      get { return (ActionWrapper[]) actions.ToArray(typeof (ActionWrapper)); }
    }

    public bool PublishResults
    {
      get
      {
        ActionWrapper[] actions = Actions;
        return actions[actions.Length - 1].PublishResults;
      }
    }

    public ResultSet Do(ResultSet resultSet, ProgressBarInfo progressBarInfo)
    {
      foreach (ActionWrapper action in actions)
      {
        resultSet = action.Do(resultSet, progressBarInfo);
      }
      return resultSet;
    }
  }
}