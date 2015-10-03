using System;
using DSIS.UI.UI;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.Application.Doc
{
  [ComponentImplementation(Startable = true)]
  public class DocUIManager : IDisposable
  {
    private readonly IApplicationClass myApp;
    private readonly IMainForm myMainForm;
    private readonly ISubContainerFactory myRootContainer;
    
    private IComponentService myDocumentContainer;

    public DocUIManager(IApplicationClass app, IMainForm mainForm, ISubContainerFactory rootContainer)
    {
      myApp = app;
      myRootContainer = rootContainer;
      myMainForm = mainForm;

      myApp.DocumentChanged += DocumentChanged;
    }

    private void DocumentChanged(object sender, DocumentChangedEventArgs e)
    {
      DisposeDocumentContainer();
      IApplicationDocument document = e.NewDocument;

      var c = CreateContainer(document);

      var f = c.GetComponent<IDocumentMainControl>();
      myMainForm.SetContent(f.Control);
    }

    private IComponentService CreateContainer(IApplicationDocument document)
    {
      var c  =
        myRootContainer.SubContainer<DocumentComponent>();
      
      //Predefined container-wide object
      c.RegisterComponent(document);

      return myDocumentContainer = c.Start();
    }

    public void Dispose()
    {
      DisposeDocumentContainer();
    }

    private void DisposeDocumentContainer()
    {
      if (myDocumentContainer != null)
      {
        myDocumentContainer.GetComponents<IDocumentComponent>().ForEach(x => x.BeforeDocumentContainerDisposed());
        myDocumentContainer.Dispose();
        myDocumentContainer = null;
      }
    }
  }
}