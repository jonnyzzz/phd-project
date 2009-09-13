using System;
using System.Reflection;
using System.Windows.Forms;
using log4net;

namespace EugenePetrenko.Core.FormGenerator.FieldInfos
{
  public class CalendarFieldInfo : FieldInfoBase
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (CalendarFieldInfo));

    public CalendarFieldInfo(PropertyInfo property, object instance) : base(property, instance)
    {
    }

    protected override Control CreateControl()
    {
      var control = new MonthCalendar();
      control.DateSelected += delegate
                                {
                                  try
                                  {
                                    Value = control.SelectionStart;
                                  }
                                  catch (Exception e)
                                  {
                                    FireError("Не удалось выбрать дату. " + e.Message);
                                    LOG.Warn(e);
                                  }
                                };
      if ((DateTime)Value < new DateTime(1900, 1, 1))
      {
        control.SetDate(DateTime.Now);
      } else
      {
        control.SetDate((DateTime) Value);
      }
      return control;
    }
  }
}