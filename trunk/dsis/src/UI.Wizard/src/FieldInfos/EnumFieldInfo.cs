using System.Collections.Generic;
using System.Reflection;
using DSIS.UI.Wizard.ListSelector;

namespace DSIS.UI.Wizard.FieldInfos
{
  public class EnumFieldInfo<T> : EnumFieldInfoBase<T>
  {
    public delegate Wrapper DWrap(T t);

    public delegate IEnumerable<ListInfo<Wrapper>> Create(DWrap factory);

    private readonly Create myFactory;

    public EnumFieldInfo(PropertyInfo property, object instance, IListSelectorFactory listSelectorFactory,
                         Create factory) : base(property, instance, listSelectorFactory)
    {
      myFactory = factory;
    }

    protected override IEnumerable<ListInfo<Wrapper>> CreateListInfos()
    {
      return myFactory(Wrap);
    }
  }
}