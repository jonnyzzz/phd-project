using System;
using System.Collections.Generic;
using DSIS.UI.UI;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.Application.Doc.Actions
{  
  [DocumentComponent]
  public class DocumentActionManager : IDocumentActionManager, IDisposable 
  {
    private readonly IDocumentManager myManager;
    private readonly IComponentService myChildContainer;
    private readonly Update myLock = new Update();
    
    public DocumentActionManager(IInvocator invocator, ISubContainerFactory container, IDocumentManager manager)
    {
      myManager = manager;
      var factory = container.SubContainer<DocumentActionAttribute>();
      myChildContainer = factory.Start();

      myLock.LockTaken += LockChanged;
      myLock.LockReturned += LockChanged;

      myManager.OperationTaken += OnLockTaken;
    }

    private void OnLockTaken(object x, OperationEventArgs v)
    {
      if (v.IsOperationTaken)
        myLock.TakeLock();
      else
        myLock.FreeLock();
    }

    private void LockChanged(object sender, EventArgs argz)
    {
      ActionAvailabilityChanged.Fire(sender, argz);
    }

    public void UpdateActionAvailability()
    {
      ActionAvailabilityChanged.Fire(this, EventArgs.Empty);
    }

    public event EventHandler<EventArgs> ActionAvailabilityChanged;

    public IEnumerable<IDocumentActionEx> GetActions()
    {
      foreach (var action in myChildContainer.GetComponents<IDocumentAction>())
      {
        var attr = action.GetType().OneInstance<DocumentActionAttribute>();
        yield return new DocumentActionEx(
          action,
          attr.Caption,
          attr.Description,
          myLock);
      }
    }

    public IDisposable DisableActions()
    {
      return myLock.TakeLock();
    }

    public void Dispose()
    {
      myChildContainer.Dispose();
      myManager.OperationTaken -= OnLockTaken;
    }

    private class DocumentActionEx : IDocumentActionEx
    {
      private readonly ILock myLock;
      private readonly IDocumentAction myHost;
      private readonly string myCaption;
      private readonly string myDescription;

      public DocumentActionEx(IDocumentAction host, string caption, string description, ILock @lock)
      {
        myHost = host;
        myLock = @lock;
        myCaption = caption;
        myDescription = description;
      }

      public bool Compatible
      {
        get { return myLock.IfFree(()=>myHost.Compatible, ()=>false); }
      }

      public void Apply()
      {
        using (myLock.TakeLock())
        {
          myHost.Apply();
        }
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
  }
}