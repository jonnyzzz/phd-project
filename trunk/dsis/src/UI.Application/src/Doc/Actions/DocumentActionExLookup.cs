using System;
using System.Collections.Generic;
using DSIS.Core.Ioc;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Doc.Actions
{
  [DocumentComponent]
  public class DocumentActionExLookup : IDocumentActionManager, IDisposable 
  {
    private readonly IComponentContainer myChildContainer;

    public DocumentActionExLookup(ISubContainerFactory container)
    {
      myChildContainer = container.SubContainer<DocumentActionAttribute>();
      myChildContainer.Start();
    }

    public IEnumerable<IDocumentActionEx> GetActions()
    {
      foreach (var action in myChildContainer.GetComponents<IDocumentAction>())
      {
        var attr = action.GetType().OneInstance<DocumentActionAttribute>();
        yield return new DocumentActionEx(
          action,
          attr.Caption,
          attr.Description);
      }
    }

    private class DocumentActionEx : IDocumentActionEx
    {
      private readonly IDocumentAction myHost;
      private readonly string myCaption;
      private readonly string myDescription;

      public DocumentActionEx(IDocumentAction host, string caption, string description)
      {
        myHost = host;
        myCaption = caption;
        myDescription = description;
      }

      public bool Compatible
      {
        get { return myHost.Compatible; }
      }

      public void Apply()
      {
        myHost.Apply();
      }

      public string Caption
      {
        get { return myCaption; }
      }

      public string Description
      {
        get { return myDescription; }
      }
    }

    public void Dispose()
    {
      myChildContainer.Dispose();
    }
  }
}