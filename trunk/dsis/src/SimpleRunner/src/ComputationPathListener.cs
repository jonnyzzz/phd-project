using System;
using System.IO;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class ComputationPathListener<T,Q> : ProvideExternalListenerBase<T,Q, IComputationPathListener>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    private readonly string myPath;
    private int myUnique = 0;

    public ComputationPathListener(string path)
    {
      myPath = path;
    }

    private static string ToSafePath(string s)
    {
      return s.Replace("`", "_").Replace(",", ".").Replace(" ", "_");
    }

    private string CreateTitle(AbstractImageBuilderContext<Q> cx)
    {
      return ToSafePath(string.Format("{0}-{1}", cx.Info.PresentableName, cx.Builder.PresentableName) + "-" + myUnique++);
    }


    public override VoidDelegate ComputationStartedC(T system, AbstractImageBuilderContext<Q> cx, bool isUnsimmetric)
    {
      string title = CreateTitle(cx);
      return delegate
               {
                 FireListeners(delegate(IComputationPathListener obj)
                                 {
                                   foreach (Pair<string, Action<string>> pair in obj.FormatPath)
                                   {
                                     pair.Second(Path.Combine(myPath, string.Format(pair.First, title)));
                                   }
                                   obj.ComputationTitle(title);
                                 });
               };
    }
  }
}