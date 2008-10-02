using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Context=DSIS.Scheme.Ctx.Context;

namespace DSIS.UI.Application.Actions
{



  [AttributeUsage(AttributeTargets.Struct|AttributeTargets.Class)]
  public class MenuItemActionAttribute : Attribute
  {
    public string Name { get; set; }    
  }
}
