/*
 * Created by: 
 * Created: 4 февраля 2007 г.
 */

using DSIS.Core.System;
using DSIS.Core.Util;

namespace DSIS.Core.Visualization
{
  public interface IImageDrawer
  {
    IImageBuilder CreateBuilder(ISystemInfo system);
    void RenderToFile(IProgressInfo info, string file, IImageBuilder builders);
  }

  public class ImageDrawerParams
  {
    public readonly string Title;
    public readonly int Width = 1000;
    public readonly int Height = 1000;
    public readonly bool ShowHistory = true;

    public ImageDrawerParams(string title)
    {
      Title = title;
    }

    public ImageDrawerParams(string title, int width, int height, bool showHistory)
    {
      Title = title;
      Width = width;
      Height = height;
      ShowHistory = showHistory;
    }
  }
}