using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using DSIS.UI.Wizard.ListSelector;
using DSIS.Utils;

namespace DSIS.UI.Wizard.FieldInfos
{
  public abstract class EnumFieldInfoBase<T> : FieldInfoBase
  {
    private readonly IListSelectorFactory myListSelectorFactory;

    protected EnumFieldInfoBase(PropertyInfo property, object instance, IListSelectorFactory listSelectorFactory) : base(property, instance)
    {
      myListSelectorFactory = listSelectorFactory;
    }

    protected abstract IEnumerable<ListInfo<Wrapper>> CreateListInfos();

    protected override Control CreateControl()
    {
      var infos = CreateListInfos().ToArray();
      Wrapper val = null;
      var objectValue = (T) Value;
      foreach (var info in infos)
      {
        if (Equals(info.Value.Value,objectValue))
        {
          val = info.Value;
        }
      }
      var cnt = myListSelectorFactory.Create<ListInfo<Wrapper>, Wrapper>(infos);
      cnt.SelectionChanged += delegate
                                {
                                  var value = cnt.SelectedValue;
                                  if (value != null)
                                  {
                                    Value = value.Value;
                                  }
                                };
      if (val != null)
        cnt.SelectedValue = val;

      return cnt;
    }

    protected Wrapper Wrap(T value)
    {
      return new Wrapper(value);
    }

    public class Wrapper
    {
      public readonly T Value;

      public Wrapper(T value)
      {
        Value = value;
      }
    }
  }
}