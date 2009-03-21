using System;
using System.Windows.Forms;
using DSIS.Core;
using DSIS.Core.Ioc;
using DSIS.UI.UI;

namespace DSIS.UI.Application
{
  [ComponentImplementation(Startable = true)]
  public class MemoryIndicatorStatusBar
  {
    private const long K = 1024;
    private const long M = 1024*K;

    private readonly IMemoryUsage myMem;

    public MemoryIndicatorStatusBar(IMainForm form, IInvocator invocator, IMemoryUsage mem)
    {
      myMem = mem;
      form.AfterFormCreated +=
        delegate
          {
            var lbl = new ToolStripLabel
                        {
                          Text = "??? mb",
                        };

            invocator.ExecuteRepeating(
              "Update memory indicator",
              TimeSpan.FromSeconds(1),
              () => { lbl.Text = PresentMemoryUsage(); });

            form.AddStatusBarControl(lbl);
          };
    }

    private string PresentMemoryUsage()
    {
      var info = myMem.GetMemoryUsage();

      return info.TotalVirtualMemory != null 
        ? string.Format("Memory usage {0} mb of {1} mb", info.HeapMemory/M, info.TotalVirtualMemory/M) 
        : string.Format("Memory usage {0} mb", info.HeapMemory);
    }
  }
}