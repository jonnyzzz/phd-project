using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using EugenePetrenko.Core.FormGenerator.ListSelector;

namespace EugenePetrenko.Core.FormGenerator.FieldInfos
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
      var infos = myFactory(Wrap).ToList();
      if (infos.Count == 0)
      {
        throw new Exception(
          string.Format("Failed to create selector with 0 elements. Make sure you marked enum members with {0}",
                        typeof (IncludeValueAttribute)));
      }
      return infos;
    }
  }
}