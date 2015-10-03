using DSIS.Core.System;

namespace DSIS.UI.UI
{
  public class ApplicationDocument : IApplicationDocument
  {
    private readonly string myTitle;
    private readonly ISystemInfo myInfo;
    private readonly ISystemSpace mySpace;

    public ApplicationDocument(string title, ISystemInfo info, ISystemSpace space)
    {
      myTitle = title;
      myInfo = info;
      mySpace = space;
    }

    public ISystemInfo System
    {
      get { return myInfo; }
    }

    public ISystemSpace Space
    {
      get { return mySpace; }
    }

    public string Title
    {
      get { return myTitle; }
    }
  }
}